CREATE PROCEDURE [dbo].[USPGetAllAddresses]
	@StartDate DATE = NULL,
	@EndDate DATE = NULL,
	@StatusId INT = NULL
AS
	SELECT	[a].[Id],
			[a].[Email],
			[m].[Subject],
			[m].[SendingTime],
			[a].[RepeatCount],
			[a].[StatusId]
	FROM [Mailing] AS [m]
	JOIN [MailingAddress] AS [a] ON [a].[MailingId] = [m].[Id]
	WHERE (@StartDate IS NULL OR [m].[SendingTime] >= @StartDate)
		AND (@EndDate IS NULL OR [m].[SendingTime] <= @EndDate)
		AND (@StatusId IS NULL OR [a].[StatusId] = @StatusId)
RETURN 0
