USE [master]
GO
/****** Object:  Database [musicstore]    Script Date: 04/10/2017 12:44:32 ******/
CREATE DATABASE [musicstore] ON  PRIMARY 
( NAME = N'musicstore', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\musicstore.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'musicstore_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\musicstore_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [musicstore] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [musicstore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [musicstore] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [musicstore] SET ANSI_NULLS OFF
GO
ALTER DATABASE [musicstore] SET ANSI_PADDING OFF
GO
ALTER DATABASE [musicstore] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [musicstore] SET ARITHABORT OFF
GO
ALTER DATABASE [musicstore] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [musicstore] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [musicstore] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [musicstore] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [musicstore] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [musicstore] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [musicstore] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [musicstore] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [musicstore] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [musicstore] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [musicstore] SET  ENABLE_BROKER
GO
ALTER DATABASE [musicstore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [musicstore] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [musicstore] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [musicstore] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [musicstore] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [musicstore] SET READ_COMMITTED_SNAPSHOT ON
GO
ALTER DATABASE [musicstore] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [musicstore] SET  READ_WRITE
GO
ALTER DATABASE [musicstore] SET RECOVERY FULL
GO
ALTER DATABASE [musicstore] SET  MULTI_USER
GO
ALTER DATABASE [musicstore] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [musicstore] SET DB_CHAINING OFF
GO
USE [musicstore]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 04/10/2017 12:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 04/10/2017 12:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 04/10/2017 12:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[OrderDate] [datetime] NOT NULL,
	[FirstName] [nvarchar](160) NOT NULL,
	[LastName] [nvarchar](160) NOT NULL,
	[Address] [nvarchar](70) NOT NULL,
	[City] [nvarchar](40) NOT NULL,
	[State] [nvarchar](40) NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[Country] [nvarchar](40) NOT NULL,
	[Phone] [nvarchar](24) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 04/10/2017 12:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.Genre] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 04/10/2017 12:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Artist] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 04/10/2017 12:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[GenreId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Title] [nvarchar](160) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[AlbumArtUrl] [nvarchar](1024) NULL,
 CONSTRAINT [PK_dbo.Album] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ArtistId] ON [dbo].[Album] 
(
	[ArtistId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_GenreId] ON [dbo].[Album] 
(
	[GenreId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_dbo.Album_dbo.Artist_ArtistId]    Script Date: 04/10/2017 12:44:34 ******/
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Album_dbo.Artist_ArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([ArtistId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_dbo.Album_dbo.Artist_ArtistId]
GO
/****** Object:  ForeignKey [FK_dbo.Album_dbo.Genre_GenreId]    Script Date: 04/10/2017 12:44:34 ******/
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Album_dbo.Genre_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([GenreId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_dbo.Album_dbo.Genre_GenreId]
GO
