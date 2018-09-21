SELECT * FROM AspNetUsers
SELECT * FROM Menu

DROP TABLE ProductDrink
DROP TABLE ProductFood
DROP TABLE ProductMenu
DROP TABLE menu
DROP TABLE Products




CREATE TABLE [dbo].[Products] (
    [ProductId]          INT     IDENTITY (1, 1)     NOT NULL,
    [ProductName]        VARCHAR (MAX) NOT NULL,
    [ProductDescription] VARCHAR (MAX) NULL,
    [ProductImagePath]   VARCHAR (MAX) NULL,
    [ProductPrice]       VARCHAR (MAX) NOT NULL,
    [ProductIsAvailble]  BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

CREATE TABLE [dbo].[Menu] (
    [MenuId]          INT           IDENTITY (1, 1) NOT NULL,
    [MenuName]        VARCHAR (MAX) NOT NULL,
    [MenuDescription] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([MenuId] ASC)
);

CREATE TABLE [dbo].[ProductMenu] (
    [ProductMenuId] INT IDENTITY (1, 1) NOT NULL,
    [ProductId]     INT NOT NULL,
    [MenuId]        INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductMenuId] ASC),
);


CREATE TABLE [dbo].[ProductFood] (
    [FoodId]   INT IDENTITY (1, 1) NOT NULL,
    [ProductId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([FoodId] ASC),
);


CREATE TABLE [dbo].[ProductDrink] (
    [DrinkId]        INT IDENTITY (1, 1) NOT NULL,
    [DrinkIsAlcohol] BIT NOT NULL,
    [ProductId]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([DrinkId] ASC)
);


CREATE TABLE Employees(
ID INT PRIMARY KEY IDENTITY,
firstname NVARCHAR(50),
lastname NVARCHAR(50),
salary INT
)
GO

INSERT into employees VALUES ('Mark', 'Hasting', 300000)
INSERT into employees VALUES ('Mark2', 'Hasting3', 31000)
INSERT into employees VALUES ('Mark4', 'Hasting', 300)
INSERT into employees VALUES ('Mark32', 'Hasting4', 30003100)


INSERT into dbo.Menu
(
    MenuName,
    MenuDescription
)
VALUES
(   
    'Food', -- MenuName - varchar(max)
    'Food Menu'  -- MenuDescription - varchar(max)
    ) 

	INSERT into dbo.Menu
(
    MenuName,
    MenuDescription
)
VALUES
( 
    'Drink', -- MenuName - varchar(max)
    'Drink Menu'  -- MenuDescription - varchar(max)
    ) 

	INSERT INTO dbo.Products
	(
	    ProductName,
	    ProductDescription,
	    ProductImagePath,
	    ProductPrice,
	    ProductIsAvailble
	)
	VALUES
	(
	    'Hamburger',  -- ProductName - varchar(max)
	    'Standard Hamburger',  -- ProductDescription - varchar(max)
	    'path.com/images/imagepath.png',  -- ProductImagePath - varchar(max)
	    '8.95',  -- ProductPrice - varchar(max)
	    1 -- ProductIsAvailble - bit
	    )	
		
		INSERT INTO dbo.Products
	(
	    ProductName,
	    ProductDescription,
	    ProductImagePath,
	    ProductPrice,
	    ProductIsAvailble
	)
	VALUES
	(
	    'Coors Light',  -- ProductName - varchar(max)
	    'Coors Light Tall Can',  -- ProductDescription - varchar(max)
	    'path.com/images/coorslight.png',  -- ProductImagePath - varchar(max)
	    '7',  -- ProductPrice - varchar(max)
	    1 -- ProductIsAvailble - bit
	    )

		INSERT INTO dbo.ProductMenu
		(
		    ProductId,
		    MenuId
		)
		VALUES
		(
		    1, -- ProductId - int
		    1  -- MenuId - int
		    )

		INSERT INTO dbo.ProductMenu
		(
		    ProductId,
		    MenuId
		)
		VALUES
		(
		    2, -- ProductId - int
		    2  -- MenuId - int
		    )

			INSERT INTO dbo.ProductDrink
			(
			    DrinkIsAlcohol,
			    ProductId
			)
			VALUES
			(   
			    1, -- DrinkIsAlcohol - bit
			    2     -- ProductId - int
			    )

				INSERT INTO dbo.ProductFood
				(
				    ProductId
				)
				VALUES
				(   
				    1  -- ProductId - int
				    )
			