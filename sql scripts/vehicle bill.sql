CREATE TABLE VehicleBills (
    [ID]         INT             IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100)  NOT NULL,
    [Date]       DATETIME        NOT NULL,
    [Amount]     DECIMAL (16, 2) NOT NULL,
    [Comments]   NVARCHAR (500)  NULL,
    [IsPrepared] BIT             NULL,
    [IsVerified] BIT             NULL,
    [IsPassed]   BIT             NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

