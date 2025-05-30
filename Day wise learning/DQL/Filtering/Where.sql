
---WHERE---
SELECT product_id,product_name,category_id,model_year,list_price FROM products
WHERE category_id = 1 ORDER BY list_price DESC;

SELECT product_id,product_name,category_id,model_year,list_price FROM products
WHERE category_id = 1 OR model_year = 2018 ORDER BY list_price DESC;

SELECT
    product_id,
    product_name,
    category_id,
    model_year,
    list_price 
FROM products WHERE list_price BETWEEN 1899.00 AND 1999.99 ORDER BY list_price DESC;

SELECT
    order_id,
    customer_id,
    order_date,
    order_status
FROM
    orders
WHERE
    order_date BETWEEN '2016-01-1' AND '2017-01-1'
ORDER BY
    order_date;


SELECT
    product_id,
    product_name,
    category_id,
    model_year,
    list_price
FROM
    products
WHERE List_Price IN(299.99,369.99,489.99)
