CREATE VIEW [dbo].[VulcanTransactionView] AS
(
	SELECT
		DISTINCT([BranchCode]),
		SUM([Amount]) as [Total Amount]
	FROM [dbo].[VulcanTransaction]
)