CREATE TABLE [dbo].[Transactions]
(
	[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	[Account_Holder] VARCHAR (150) NOT NULL,
	[Branch_Code] INT NOT NULL,
	[Account_Number] INT NOT NULL,
	[Account_Type] INT NOT NULL,
	[Transaction_Date] DATE NOT NULL,
	[Amount] DECIMAL NOT NULL,
	[Status] INT NOT NULL,
	[Effective_Status_Date] DATE NOT NULL
)
