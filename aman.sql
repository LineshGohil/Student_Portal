USE [master]
GO
/****** Object:  Database [StudentPortal]    Script Date: 02-08-2017 20:20:48 ******/
CREATE DATABASE [StudentPortal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentPortal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StudentPortal.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudentPortal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StudentPortal_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudentPortal] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentPortal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentPortal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentPortal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentPortal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentPortal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentPortal] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentPortal] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentPortal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentPortal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentPortal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentPortal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentPortal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentPortal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentPortal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentPortal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentPortal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentPortal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentPortal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentPortal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentPortal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentPortal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentPortal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentPortal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentPortal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentPortal] SET  MULTI_USER 
GO
ALTER DATABASE [StudentPortal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentPortal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentPortal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentPortal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StudentPortal] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StudentPortal]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 02-08-2017 20:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[StudId] [int] NOT NULL,
	[TenthMarks] [money] NULL,
	[TwelthMarks] [money] NULL,
	[TenthLink] [nvarchar](max) NULL,
	[TwelthLink] [nvarchar](max) NULL,
	[PolytechnicMarks] [money] NULL,
	[PolytechnicLink] [nvarchar](max) NULL,
	[BEPercentage] [money] NULL,
	[FirstSemLink] [nvarchar](max) NULL,
	[SecondSemLink] [nvarchar](max) NULL,
	[ThirdSemLink] [nvarchar](max) NULL,
	[ForthSemLink] [nvarchar](max) NULL,
	[FifthSemLinkk] [nvarchar](max) NULL,
	[SixthSemLink] [nvarchar](max) NULL,
	[SeventhSemLink] [nvarchar](max) NULL,
	[EigthSemLink] [nvarchar](max) NULL,
	[EID] [int] IDENTITY(1,1) NOT NULL,
	[CurrentBacklog] [int] NULL,
	[TotalBacklog] [int] NULL,
 CONSTRAINT [E_ID] PRIMARY KEY CLUSTERED 
(
	[EID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Intership]    Script Date: 02-08-2017 20:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intership](
	[StudId] [int] NOT NULL,
	[Profilee] [nvarchar](50) NULL,
	[Technology] [nvarchar](50) NULL,
	[Organization] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[ProjectLink] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
	[IID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [I_ID] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notices]    Script Date: 02-08-2017 20:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notices](
	[NID] [int] IDENTITY(1,1) NOT NULL,
	[TID] [int] NULL,
	[SubOfNotice] [varchar](50) NULL,
	[Detail] [varchar](500) NULL,
	[PostingDate] [date] NULL,
	[Category] [varchar](50) NULL,
 CONSTRAINT [N_ID] PRIMARY KEY CLUSTERED 
(
	[NID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 02-08-2017 20:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Branch] [nvarchar](50) NOT NULL,
	[Sem] [nvarchar](2) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Passward] [nvarchar](25) NOT NULL,
	[RollNo] [nvarchar](12) NOT NULL,
 CONSTRAINT [Stud_ID] PRIMARY KEY CLUSTERED 
(
	[StudId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 02-08-2017 20:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeachID] [int] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Passward] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Branch] [nvarchar](50) NULL,
 CONSTRAINT [Teach_ID] PRIMARY KEY CLUSTERED 
