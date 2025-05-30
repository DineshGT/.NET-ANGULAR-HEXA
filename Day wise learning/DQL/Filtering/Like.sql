
--LIKE----
SELECT
    customer_id,
    first_name,
    last_name
FROM
    customers
WHERE
    last_name LIKE 'z%'
ORDER BY
    first_name;


SELECT
    customer_id,
    first_name,
    last_name
FROM
    customers
WHERE
    last_name LIKE '%er'
ORDER BY
    first_name;


SELECT
    customer_id,
    first_name,
    last_name
FROM
    customers
WHERE
    last_name LIKE 't%s'
ORDER BY
    first_name;


SELECT * FROM CUSTOMERS WHERE LAST_NAME LIKE '_U%'

SELECT
    customer_id,
    first_name,
    last_name
FROM
    customers
WHERE
    last_name LIKE '[YZ]%'
ORDER BY
    last_name;

	SELECT
    customer_id,
    first_name,
    last_name
FROM
    customers
WHERE
    first_name NOT LIKE 'A%'
ORDER BY
    first_name;