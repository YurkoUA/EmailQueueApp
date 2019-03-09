DECLARE @MailStatus_01 TABLE (
	[Id] INT,
	[Name] NVARCHAR(32)
)

INSERT INTO [tMailStatus]([Id], [Name])
SELECT	[temp].[Id], [temp].[Name]
FROM @MailStatus_01 AS [temp]
LEFT JOIN [tMailStatus] AS [actual] ON [actual].[Id] = [temp].[Id]
WHERE [actual].[Id] IS NULL