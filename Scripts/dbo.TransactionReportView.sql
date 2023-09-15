CREATE VIEW [dbo].[VulcanTransactionReportView] AS 
	SELECT ROW_NUMBER() OVER( ORDER BY [BranchCode]) AS [Id], [BranchCode], [AccountType], [Status], [TotalCount], [TotalAmount]
	FROM
	(
		SELECT DISTINCT [Status], [AccountType], [BranchCode], COUNT([Amount]) AS [TotalCount], SUM([Amount]) AS [TotalAmount]
		FROM [dbo].[VulcanTransaction]
		GROUP BY [AccountType], [Status], [BranchCode]
	) vulcanTransactionReport;