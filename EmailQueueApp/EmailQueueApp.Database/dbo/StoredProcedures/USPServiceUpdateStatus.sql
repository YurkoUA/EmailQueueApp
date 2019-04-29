CREATE PROCEDURE [dbo].[USPServiceUpdateStatus]
	@StatusCollection [MessageStatusType] READONLY
AS
	BEGIN TRANSACTION
	BEGIN TRY

		UPDATE [ma]
		SET [ma].[StatusId] = [st].[StatusId]
		FROM [MailingAddress] AS [ma]
		JOIN @StatusCollection AS [st] ON [st].[MailingAddressId] = [ma].[Id]


		INSERT INTO [MailingLog]([MailingAddressId], [StatusId], [LogTime])
		SELECT	[s].[MailingAddressId], [s].[StatusId], GETUTCDATE()
		FROM @StatusCollection AS [s]

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION
		END;
		THROW;
	END CATCH;

	IF @@TRANCOUNT > 0
	BEGIN
		COMMIT TRANSACTION 
	END;
	
RETURN 0
