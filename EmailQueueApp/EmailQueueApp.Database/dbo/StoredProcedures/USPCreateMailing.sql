CREATE PROCEDURE [dbo].[USPCreateMailing]
	@Subject NVARCHAR(255),
	@Body NVARCHAR(1024),
	@SendingTime DATETIME,
	@Addresses MailingAddressType READONLY
AS
	BEGIN TRANSACTION
	BEGIN TRY

		DECLARE @MailingId INT
		DECLARE @MailingAddressesIDs IntArrayType

		INSERT INTO [Mailing]([Subject], [Body], [SendingTime])
		VALUES (@Subject, @Body, @SendingTime)

		SET @MailingId = SCOPE_IDENTITY()

		INSERT INTO [MailingAddress]([MailingId], [Email], [RepeatCount])
		OUTPUT INSERTED.[Id] INTO @MailingAddressesIDs([Item])
		SELECT	@MailingId, [a].[Email], [a].[RepeatCount]
		FROM @Addresses AS [a]

		SELECT @MailingId
		SELECT [Item] FROM @MailingAddressesIDs

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
