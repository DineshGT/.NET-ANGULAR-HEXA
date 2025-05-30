
USE AutoMobileData

--ALTER TABLE---
ALTER TABLE Products
ADD Description NVARCHAR(50) NULL

ALTER TABLE Products
ALTER COLUMN Product_Name NVARCHAR(100) NOT NULL

ALTER TABLE Products
DROP COLUMN Description

EXEC sp_rename 'Products.Product_Name','Pro_Name','COLUMN'

