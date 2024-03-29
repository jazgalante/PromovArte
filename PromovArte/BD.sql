USE [master]
GO
/****** Object:  Database [PromovArte]    Script Date: 29/10/2019 09:04:56 ******/
CREATE DATABASE [PromovArte]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PromovArte', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PromovArte.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PromovArte_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PromovArte_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PromovArte] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PromovArte].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PromovArte] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PromovArte] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PromovArte] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PromovArte] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PromovArte] SET ARITHABORT OFF 
GO
ALTER DATABASE [PromovArte] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PromovArte] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PromovArte] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PromovArte] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PromovArte] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PromovArte] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PromovArte] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PromovArte] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PromovArte] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PromovArte] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PromovArte] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PromovArte] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PromovArte] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PromovArte] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PromovArte] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PromovArte] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PromovArte] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PromovArte] SET RECOVERY FULL 
GO
ALTER DATABASE [PromovArte] SET  MULTI_USER 
GO
ALTER DATABASE [PromovArte] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PromovArte] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PromovArte] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PromovArte] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PromovArte] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PromovArte', N'ON'
GO
ALTER DATABASE [PromovArte] SET QUERY_STORE = OFF
GO
USE [PromovArte]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PromovArte]
GO
/****** Object:  User [alumno]    Script Date: 29/10/2019 09:04:57 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Artistas]    Script Date: 29/10/2019 09:04:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artistas](
	[IdArtista] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 29/10/2019 09:04:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[IdEvento] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Artista] [int] NOT NULL,
	[Foto] [varchar](100) NOT NULL,
	[Destacado] [bit] NOT NULL,
	[Fecha] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEventos]    Script Date: 29/10/2019 09:04:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEventos](
	[IdTipoEvento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Artistas] ON 

INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña]) VALUES (1, N'Jazmin', N'Galante', N'JazGalante', N'12345')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña]) VALUES (2, N'Lucia', N'Pavlov', N'LuliPavlov', N'1234')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña]) VALUES (3, N'Nicole', N'Orencel', N'NikiOrencel', N'aa')
SET IDENTITY_INSERT [dbo].[Artistas] OFF
SET IDENTITY_INSERT [dbo].[Eventos] ON 

INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (1, 1, N'Recital de rock', N'Rolling Stones', 2, N'1.jpg', 1, CAST(N'2019-12-25' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (2, 3, N'Venta de esculturas', N'Esculturas', 1, N'2.jpg', 0, CAST(N'2020-05-30' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (3, 4, N'Exhibicion de pinturas', N'Pinturas', 2, N'3.jpg', 0, CAST(N'2020-02-04' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (4, 2, N'Obra de Sheakspeare ', N'Ser o no ser', 3, N'4.jpg', 0, CAST(N'2019-11-15' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (5, 5, N'Ballet', N'Cascanueces', 1, N'5.jpg', 0, CAST(N'2020-10-03' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (6, 6, N'Muestra juegos', N'ExpoInfo', 3, N'6.jpg', 0, CAST(N'2021-07-06' AS Date))
SET IDENTITY_INSERT [dbo].[Eventos] OFF
SET IDENTITY_INSERT [dbo].[TipoEventos] ON 

INSERT [dbo].[TipoEventos] ([IdTipoEvento], [Nombre]) VALUES (1, N'Recital')
INSERT [dbo].[TipoEventos] ([IdTipoEvento], [Nombre]) VALUES (2, N'Obra')
INSERT [dbo].[TipoEventos] ([IdTipoEvento], [Nombre]) VALUES (3, N'Venta')
INSERT [dbo].[TipoEventos] ([IdTipoEvento], [Nombre]) VALUES (4, N'Exhibicion')
INSERT [dbo].[TipoEventos] ([IdTipoEvento], [Nombre]) VALUES (5, N'Muestra Baile')
INSERT [dbo].[TipoEventos] ([IdTipoEvento], [Nombre]) VALUES (6, N'Otro')
SET IDENTITY_INSERT [dbo].[TipoEventos] OFF
USE [master]
GO
ALTER DATABASE [PromovArte] SET  READ_WRITE 
GO
