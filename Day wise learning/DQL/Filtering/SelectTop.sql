
--SELECT TOP--
SELECT TOP 10
	Product_Id,
    product_name, 
    list_price
FROM
    products
	ORDER BY
	List_Price DESC


SELECT TOP 10 PERCENT
    product_name, 
    list_price
FROM
    products
ORDER BY 
    list_price DESC;

