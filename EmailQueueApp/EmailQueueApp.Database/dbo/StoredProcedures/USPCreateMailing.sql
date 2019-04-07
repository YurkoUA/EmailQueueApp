CREATE PROCEDURE [dbo].[USPCreateMailing]
	@Subject NVARCHAR(255),
	@Body NVARCHAR(1024),
	@SendingTime DATETIME,
	@Addresses MailingAddressType READONLY
AS
	BEGIN TRANSACTION
	BEGIN TRY

		DECLARE @MailingId INT
		DECLARE @MailingAddresses TABLE (
			[Id] INT,
			[Email] VARCHAR(128)
		)

		INSERT INTO [Mailing]([Subject], [Body], [SendingTime])
		VALUES (@Subject, @Body, @SendingTime)

		SET @MailingId = SCOPE_IDENTITY()

		INSERT INTO [MailingAddress]([MailingId], [Email], [RepeatCount])
		OUTPUT INSERTED.[Id], INSERTED.[Email] INTO @MailingAddresses([Id], [Email])
		SELECT	@MailingId, [a].[Email], [a].[RepeatCount]
		FROM @Addresses AS [a]

		SELECT @MailingId
		SELECT [Id], [Email] FROM @MailingAddresses

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
