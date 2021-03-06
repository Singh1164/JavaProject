USE [master]
GO
/****** Object:  Database [StudentCourseDB]    Script Date: 4/29/2019 5:51:33 PM ******/
CREATE DATABASE [StudentCourseDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentCourseDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StudentCourseDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentCourseDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StudentCourseDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentCourseDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentCourseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentCourseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentCourseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentCourseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentCourseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentCourseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentCourseDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentCourseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentCourseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentCourseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentCourseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentCourseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentCourseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentCourseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentCourseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentCourseDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentCourseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentCourseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentCourseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentCourseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentCourseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentCourseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentCourseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentCourseDB] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentCourseDB] SET  MULTI_USER 
GO
ALTER DATABASE [StudentCourseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentCourseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentCourseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentCourseDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentCourseDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentCourseDB] SET QUERY_STORE = OFF
GO
USE [StudentCourseDB]
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
USE [StudentCourseDB]
GO
/****** Object:  Table [dbo].[CourseAssignment]    Script Date: 4/29/2019 5:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignment](
	[StudentID] [int] NOT NULL,
	[CourseNumber] [nvarchar](50) NOT NULL,
	[AssingedDate] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 4/29/2019 5:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseNumber] [nvarchar](50) NOT NULL,
	[CourseTitle] [varchar](50) NOT NULL,
	[Duration] [int] NOT NULL,
	[Prerequisite] [nvarchar](50) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students1]    Script Date: 4/29/2019 5:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students1](
	[StudentID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[HomePhone] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Students1] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentUsers]    Script Date: 4/29/2019 5:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentUsers](
	[UserID] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration], [Prerequisite]) VALUES (N'COMP101', N'Structured Programming', 90, N'')
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration], [Prerequisite]) VALUES (N'COMP102', N'Introduction to C# 2017', 75, N'COMP101')
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration], [Prerequisite]) VALUES (N'COMP103', N'Advanced Programming in C# 2017', 75, N'COMP102')
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration], [Prerequisite]) VALUES (N'COMP104', N'Web Programming 1', 90, NULL)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration], [Prerequisite]) VALUES (N'COMP105', N'Web Programming 2', 90, N'COMP104')
INSERT [dbo].[Students1] ([StudentID], [FirstName], [LastName], [HomePhone], [Email]) VALUES (11111, N'Mary', N'Brown', N'5141111111', N'mary@yahoo.com')
INSERT [dbo].[Students1] ([StudentID], [FirstName], [LastName], [HomePhone], [Email]) VALUES (22222, N'Wei', N'Huang', N'5142222222', N'wei@gmail.com')
INSERT [dbo].[Students1] ([StudentID], [FirstName], [LastName], [HomePhone], [Email]) VALUES (33333, N'MIchael', N'Fretaig', N'5143333333', N'michael@hotmail.com')
INSERT [dbo].[Students1] ([StudentID], [FirstName], [LastName], [HomePhone], [Email]) VALUES (44444, N'Daniel', N'Rother', N'5145555555', N'daniel@yahoo.com')
INSERT [dbo].[StudentUsers] ([UserID], [Password]) VALUES (11111, N'Mary_1234')
INSERT [dbo].[StudentUsers] ([UserID], [Password]) VALUES (22222, N'Wei_1235')
INSERT [dbo].[StudentUsers] ([UserID], [Password]) VALUES (33333, N'Michael_1236')
INSERT [dbo].[StudentUsers] ([UserID], [Password]) VALUES (44444, N'Daniel_1237')
USE [master]
GO
ALTER DATABASE [StudentCourseDB] SET  READ_WRITE 
GO
