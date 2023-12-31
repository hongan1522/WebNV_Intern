USE [EmpManager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/29/2023 2:16:47 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/29/2023 2:16:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231025041521_InitialEmployee', N'7.0.13')
GO
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'BE0001', N'string', N'Backend', CAST(N'2023-10-25T09:12:14.057' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'BE0002', N'string', N'Backend', CAST(N'2023-10-27T07:42:26.090' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'BE0003', N'string3', N'Backend', CAST(N'2023-10-26T01:24:25.067' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'BE0004', N'string', N'Backend', CAST(N'2023-10-27T07:42:26.090' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'BE0006', N'string', N'Backend', CAST(N'2023-10-27T07:42:26.090' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'BE0007', N'string', N'Backend', CAST(N'2023-10-27T07:42:26.090' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'BE0008', N'string', N'Backend', CAST(N'2023-10-27T07:42:26.090' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'BE0010', N'string', N'Backend', CAST(N'2023-10-27T07:42:26.090' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0001', N'string2', N'Frontend', CAST(N'2023-10-25T09:13:42.660' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0002', N'string', N'Frontend', CAST(N'2023-10-26T01:54:10.880' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0003', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0004', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string5@gmail.com', N'0111111115', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0006', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0007', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0008', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0009', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0010', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0011', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0014', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0019', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0020', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0021', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'FE0022', N'string', N'Frontend', CAST(N'2023-10-26T03:04:39.610' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'TL0001', N'string', N'Teamlead', CAST(N'2023-10-25T09:48:51.440' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'TL0002', N'string', N'Teamlead', CAST(N'2023-10-25T09:48:51.440' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'TL0003', N'string', N'Teamlead', CAST(N'2023-10-25T09:48:51.440' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'TL0005', N'string', N'Teamlead', CAST(N'2023-10-25T09:48:51.440' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'TL0006', N'string', N'Teamlead', CAST(N'2023-10-25T09:48:51.440' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'TL0007', N'string', N'Teamlead', CAST(N'2023-10-25T09:48:51.440' AS DateTime), N'string', N'string', N'string')
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Birthday], [Email], [Phone], [Address]) VALUES (N'TL0008', N'string', N'Teamlead', CAST(N'2023-10-25T09:48:51.440' AS DateTime), N'string', N'string', N'string')
GO
