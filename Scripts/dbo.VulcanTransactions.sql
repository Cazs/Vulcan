CREATE TABLE [dbo].[VulcanTransaction] (
    [Id]                  INT   NOT NULL,
    [AccountHolder]       VARCHAR (150) NOT NULL,
    [BranchCode]          INT           NOT NULL,
    [AccountNumber]       BIGINT           NOT NULL,
    [AccountType]         INT           NOT NULL,
    [TransactionDate]     DATE          NOT NULL,
    [Amount]              MONEY  NOT NULL,
    [Status]              INT           NOT NULL,
    [EffectiveStatusDate] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
