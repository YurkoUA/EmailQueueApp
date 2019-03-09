CREATE TABLE [dbo].[MailingLog]
(
	[Id] INT IDENTITY NOT NULL,
	[LogTime] DATETIME NOT NULL CONSTRAINT [DF_MailingLog] DEFAULT(GETUTCDATE()),
	[MailingAddressId] INT NOT NULL,
	[StatusId] INT NOT NULL

	CONSTRAINT [PK_MailingLog] PRIMARY KEY([Id]),
	CONSTRAINT [FK_MailingLog_Id_MailingAddress_Id] FOREIGN KEY([MailingAddressId]) REFERENCES [dbo].[MailingAddress]([Id]),
	CONSTRAINT [FK_MailingLog_StatusId_tMailStatus_Id] FOREIGN KEY([StatusId]) REFERENCES [dbo].[tMailStatus]([Id])
)
