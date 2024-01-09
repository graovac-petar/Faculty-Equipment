USE [master]
GO
/****** Object:  Database [IRC-EFC]    Script Date: 23/12/2023 3:21:41 PM ******/
CREATE DATABASE [IRC-EFC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IRC-EFC', FILENAME = N'C:\Users\38161\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\IRC-EFC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IRC-EFC_log', FILENAME = N'C:\Users\38161\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\IRC-EFC.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IRC-EFC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IRC-EFC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IRC-EFC] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [IRC-EFC] SET ANSI_NULLS ON 
GO
ALTER DATABASE [IRC-EFC] SET ANSI_PADDING ON 
GO
ALTER DATABASE [IRC-EFC] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [IRC-EFC] SET ARITHABORT ON 
GO
ALTER DATABASE [IRC-EFC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IRC-EFC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IRC-EFC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IRC-EFC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IRC-EFC] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [IRC-EFC] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [IRC-EFC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IRC-EFC] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [IRC-EFC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IRC-EFC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IRC-EFC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IRC-EFC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IRC-EFC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IRC-EFC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IRC-EFC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IRC-EFC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IRC-EFC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IRC-EFC] SET RECOVERY FULL 
GO
ALTER DATABASE [IRC-EFC] SET  MULTI_USER 
GO
ALTER DATABASE [IRC-EFC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IRC-EFC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IRC-EFC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IRC-EFC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IRC-EFC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IRC-EFC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [IRC-EFC] SET QUERY_STORE = OFF
GO
USE [IRC-EFC]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/12/2023 3:21:41 PM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 23/12/2023 3:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Department] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 23/12/2023 3:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SerialNumber] [nvarchar](max) NOT NULL,
	[InventoryNumber] [nvarchar](max) NOT NULL,
	[Quantity] [int] NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentAssignement]    Script Date: 23/12/2023 3:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentAssignement](
	[EquipmentAssignementId] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DateBorrowed] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EquipmentAssignement] PRIMARY KEY CLUSTERED 
(
	[EquipmentAssignementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 23/12/2023 3:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231215094236_Init', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231215120717_SecondMigration', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231216153843_ChangingRoom', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231219114056_TypeObavezan', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (1, N'Petar Graovac', N'IRC')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (3, N'Ivan Lukovic', N'Informacioni Sistemi')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (4, N'Aleksandar Rakićević', N'Laboratorija za Sisteme')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (5, N'Ivan Milenković', N'Informacione tehnologije')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (6, N'Branko Krsmanović', N'Informacioni Sistemi')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (1002, N'Predrag Imšić', N'Informacioni Sistemi')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (2002, N'Luka Petrović', N'IRC')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (2003, N'Milica Zukanović', N'Laboratorija za Sisteme')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (3002, N'Tatjana Stojanović', N'SILAB')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (3003, N'Tatjana Bailović', N'SILAB')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (3004, N'Isidora Vidojević', N'IRC')
INSERT [dbo].[Employee] ([EmployeeId], [Name], [Department]) VALUES (3005, N'Dušan Savić', N'SILAB')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (5, N'Y0139836L95', N'Y0139836', N'001', 5, 0)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (6, N'JEERA9NMP10', N'JEERA9NM', N'002', 2, 0)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (7, N'BNKMAK16K11', N'BNKMAK16', N'003', 1, 0)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (8, N'I1ZHPKLLZ56', N'I1ZHPKLL', N'101', 3, 1)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (9, N'Q4DYU4QBB11', N'Q4DYU4QB', N'102', 3, 1)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (2002, N'HYTP0FEQ03Z', N'HYTP0FEQ', N'103', 5, 1)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (3005, N'BMOJCK93B72', N'BMOJCK93', N'201', 11, 2)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (3006, N'42X2TICUT10', N'42X2TICU', N'202', 13, 2)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (3007, N'J3N4S7SZ123', N'J3N4S7SZ', N'203', 14, 2)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (3008, N'MDTWTX0TM67', N'MDTWTX0T', N'301', 17, 3)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (3009, N'E88N2SE4P43', N'E88N2SE4', N'302', 23, 3)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (3010, N'7C8GB1X0O93', N'7C8GB1X0', N'303', 21, 3)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (3011, N'7GXGRHPCLK3', N'7GXGRHPC', N'304', 2, 3)
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [SerialNumber], [InventoryNumber], [Quantity], [Type]) VALUES (4003, N'AMIFLJYWHJ2', N'AMIFLJYW', N'007', 5, 0)
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[EquipmentAssignement] ON 

INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (7, 5, 3, 2, CAST(N'2022-09-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (8, 6, 4, 5, CAST(N'2023-09-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (2012, 3010, 5, 2, CAST(N'2005-10-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (3002, 7, 1, 2, CAST(N'2023-12-20T20:36:30.6060000' AS DateTime2))
INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (4005, 5, 1002, 2, CAST(N'2023-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (5005, 3011, 3002, 1004, CAST(N'2020-05-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (5006, 3009, 3003, 1004, CAST(N'2023-11-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (5007, 3005, 6, 1, CAST(N'2021-11-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[EquipmentAssignement] ([EquipmentAssignementId], [EquipmentId], [EmployeeId], [RoomId], [DateBorrowed]) VALUES (6002, 4003, 3, 1003, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[EquipmentAssignement] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (1, N'117')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (2, N'120')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (4, N'124')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (5, N'125')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (6, N'221')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (1002, N'201')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (1003, N'205')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (1004, N'24')
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
/****** Object:  Index [IX_EquipmentAssignement_EmployeeId]    Script Date: 23/12/2023 3:21:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_EquipmentAssignement_EmployeeId] ON [dbo].[EquipmentAssignement]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EquipmentAssignement_EquipmentId]    Script Date: 23/12/2023 3:21:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_EquipmentAssignement_EquipmentId] ON [dbo].[EquipmentAssignement]
(
	[EquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EquipmentAssignement_RoomId]    Script Date: 23/12/2023 3:21:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_EquipmentAssignement_RoomId] ON [dbo].[EquipmentAssignement]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Equipment] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[EquipmentAssignement]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentAssignement_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentAssignement] CHECK CONSTRAINT [FK_EquipmentAssignement_Employee_EmployeeId]
GO
ALTER TABLE [dbo].[EquipmentAssignement]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentAssignement_Equipment_EquipmentId] FOREIGN KEY([EquipmentId])
REFERENCES [dbo].[Equipment] ([EquipmentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentAssignement] CHECK CONSTRAINT [FK_EquipmentAssignement_Equipment_EquipmentId]
GO
ALTER TABLE [dbo].[EquipmentAssignement]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentAssignement_Room_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentAssignement] CHECK CONSTRAINT [FK_EquipmentAssignement_Room_RoomId]
GO
USE [master]
GO
ALTER DATABASE [IRC-EFC] SET  READ_WRITE 
GO
