CREATE TABLE [dbo].[MailingAddress]
(
	[Id] INT IDENTITY NOT NULL,
	[MailingId] INT NOT NULL,
	[Email] VARCHAR(128) NOT NULL,
	[StatusId] INT NOT NULL CONSTRAINT [DF_MailingAddress_StatusId] DEFAULT(1),
	[RepeatCount] INT NOT NULL CONSTRAINT [DK_MailingAddress_Count] DEFAULT(1)

	CONSTRAINT [PK_MailingAddress] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_MailingAddress_MailingId_Mailing_Id] FOREIGN KEY([MailingId]) REFERENCES [dbo].[Mailing]([Id]),
	CONSTRAINT [FK_MailingAddress_StatusId_tMailStatus_Id] FOREIGN KEY([StatusId]) REFERENCES [dbo].[tMailStatus]([Id])
)