(
	[TeachID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Training]    Script Date: 02-08-2017 20:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Training](
	[StudId] [int] NOT NULL,
	[Technology] [nvarchar](50) NULL,
	[Organization] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[TypeOfTraining] [nvarchar](20) NULL,
	[ProjectLink] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
	[TID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [T_ID] PRIMARY KEY CLUSTERED 
(
	[TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Workshop]    Script Date: 02-08-2017 20:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workshop](
	[StudId] [int] NOT NULL,
	[Technology] [nvarchar](50) NULL,
	[Organizer] [nvarchar](50) NULL,
	[NoOfDays] [int] NULL,
	[Location] [nvarchar](50) NULL,
	[DateOfWorkshop] [date] NULL,
	[Link] [nvarchar](max) NULL,
	[Semester] [int] NULL,
	[WID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [W_ID] PRIMARY KEY CLUSTERED 
(
	[WID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Education] ON 

GO
INSERT [dbo].[Education] ([StudId], [TenthMarks], [TwelthMarks], [TenthLink], [TwelthLink], [PolytechnicMarks], [PolytechnicLink], [BEPercentage], [FirstSemLink], [SecondSemLink], [ThirdSemLink], [ForthSemLink], [FifthSemLinkk], [SixthSemLink], [SeventhSemLink], [EigthSemLink], [EID], [CurrentBacklog], [TotalBacklog]) VALUES (1, 1.0000, 3.0000, N'2', N'4', 5.0000, N'6', 7.0000, N'8', N'9', N'10', N'11', N'12', N'13', N'14', N'15', 1, NULL, NULL)
GO
INSERT [dbo].[Education] ([StudId], [TenthMarks], [TwelthMarks], [TenthLink], [TwelthLink], [PolytechnicMarks], [PolytechnicLink], [BEPercentage], [FirstSemLink], [SecondSemLink], [ThirdSemLink], [ForthSemLink], [FifthSemLinkk], [SixthSemLink], [SeventhSemLink], [EigthSemLink], [EID], [CurrentBacklog], [TotalBacklog]) VALUES (1, 10.0000, 20.0000, N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', NULL, N'https://drive.google.com/uc?export=download&id=undefined', 70.0000, N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', N'https://drive.google.com/uc?export=download&id=1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc', N'https://drive.google.com/uc?export=download&id=undefined', 2, NULL, NULL)
GO
INSERT [dbo].[Education] ([StudId], [TenthMarks], [TwelthMarks], [TenthLink], [TwelthLink], [PolytechnicMarks], [PolytechnicLink], [BEPercentage], [FirstSemLink], [SecondSemLink], [ThirdSemLink], [ForthSemLink], [FifthSemLinkk], [SixthSemLink], [SeventhSemLink], [EigthSemLink], [EID], [CurrentBacklog], [TotalBacklog]) VALUES (1, 10.0000, NULL, N'https://drive.google.com/uc?export=download&id=0B-botfOvx2V1VkRGcTJ3Y3FBZnc', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'https://drive.google.com/uc?export=download&id=undefined', 3, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Education] OFF
GO
SET IDENTITY_INSERT [dbo].[Intership] ON 

GO
INSERT [dbo].[Intership] ([StudId], [Profilee], [Technology], [Organization], [Location], [StartDate], [EndDate], [ProjectLink], [Link], [IID]) VALUES (1, N'lewmfenfenienieune', N'fesfsfsef', N'dfsgdgdrgdrgrdgr', N'dgdgsdtgdgtergrte', CAST(N'2017-10-11' AS Date), CAST(N'2017-11-11' AS Date), N'rryryrryrtytyfffsettrysry', N'srysrrurtbtesbte4bytuyse', 1)
GO
INSERT [dbo].[Intership] ([StudId], [Profilee], [Technology], [Organization], [Location], [StartDate], [EndDate], [ProjectLink], [Link], [IID]) VALUES (1, N'nithneihneigneign', N'nkjrrngkrerngiekngi', N'nirknerhnirengeognow', N'1gneigneirneineinein', CAST(N'2017-01-02' AS Date), CAST(N'2017-01-11' AS Date), N'efewsvks0jfwsnosnwono', N'nvidsnvinvisnsnsnvosnovn', 2)
GO
SET IDENTITY_INSERT [dbo].[Intership] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

GO
INSERT [dbo].[Student] ([StudId], [Name], [Branch], [Sem], [Email], [Passward], [RollNo]) VALUES (1, N'Linesh', N'CSE', N'7', N'a@gmail.com', N'abc@122', N'3332214025')
GO
INSERT [dbo].[Student] ([StudId], [Name], [Branch], [Sem], [Email], [Passward], [RollNo]) VALUES (2, N'Rsihabh', N'CSE', N'7', N'b@gmail.com', N'abc@122', N'3332214025')
GO
INSERT [dbo].[Student] ([StudId], [Name], [Branch], [Sem], [Email], [Passward], [RollNo]) VALUES (3, N'Aman', N'CSE', N'7', N'c@gmail.com', N'abc@122', N'3332214004')
GO
INSERT [dbo].[Student] ([StudId], [Name], [Branch], [Sem], [Email], [Passward], [RollNo]) VALUES (5, N'Shubham', N'CSE', N'7', N'd@gmail.com', N'abc@122', N'3332214046')
GO
INSERT [dbo].[Student] ([StudId], [Name], [Branch], [Sem], [Email], [Passward], [RollNo]) VALUES (6, N'Ayushi', N'CSE', N'7', N'x@gmail.com', N'abc@122', N'332214014')
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[Teacher] ([TeachID], [Email], [Passward], [Name], [Branch]) VALUES (1, N'lineshgohil@gmail.com', N'123456789', N'Aman', N'CSE')
GO
SET IDENTITY_INSERT [dbo].[Training] ON 

GO
INSERT [dbo].[Training] ([StudId], [Technology], [Organization], [Location], [StartDate], [EndDate], [TypeOfTraining], [ProjectLink], [Link], [TID]) VALUES (1, N'fesfsfsef', N'dfsgdgdrgdrgrdgr', N'dgdgsdtgdgtergrte', CAST(N'2017-10-11' AS Date), CAST(N'2017-11-11' AS Date), N'Mid Sem Training', N'rryryrryrtytyfffsettrysry', N'srysrrurtbtesbte4bytuyse', 1)
GO
SET IDENTITY_INSERT [dbo].[Training] OFF
GO
SET IDENTITY_INSERT [dbo].[Workshop] ON 

GO
INSERT [dbo].[Workshop] ([StudId], [Technology], [Organizer], [NoOfDays], [Location], [DateOfWorkshop], [Link], [Semester], [WID]) VALUES (1, N'Java', N'Effcon', 5, N'Raipur', CAST(N'2016-02-11' AS Date), N'https://docs.google.com/document/d/1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc/edit?usp=sharing', 5, 1)
GO
INSERT [dbo].[Workshop] ([StudId], [Technology], [Organizer], [NoOfDays], [Location], [DateOfWorkshop], [Link], [Semester], [WID]) VALUES (1, N'Big Data', N'Innolat', 3, N'Raipur', NULL, N'https://docs.google.com/document/d/1Dfpj65elwUs4Xla2tlEfs2ZbAdHQgVWe0FuU02I15qc/edit?usp=sharing', 6, 2)
GO
SET IDENTITY_INSERT [dbo].[Workshop] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Email_Stud]    Script Date: 02-08-2017 20:20:48 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [Email_Stud] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD  CONSTRAINT [fk_Education_Student_StudId] FOREIGN KEY([StudId])
REFERENCES [dbo].[Student] ([StudId])
GO
ALTER TABLE [dbo].[Education] CHECK CONSTRAINT [fk_Education_Student_StudId]
GO
ALTER TABLE [dbo].[Intership]  WITH CHECK ADD  CONSTRAINT [fk_Intership_Student_StudId] FOREIGN KEY([StudId])
REFERENCES [dbo].[Student] ([StudId])
GO
ALTER TABLE [dbo].[Intership] CHECK CONSTRAINT [fk_Intership_Student_StudId]
GO
ALTER TABLE [dbo].[Notices]  WITH CHECK ADD  CONSTRAINT [fk_Notices_Teacher_TeachID] FOREIGN KEY([TID])
REFERENCES [dbo].[Teacher] ([TeachID])
GO
ALTER TABLE [dbo].[Notices] CHECK CONSTRAINT [fk_Notices_Teacher_TeachID]
GO
ALTER TABLE [dbo].[Training]  WITH CHECK ADD  CONSTRAINT [fk_Training_Student_StudId] FOREIGN KEY([StudId])
REFERENCES [dbo].[Student] ([StudId])
GO
ALTER TABLE [dbo].[Training] CHECK CONSTRAINT [fk_Training_Student_StudId]
GO
ALTER TABLE [dbo].[Workshop]  WITH CHECK ADD  CONSTRAINT [fk_Workshop_Student_StudId] FOREIGN KEY([StudId])
REFERENCES [dbo].[Student] ([StudId])
GO
ALTER TABLE [dbo].[Workshop] CHECK CONSTRAINT [fk_Workshop_Student_StudId]
GO
USE [master]
GO
ALTER DATABASE [StudentPortal] SET  READ_WRITE 
GO
