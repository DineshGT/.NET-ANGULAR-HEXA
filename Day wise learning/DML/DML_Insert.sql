
USE AutoMobileData

--To insert data into a table
INSERT INTO Brands VALUES(100,'INDIAN OIL')

SELECT * FROM Brands

INSERT INTO Categories VALUES(110,'Lubricant')

SELECT * FROM Categories

INSERT INTO Products VALUES('Hemlate',110,100,800)

SELECT * FROM Products

INSERT INTO Customers(First_Name,Last_Name,Email,Pin_Code)
VALUES('Sachin','Patil','sachin.patil@gmail.com',422001)

SELECT * FROM Customers

INSERT INTO Order_Details VALUES(111,'10-06-2025','10-10-2025',1)

SELECT * FROM Order_Details

INSERT INTO Order_Item_Info VALUES(111,100,900,2)

SELECT * FROM Order_Item_Info