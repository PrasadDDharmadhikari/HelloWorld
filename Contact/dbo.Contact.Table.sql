/****** Object:  Table [dbo].[Contact]    Script Date: 4/28/2018 4:08:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [int] NULL,
	[Status] [char](10) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ID], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (1, N'Umesh', N'vastre', N'umeshvastre@gmil.com', 12321, N'Active    ')
SET IDENTITY_INSERT [dbo].[Contact] OFF
