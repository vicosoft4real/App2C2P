USE [App2c2pDb]
GO
/****** Object:  StoredProcedure [dbo].[GetCard]    Script Date: 10/10/2018 7:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCard]
	                            @card nvarchar(19)
                    AS
                    BEGIN
	                -- SET NOCOUNT ON added to prevent extra result sets from
	                -- interfering with SELECT statements.
	                SET NOCOUNT ON;

                    -- select statements for card
	                SELECT TOP(1) * FROM CreditCards WHERE Card=@card
                    END

GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/10/2018 7:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 10/10/2018 7:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Card] [nvarchar](19) NOT NULL,
	[CardDescription] [nvarchar](max) NULL,
	[ExpiryDate] [int] NOT NULL,
 CONSTRAINT [PK_CreditCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181009151332_App2c2p_Context_init', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181009154626_CreditCard_ExiiryDate_added', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181009164602_GetCard', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181010083644_Card_length_updated', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181010173929_Seed_Data', N'2.1.3-rtm-32065')
SET IDENTITY_INSERT [dbo].[CreditCards] ON 

INSERT [dbo].[CreditCards] ([Id], [DateCreated], [IsDeleted], [IsActive], [Card], [CardDescription], [ExpiryDate]) VALUES (1, CAST(0x07007292639CD03E0B AS DateTime2), 0, 1, N'4909-2832-8723-8888', N'Visa Card Sample', 81980)
INSERT [dbo].[CreditCards] ([Id], [DateCreated], [IsDeleted], [IsActive], [Card], [CardDescription], [ExpiryDate]) VALUES (2, CAST(0x07109992639CD03E0B AS DateTime2), 0, 1, N'5909-2222-8723-8888', N'Master Card Sample', 81933)
INSERT [dbo].[CreditCards] ([Id], [DateCreated], [IsDeleted], [IsActive], [Card], [CardDescription], [ExpiryDate]) VALUES (3, CAST(0x07109992639CD03E0B AS DateTime2), 0, 1, N'3409-2222-8723-888', N'Amex Card Sample', 81973)
INSERT [dbo].[CreditCards] ([Id], [DateCreated], [IsDeleted], [IsActive], [Card], [CardDescription], [ExpiryDate]) VALUES (5, CAST(0x07109992639CD03E0B AS DateTime2), 0, 1, N'3528-3589-8723-8888', N'JCB Card Sample', 81963)
INSERT [dbo].[CreditCards] ([Id], [DateCreated], [IsDeleted], [IsActive], [Card], [CardDescription], [ExpiryDate]) VALUES (6, CAST(0x07109992639CD03E0B AS DateTime2), 0, 1, N'3709-2222-8723-8888', N'Amex Card Sample', 81963)
SET IDENTITY_INSERT [dbo].[CreditCards] OFF
ALTER TABLE [dbo].[CreditCards] ADD  DEFAULT ((0)) FOR [ExpiryDate]
GO
