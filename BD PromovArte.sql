USE [master]
GO
/****** Object:  Database [PromovArte]    Script Date: 29/11/2019 10:47:45 ******/
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
/****** Object:  User [alumno]    Script Date: 29/11/2019 10:47:45 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Artistas]    Script Date: 29/11/2019 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artistas](
	[IdArtista] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Destacado] [bit] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Foto] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 29/11/2019 10:47:46 ******/
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
/****** Object:  Table [dbo].[TipoEventos]    Script Date: 29/11/2019 10:47:46 ******/
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

INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (1, N'Rolling', N'Stones', N'rollingstones', N'a', 0, N'Banda británica de rock originaria de Londres', N'rolling perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (2, N'Miguel', N'Angelo', N'michaelangelo', N'a', 0, N'Escultor cristiano', N'angelo perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (3, N'Jose', N'Shakespeare', N'jeikspirr', N'a', 1, N'Escritor de obras teatrales', N'shake perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (4, N'Ivana', N'Ivanovna', N'ivana', N'a', 0, N'Bailarina clasica rusa', N'ivana perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (5, N'Mr.', N'Binker', N'binker.kpo', N'a', 0, N'Programador y coordinador de la ExpoInfo', N'binker perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (6, N'Milo', N'Lockett', N'milomilo', N'a', 0, N'Pintor y escultor contemporaneo', N'milo perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (7, N'Mariana', N'Grande', N'marig', N'a', 0, N'Cantante independiente', N'mariana perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (8, N'Hombre', N'Griego', N'elgriego', N'a', 0, N'Escultor de piezas de la Antigua Grecia', N'griego perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (9, N'Hamlet', N'Hamlet', N'hamham', N'a', 0, N'Actor profesional', N'hamlet perfil.jpg')
INSERT [dbo].[Artistas] ([IdArtista], [Nombre], [Apellido], [NombreUsuario], [Contraseña], [Destacado], [Descripcion], [Foto]) VALUES (10, N'Bronislava	', N'Dostoyevsky', N'broni', N'a', 0, N'Bailarina clasica, tambien rusa', N'bronislava perfil.jpg')
SET IDENTITY_INSERT [dbo].[Artistas] OFF
SET IDENTITY_INSERT [dbo].[Eventos] ON 

INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (1, 1, N'Recital de rock', N'Los Rolling en Argentina', 1, N'rolling evento.jpg', 1, CAST(N'2020-05-30' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (2, 2, N'Shakespeare dirige "Hamlet"', N'Ser O No Ser', 3, N'hamlet evento.jpg', 1, CAST(N'2020-02-04' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (3, 2, N'Hamlet actua en obra de "Shakespearre"', N'Hamlet', 9, N'jake evento.jpg', 0, CAST(N'2019-11-15' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (4, 3, N'Se venden sabanas de Arredo', N'Arredo y Milo', 6, N'sabanas evento.jpg', 0, CAST(N'2020-10-03' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (5, 3, N'Venta de bases de datos confidenciales del gobierno', N'Informatica en ORT', 5, N'database evento.jpg', 0, CAST(N'2021-07-06' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (6, 4, N'Miguelangel nos muestra lo que es una piedra', N'Las esculturas del vaticano', 2, N'esculturas evento.jpg', 0, CAST(N'2020-04-08' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (7, 4, N'Vida y obra de Milo Lockett', N'6', 1, N'vida y obra evento .jpg', 0, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (8, 5, N'El clasico ruso organizado por rusos', N'El Cascanueces', 10, N'cascanueces evento.jpg', 0, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (9, 6, N'Exposicion de los proyectos de info', N'Expoinfo', 5, N'expoinfo evento.jpg', 0, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (10, 6, N'Stand up de la rusa que no contrataron para el cascanueces', N'Ivanactuar y noactuo', 4, N'standup evento.jpg', 1, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[Eventos] ([IdEvento], [Tipo], [Descripcion], [Titulo], [Artista], [Foto], [Destacado], [Fecha]) VALUES (11, 1, N'El show de Ariana pero en castellano', N'Edulcorante', 7, N'edulcorante evento.jpg', 0, CAST(N'2020-08-10' AS Date))
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
