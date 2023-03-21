CREATE TABLE [dbo].[Products_Table] (
    [Product_Id]       INT           NOT NULL IDENTITY,
    [Product_Name]     VARCHAR (100) NULL,
    [Product_Category] VARCHAR (50)  NULL,
    [Product_Price]    MONEY         NULL,
    PRIMARY KEY CLUSTERED ([Product_Id] ASC)
);

