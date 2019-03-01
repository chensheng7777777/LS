USE [ls_cms]
GO
/****** Object:  Table [dbo].[ls_visit_log]    Script Date: 03/01/2019 17:23:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ls_visit_log](
	[id] [uniqueidentifier] NOT NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](32) NULL,
	[visit_ip] [nvarchar](50) NULL,
	[visit_time] [datetime] NULL,
	[visit_url] [nvarchar](64) NULL,
	[visit_area] [nvarchar](64) NULL,
	[visit_os] [nvarchar](64) NULL,
	[visit_browser] [nvarchar](64) NULL,
 CONSTRAINT [PK_ls_visit_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ls_user_role]    Script Date: 03/01/2019 17:23:24 ******/
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
/****** Object:  Table [dbo].[ls_user]    Script Date: 03/01/2019 17:23:24 ******/
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
/****** Object:  Table [dbo].[ls_role_nav]    Script Date: 03/01/2019 17:23:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ls_role_nav](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[nav_id] [int] NOT NULL,
 CONSTRAINT [PK_ls_role_nav] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ls_role]    Script Date: 03/01/2019 17:23:24 ******/
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
/****** Object:  Table [dbo].[ls_nav]    Script Date: 03/01/2019 17:23:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ls_nav](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
	[nav_name] [nvarchar](32) NOT NULL,
	[nav_title] [nvarchar](32) NOT NULL,
	[icon_url] [nvarchar](64) NULL,
	[link_url] [nvarchar](64) NULL,
	[nav_status] [int] NOT NULL,
	[nav_desc] [nvarchar](64) NULL,
	[create_time] [datetime] NOT NULL,
 CONSTRAINT [PK_ls_nav] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ls_log]    Script Date: 03/01/2019 17:23:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ls_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[action_type] [nvarchar](100) NULL,
	[remark] [nvarchar](255) NULL,
	[user_ip] [nvarchar](30) NULL,
	[add_time] [datetime] NULL,
 CONSTRAINT [PK_DT_MANAGER_LOG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
