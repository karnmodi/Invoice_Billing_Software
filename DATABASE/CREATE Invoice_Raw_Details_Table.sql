CREATE TABLE Invoice_Raw_Details 
(
	SI_Number int NOT NULL Primary Key,
	Item_Name varchar(50),
	Quantity float,
	Price money,
	Amount money,
	Invoice_No int,
	Invoice_Date date
)