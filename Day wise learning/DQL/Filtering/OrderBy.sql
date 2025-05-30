
--ORDER BY--
SELECT * FROM CUSTOMERS ORDER BY FIRST_NAME

SELECT * FROM customers ORDER BY first_name DESC;

SELECT
    city,
    first_name,
    last_name
FROM
    customers
ORDER BY
    city,
    first_name;


	SELECT
    city,
    first_name,
    last_name
FROM
    customers
ORDER BY
    city DESC,
    first_name ASC;

SELECT FIRST_NAME,LAST_NAME FROM CUSTOMERS ORDER BY LEN(FIRST_NAME) DESC
