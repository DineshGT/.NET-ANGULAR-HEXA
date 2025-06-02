CREATE DATABASE Sampledb1;
USE Sampledb1;

-- create tables
CREATE TABLE categories (
	category_id INT IDENTITY (1, 1) PRIMARY KEY,
	category_name VARCHAR (255) NOT NULL
);

CREATE TABLE brands (
	brand_id INT IDENTITY (1, 1) PRIMARY KEY,
	brand_name VARCHAR (255) NOT NULL
);

CREATE TABLE products (
	product_id INT IDENTITY (1, 1) PRIMARY KEY,
	product_name VARCHAR (255) NOT NULL,
	brand_id INT NOT NULL,
	category_id INT NOT NULL,
	model_year SMALLINT NOT NULL,
	list_price DECIMAL (10, 2) NOT NULL,
	FOREIGN KEY (category_id) REFERENCES categories (category_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (brand_id) REFERENCES brands (brand_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE customers (
	customer_id INT IDENTITY (1, 1) PRIMARY KEY,
	first_name VARCHAR (255) NOT NULL,
	last_name VARCHAR (255) NOT NULL,
	phone VARCHAR (25),
	email VARCHAR (255) NOT NULL,
	street VARCHAR (255),
	city VARCHAR (50),
	state VARCHAR (25),
	zip_code VARCHAR (5)
);

CREATE TABLE stores (
	store_id INT IDENTITY (1, 1) PRIMARY KEY,
	store_name VARCHAR (255) NOT NULL,
	phone VARCHAR (25),
	email VARCHAR (255),
	street VARCHAR (255),
	city VARCHAR (255),
	state VARCHAR (10),
	zip_code VARCHAR (5)
);

CREATE TABLE staffs (
	staff_id INT IDENTITY (1, 1) PRIMARY KEY,
	first_name VARCHAR (50) NOT NULL,
	last_name VARCHAR (50) NOT NULL,
	email VARCHAR (255) NOT NULL UNIQUE,
	phone VARCHAR (25),
	active tinyint NOT NULL,
	store_id INT NOT NULL,
	manager_id INT,
	FOREIGN KEY (store_id) REFERENCES stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (manager_id) REFERENCES staffs (staff_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE orders (
	order_id INT IDENTITY (1, 1) PRIMARY KEY,
	customer_id INT,
	order_status tinyint NOT NULL,
	-- Order status: 1 = Pending; 2 = Processing; 3 = Rejected; 4 = Completed
	order_date DATE NOT NULL,
	required_date DATE NOT NULL,
	shipped_date DATE,
	store_id INT NOT NULL,
	staff_id INT NOT NULL,
	FOREIGN KEY (customer_id) REFERENCES customers (customer_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (store_id) REFERENCES stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (staff_id) REFERENCES staffs (staff_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE order_items (
	order_id INT,
	item_id INT,
	product_id INT NOT NULL,
	quantity INT NOT NULL,
	list_price DECIMAL (10, 2) NOT NULL,
	discount DECIMAL (4, 2) NOT NULL DEFAULT 0,
	PRIMARY KEY (order_id, item_id),
	FOREIGN KEY (order_id) REFERENCES orders (order_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (product_id) REFERENCES products (product_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE stocks (
	store_id INT,
	product_id INT,
	quantity INT,
	PRIMARY KEY (store_id, product_id),
	FOREIGN KEY (store_id) REFERENCES stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (product_id) REFERENCES products (product_id) ON DELETE CASCADE ON UPDATE CASCADE
);



-- Case study questions...

-- 1. Write a query to display customer list by the first name in descending order.
SELECT * FROM customers
ORDER BY first_name DESC;


-- 2. Write a query to display the first name, last name, and city of the customers. 
-- It sorts the customer list by the city first and then by the first name.
SELECT first_name, last_name, city FROM customers
ORDER BY city ASC, first_name ASC;



-- 3. Write a query to return the top three most expensive products.
SELECT TOP 3 * FROM products
ORDER BY list_price DESC;



-- 4. Write a query to find the products whose list price is greater than 300 and model year is 2018.
SELECT * FROM products
WHERE list_price > 300 AND model_year = 2018;



-- 5. Write a query to find products whose list price is greater than 3,000 
-- or model year is 2018. Any product that meets one of these conditions is included in the result set.
SELECT * FROM products
WHERE list_price > 3000 OR model_year = 2018;



-- 6. Write a query to find the products whose list prices are between 1,899 and 1,999.99.                         
SELECT * FROM products
WHERE list_price BETWEEN 1899 AND 1999.99;



-- 7. Write a query using the IN operator to find products whose list price is 299.99 or 466.99 or 489.99.
SELECT * FROM products
WHERE list_price IN (299.99, 466.99, 489.99);



-- 8. Write a query to return the customers where the first character in the last name is the letter in the range A through C.
SELECT * FROM customers
WHERE LEFT(last_name, 1) BETWEEN 'A' AND 'C';



-- 9. Write a query using NOT LIKE operator to find customers where the first character in the first name is not the letter A.
SELECT * FROM customers
WHERE first_name NOT LIKE 'A%';



-- 10. Write a query to return the number of customers by state and city, group by state and city.
SELECT state, city, COUNT(*) AS customer_count
FROM customers
GROUP BY state, city;



-- 11. Write a query to return the number of orders placed by the customer, group by customer id and year.
SELECT customer_id, YEAR(order_date) AS order_year, COUNT(*) AS total_orders
FROM orders
GROUP BY customer_id, YEAR(order_date);



-- 12. Write a query to find the maximum and minimum list price group by category id. 
-- Then, filter out the category which has the maximum list price greater than 4,000 
-- or the minimum list price less than 500.
SELECT category_id,
       MAX(list_price) AS max_price,
       MIN(list_price) AS min_price
FROM products
GROUP BY category_id
HAVING MAX(list_price) > 4000 OR MIN(list_price) < 500;
