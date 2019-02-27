USE [ls_cms]
GO
/****** Object:  Table [dbo].[ls_user_role]    Script Date: 02/27/2019 17:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ls_user_role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_ls_user_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ls_user]    Script Date: 02/27/2019 17:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ls_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](32) NOT NULL,
	[user_mobile] [nvarchar](32) NULL,
	[user_email] [nvarchar](32) NULL,
	[user_password] [nvarchar](64) NOT NULL,
	[user_salt] [nvarchar](32) NOT NULL,
	[user_avatar] [nvarchar](64) NULL,
	[user_birth] [datetime] NULL,
	[nick_name] [nvarchar](32) NULL,
	[real_name] [nvarchar](50) NULL,
	[create_time] [datetime] NOT NULL,
	[create_ip] [nvarchar](50) NULL,
	[user_status] [int] NOT NULL,
 CONSTRAINT [PK_ls_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ls_role]    Script Date: 02/27/2019 17:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ls_role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](32) NOT NULL,
	[create_time] [datetime] NOT NULL,
	[role_status] [int] NOT NULL,
 CONSTRAINT [PK_ls_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
