
Use AutoMobileData

--TO CREATE A TABLE--

CREATE TABLE Categories(
Category_Id		INT				PRIMARY KEY,
Category_Name	NVARCHAR(50)	NOT NULL
)

CREATE TABLE Brands(
Brand_Id	INT					PRIMARY KEY,
Brand_Name	NVARCHAR(50)		NOT NULL
)

CREATE TABLE Products(
Product_Id		INT				IDENTITY(100,1) PRIMARY KEY,
Product_Name	NVARCHAR(50)	NOT NULL,
Category_Id		INT				NOT NULL,
Brand_Id		INT				NOT NULL,
List_Price		NUMERIC(18,2)	NOT NULL,
FOREIGN KEY(Category_Id) REFERENCES Categories(Category_Id) ON DELETE CASCADE,
FOREIGN KEY(Brand_Id) REFERENCES Brands(Brand_Id) ON DELETE CASCADE
)

CREATE TABLE Customers(
Customer_Id		INT				IDENTITY(1,1) PRIMARY KEY,
First_Name		NVARCHAR(50)	NOT NULL,
Last_Name		NVARCHAR(50)	NOT NULL,
Name			AS(First_Name+' '+Last_Name),
Email			NVARCHAR(100)	UNIQUE,
Pin_Code		INT				CHECK(Pin_Code>0) NOT NULL
)

CREATE TABLE Order_Details(
Order_Id		INT			PRIMARY KEY,
Order_Date		DATETIME	NOT NULL,
Delivery_Date	DATETIME	NOT NULL,
Customer_Id		INT			NOT NULL,
FOREIGN KEY(Customer_Id) REFERENCES Customers(Customer_Id) ON DELETE CASCADE
)

CREATE TABLE Order_Item_Info(
Order_Id		INT				NOT NULL,
Product_Id		INT				NOT NULL,
Price			NUMERIC(10,2)	NOT NULL,
Qty				INT				NOT NULL,
Total			AS(Price*Qty),
FOREIGN KEY(Order_Id) REFERENCES Order_Details(Order_Id) ON DELETE CASCADE,
FOREIGN KEY(Product_Id) REFERENCES Products(Product_Id) ON DELETE CASCADE
)