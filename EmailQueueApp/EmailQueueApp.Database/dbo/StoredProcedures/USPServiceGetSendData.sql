CREATE PROCEDURE [dbo].[USPServiceGetSendData]
AS
	SELECT	[a].[Id],
			[a].[Email],
			[m].[Subject],
			[m].[Body],
			[a].[RepeatCount]
	FROM [Mailing] AS [m]
	JOIN [MailingAddress] AS [a] ON [a].[MailingId] = [m].[Id]
	WHERE [a].[StatusId] = 1 -- New
		AND [m].[SendingTime] <= GETUTCDATE()
RETURN 0
