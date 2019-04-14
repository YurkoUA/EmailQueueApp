CREATE PROCEDURE [dbo].[USPServiceUpdateStatus]
	@StatusCollection [MessageStatusType] READONLY
AS
	UPDATE [ma]
	SET [ma].[StatusId] = [st].[StatusId]
	FROM [MailingAddress] AS [ma]
	JOIN @StatusCollection AS [st] ON [st].[MailingAddressId] = [ma].[Id]
RETURN 0
