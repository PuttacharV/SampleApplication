
CREATE TABLE dbo.tableMedicines (
    MedicineId INT IDENTITY(1,1),
    MedicineName NVARCHAR(100) NOT NULL,	
	Brand NVARCHAR(100) NOT NULL,
	Price NUMERIC(10,2) NOT NULL,
	Quantity INT NOT NULL,
	ExpiryDate DATETIME NOT NULL,
	Notes NVARCHAR(250) NOT NULL,
	CreatedOn DATETIME NOT NULL,
	ModifiedOn DATETIME NOT NULL,

	CONSTRAINT tableMedicines_PK PRIMARY KEY (MedicineId)
);

CREATE TABLE dbo.lnkMedicineOrder (
    OrderId INT IDENTITY(1,1),
    MedicineId INT NOT NULL,	
	OrderQuantity INT NOT NULL,
	OrderedBy NVARCHAR(250) NOT NULL,
	OrderCreatedOn DateTime NOT NULL,
	OrderStatus NVARCHAR(50) NOT NULL

	CONSTRAINT lnkMedicineOrder_PK PRIMARY KEY (OrderId)
);

ALTER TABLE dbo.lnkMedicineOrder
ADD CONSTRAINT lnkMedicineOrder_tableMedicines_FK
FOREIGN KEY(MedicineId) REFERENCES dbo.tableMedicines(MedicineId);
