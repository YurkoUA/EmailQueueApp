DECLARE @MailStatus_01 TABLE (
	[Id] INT,
	[Name] NVARCHAR(32)
)

INSERT INTO @MailStatus_01([Id], [Name])
VALUES	(1, 'New'),
		(2, 'In Queue'),
		(3, 'Sent'),
		(4, 'Error')

INSERT INTO [tMailStatus]([Id], [Name])
SELECT	[temp].[Id], [temp].[Name]
FROM @MailStatus_01 AS [temp]
LEFT JOIN [tMailStatus] AS [actual] ON [actual].[Id] = [temp].[Id]
WHERE [actual].[Id] IS NULL