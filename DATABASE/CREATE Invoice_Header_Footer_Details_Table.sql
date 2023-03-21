CREATE TABLE Invoice_Header_Footer_Details
(
	Invoice_No int NOT NULL PRIMARY KEY,
	Customer_Name varchar(50),
	Customer_Number varchar(15),
	Invoice_Date date,
	Invoice_Amount money ,
	Tax_Amount money,
	Net_Amount Money,
	Note varchar(50)

)