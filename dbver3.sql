USE [master]
GO
/****** Object:  Database [SchoolMgDb]    Script Date: 10/28/2024 2:53:25 PM ******/
CREATE DATABASE [SchoolMgDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolMgDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SchoolMgDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SchoolMgDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SchoolMgDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SchoolMgDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolMgDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolMgDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchoolMgDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchoolMgDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchoolMgDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchoolMgDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchoolMgDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchoolMgDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolMgDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolMgDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolMgDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchoolMgDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchoolMgDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolMgDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchoolMgDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolMgDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SchoolMgDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolMgDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolMgDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolMgDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolMgDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolMgDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchoolMgDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolMgDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SchoolMgDb] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolMgDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchoolMgDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolMgDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolMgDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SchoolMgDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SchoolMgDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SchoolMgDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [SchoolMgDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SchoolMgDb]
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTable](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [int] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ContactNo] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypeTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypeTable](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_UserTypeTable] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vAllUsers]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vAllUsers]
AS
SELECT        dbo.UserTable.UserID, dbo.UserTable.UserTypeID, dbo.UserTypeTable.TypeName, dbo.UserTable.FullName, dbo.UserTable.UserName, dbo.UserTable.ContactNo, dbo.UserTable.EmailAddress, dbo.UserTable.Address
FROM            dbo.UserTable INNER JOIN
                         dbo.UserTypeTable ON dbo.UserTable.UserTypeID = dbo.UserTypeTable.UserTypeID

GO
/****** Object:  Table [dbo].[AnnualTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnnualTable](
	[AnnualID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ProgrameID] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](400) NULL,
	[Fees] [float] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AnnualTable] PRIMARY KEY CLUSTERED 
(
	[AnnualID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttendanceTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttendanceTable](
	[AttendanceID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[AttendDate] [datetime] NOT NULL,
	[AttendTime] [time](7) NOT NULL,
 CONSTRAINT [PK_AttendanceTable] PRIMARY KEY CLUSTERED 
(
	[AttendanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTable](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ClassTable] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DesignationTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesignationTable](
	[DesignationID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DesignationTable] PRIMARY KEY CLUSTERED 
(
	[DesignationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamMarksTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamMarksTable](
	[MarksID] [int] IDENTITY(1,1) NOT NULL,
	[SessionProgrameSubjectSettingID] [int] NOT NULL,
	[ExamID] [int] NOT NULL,
	[ExamSettingID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[ObtainMarks] [int] NOT NULL,
 CONSTRAINT [PK_ExamMarksTable] PRIMARY KEY CLUSTERED 
(
	[MarksID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamSettingTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamSettingTable](
	[ExamSettingID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [nchar](150) NOT NULL,
	[SessionID] [int] NOT NULL,
	[ExamID] [int] NOT NULL,
	[ProgrameSessionID] [int] NOT NULL,
	[Description] [nvarchar](400) NOT NULL,
 CONSTRAINT [PK_ExamSettingTable] PRIMARY KEY CLUSTERED 
(
	[ExamSettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamTable](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Descrption] [nvarchar](200) NULL,
 CONSTRAINT [PK_ExamTable] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgrameSessionTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgrameSessionTable](
	[ProgrameSessionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[SessionID] [int] NOT NULL,
	[ProgrameID] [int] NOT NULL,
	[Details] [nvarchar](200) NOT NULL,
	[RegDate] [date] NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProgrameSessionTable] PRIMARY KEY CLUSTERED 
(
	[ProgrameSessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgrameTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgrameTable](
	[ProgrameID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[StartDate] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ProgrameTable] PRIMARY KEY CLUSTERED 
(
	[ProgrameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionProgrameSubjectSettingTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionProgrameSubjectSettingTable](
	[SessionProgrameSubjectSettingID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[SessionID] [int] NOT NULL,
	[ProgrameID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[Name] [nchar](150) NOT NULL,
	[RegDate] [date] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SessionProgrameSubjectSettingTable] PRIMARY KEY CLUSTERED 
(
	[SessionProgrameSubjectSettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionTable](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_SessionTable] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffAttendanceTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffAttendanceTable](
	[StaffAttendanceID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[AttendDate] [date] NOT NULL,
	[ComingTime] [time](7) NULL,
	[ClosingTime] [time](7) NULL,
 CONSTRAINT [PK_StaffAttendanceTable] PRIMARY KEY CLUSTERED 
(
	[StaffAttendanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffTable](
	[StaffID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[DesignationID] [int] NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[BasicSalary] [float] NOT NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Qualification] [nvarchar](500) NOT NULL,
	[Photo] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_StaffTable] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentPromotTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentPromotTable](
	[StudentPromotID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[ProgrameSessionID] [int] NOT NULL,
	[PromoteDate] [date] NOT NULL,
	[AnnualFee] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsSubmit] [bit] NULL,
 CONSTRAINT [PK_StudentPromotTable] PRIMARY KEY CLUSTERED 
(
	[StudentPromotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTable](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NOT NULL,
	[ProgrameID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[FatherName] [nvarchar](100) NOT NULL,
	[DateofBirth] [date] NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[ContactNo] [nvarchar](50) NOT NULL,
	[CNIC] [nvarchar](50) NOT NULL,
	[FNIC] [nvarchar](50) NOT NULL,
	[Photo] [nvarchar](max) NOT NULL,
	[IsEnrolled] [bit] NOT NULL,
	[ApplyDate] [date] NOT NULL,
	[IsShortList] [bit] NOT NULL,
	[IsApply] [bit] NOT NULL,
	[PreviousSchool] [nvarchar](500) NOT NULL,
	[PreviousPercentage] [float] NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_StudentTable] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectTable](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[RegDate] [date] NOT NULL,
	[Description] [nvarchar](400) NULL,
	[TotalMarks] [int] NOT NULL,
 CONSTRAINT [PK_SubjectTable] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubmissionFeeTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubmissionFeeTable](
	[SubmissionFeeID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[ProgrameID] [int] NOT NULL,
	[SubmissionDate] [date] NOT NULL,
	[FeesMonth] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_SubmissionFeeTable] PRIMARY KEY CLUSTERED 
(
	[SubmissionFeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTblTable]    Script Date: 10/28/2024 2:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTblTable](
	[TimeTableID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Day] [nvarchar](100) NOT NULL,
	[ClassID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TimeTblTable] PRIMARY KEY CLUSTERED 
(
	[TimeTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AnnualTable] ADD  CONSTRAINT [DF_AnnualTable_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ClassTable] ADD  CONSTRAINT [DF_ClassTable_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[DesignationTable] ADD  CONSTRAINT [DF_DesignationTable_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ExamMarksTable] ADD  CONSTRAINT [DF_ExamMarksTable_TotalMarks]  DEFAULT ((100)) FOR [TotalMarks]
GO
ALTER TABLE [dbo].[ProgrameTable] ADD  CONSTRAINT [DF_ProgrameTable_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable] ADD  CONSTRAINT [DF_SessionProgrameSubjectSettingTable_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[StaffTable] ADD  CONSTRAINT [DF_StaffTable_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[StudentPromotTable] ADD  CONSTRAINT [DF_StudentPromotTable_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[StudentPromotTable] ADD  CONSTRAINT [DF_StudentPromotTable_IsSubmit]  DEFAULT ((1)) FOR [IsSubmit]
GO
ALTER TABLE [dbo].[StudentTable] ADD  CONSTRAINT [DF_StudentTable_IsEnrolled]  DEFAULT ((0)) FOR [IsEnrolled]
GO
ALTER TABLE [dbo].[StudentTable] ADD  CONSTRAINT [DF_StudentTable_IsShortList]  DEFAULT ((0)) FOR [IsShortList]
GO
ALTER TABLE [dbo].[StudentTable] ADD  CONSTRAINT [DF_StudentTable_IsApply]  DEFAULT ((0)) FOR [IsApply]
GO
ALTER TABLE [dbo].[StudentTable] ADD  CONSTRAINT [DF_StudentTable_PreviousPercentage]  DEFAULT ((0)) FOR [PreviousPercentage]
GO
ALTER TABLE [dbo].[SubjectTable] ADD  CONSTRAINT [DF_SubjectTable_TotalMarks]  DEFAULT ((100)) FOR [TotalMarks]
GO
ALTER TABLE [dbo].[TimeTblTable] ADD  CONSTRAINT [DF_TimeTblTable_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[AnnualTable]  WITH CHECK ADD  CONSTRAINT [FK_AnnualTable_ProgrameTable] FOREIGN KEY([ProgrameID])
REFERENCES [dbo].[ProgrameTable] ([ProgrameID])
GO
ALTER TABLE [dbo].[AnnualTable] CHECK CONSTRAINT [FK_AnnualTable_ProgrameTable]
GO
ALTER TABLE [dbo].[AnnualTable]  WITH CHECK ADD  CONSTRAINT [FK_AnnualTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[AnnualTable] CHECK CONSTRAINT [FK_AnnualTable_UserTable]
GO
ALTER TABLE [dbo].[AttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_AttendanceTable_ClassTable] FOREIGN KEY([ClassID])
REFERENCES [dbo].[ClassTable] ([ClassID])
GO
ALTER TABLE [dbo].[AttendanceTable] CHECK CONSTRAINT [FK_AttendanceTable_ClassTable]
GO
ALTER TABLE [dbo].[AttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_AttendanceTable_StudentTable] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentTable] ([StudentID])
GO
ALTER TABLE [dbo].[AttendanceTable] CHECK CONSTRAINT [FK_AttendanceTable_StudentTable]
GO
ALTER TABLE [dbo].[DesignationTable]  WITH CHECK ADD  CONSTRAINT [FK_DesignationTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[DesignationTable] CHECK CONSTRAINT [FK_DesignationTable_UserTable]
GO
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_ExamSettingTable] FOREIGN KEY([ExamSettingID])
REFERENCES [dbo].[ExamSettingTable] ([ExamSettingID])
GO
ALTER TABLE [dbo].[ExamMarksTable] CHECK CONSTRAINT [FK_ExamMarksTable_ExamSettingTable]
GO
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_ExamTable] FOREIGN KEY([ExamID])
REFERENCES [dbo].[ExamTable] ([ExamID])
GO
ALTER TABLE [dbo].[ExamMarksTable] CHECK CONSTRAINT [FK_ExamMarksTable_ExamTable]
GO
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_SessionProgrameSubjectSettingTable] FOREIGN KEY([SessionProgrameSubjectSettingID])
REFERENCES [dbo].[SessionProgrameSubjectSettingTable] ([SessionProgrameSubjectSettingID])
GO
ALTER TABLE [dbo].[ExamMarksTable] CHECK CONSTRAINT [FK_ExamMarksTable_SessionProgrameSubjectSettingTable]
GO
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_StudentTable] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentTable] ([StudentID])
GO
ALTER TABLE [dbo].[ExamMarksTable] CHECK CONSTRAINT [FK_ExamMarksTable_StudentTable]
GO
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_SubjectTable] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[SubjectTable] ([SubjectID])
GO
ALTER TABLE [dbo].[ExamMarksTable] CHECK CONSTRAINT [FK_ExamMarksTable_SubjectTable]
GO
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[ExamMarksTable] CHECK CONSTRAINT [FK_ExamMarksTable_UserTable]
GO
ALTER TABLE [dbo].[ExamSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamSettingTable_ExamTable] FOREIGN KEY([ExamID])
REFERENCES [dbo].[ExamTable] ([ExamID])
GO
ALTER TABLE [dbo].[ExamSettingTable] CHECK CONSTRAINT [FK_ExamSettingTable_ExamTable]
GO
ALTER TABLE [dbo].[ExamSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamSettingTable_ProgrameSessionTable] FOREIGN KEY([ProgrameSessionID])
REFERENCES [dbo].[ProgrameSessionTable] ([ProgrameSessionID])
GO
ALTER TABLE [dbo].[ExamSettingTable] CHECK CONSTRAINT [FK_ExamSettingTable_ProgrameSessionTable]
GO
ALTER TABLE [dbo].[ExamSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamSettingTable_SessionTable] FOREIGN KEY([SessionID])
REFERENCES [dbo].[SessionTable] ([SessionID])
GO
ALTER TABLE [dbo].[ExamSettingTable] CHECK CONSTRAINT [FK_ExamSettingTable_SessionTable]
GO
ALTER TABLE [dbo].[ExamSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamSettingTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[ExamSettingTable] CHECK CONSTRAINT [FK_ExamSettingTable_UserTable]
GO
ALTER TABLE [dbo].[ExamTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[ExamTable] CHECK CONSTRAINT [FK_ExamTable_UserTable]
GO
ALTER TABLE [dbo].[ProgrameSessionTable]  WITH CHECK ADD  CONSTRAINT [FK_ProgrameSessionTable_ProgrameTable] FOREIGN KEY([ProgrameID])
REFERENCES [dbo].[ProgrameTable] ([ProgrameID])
GO
ALTER TABLE [dbo].[ProgrameSessionTable] CHECK CONSTRAINT [FK_ProgrameSessionTable_ProgrameTable]
GO
ALTER TABLE [dbo].[ProgrameSessionTable]  WITH CHECK ADD  CONSTRAINT [FK_ProgrameSessionTable_SessionTable] FOREIGN KEY([SessionID])
REFERENCES [dbo].[SessionTable] ([SessionID])
GO
ALTER TABLE [dbo].[ProgrameSessionTable] CHECK CONSTRAINT [FK_ProgrameSessionTable_SessionTable]
GO
ALTER TABLE [dbo].[ProgrameSessionTable]  WITH CHECK ADD  CONSTRAINT [FK_ProgrameSessionTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[ProgrameSessionTable] CHECK CONSTRAINT [FK_ProgrameSessionTable_UserTable]
GO
ALTER TABLE [dbo].[ProgrameTable]  WITH CHECK ADD  CONSTRAINT [FK_ProgrameTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[ProgrameTable] CHECK CONSTRAINT [FK_ProgrameTable_UserTable]
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_SessionProgrameSubjectSettingTable_ClassTable] FOREIGN KEY([ClassID])
REFERENCES [dbo].[ClassTable] ([ClassID])
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable] CHECK CONSTRAINT [FK_SessionProgrameSubjectSettingTable_ClassTable]
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_SessionProgrameSubjectSettingTable_ProgrameTable] FOREIGN KEY([ProgrameID])
REFERENCES [dbo].[ProgrameTable] ([ProgrameID])
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable] CHECK CONSTRAINT [FK_SessionProgrameSubjectSettingTable_ProgrameTable]
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_SessionProgrameSubjectSettingTable_SessionTable] FOREIGN KEY([SessionID])
REFERENCES [dbo].[SessionTable] ([SessionID])
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable] CHECK CONSTRAINT [FK_SessionProgrameSubjectSettingTable_SessionTable]
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_SessionProgrameSubjectSettingTable_SubjectTable] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[SubjectTable] ([SubjectID])
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable] CHECK CONSTRAINT [FK_SessionProgrameSubjectSettingTable_SubjectTable]
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable]  WITH CHECK ADD  CONSTRAINT [FK_SessionProgrameSubjectSettingTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[SessionProgrameSubjectSettingTable] CHECK CONSTRAINT [FK_SessionProgrameSubjectSettingTable_UserTable]
GO
ALTER TABLE [dbo].[SessionTable]  WITH CHECK ADD  CONSTRAINT [FK_SessionTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[SessionTable] CHECK CONSTRAINT [FK_SessionTable_UserTable]
GO
ALTER TABLE [dbo].[StaffAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_StaffAttendanceTable_StaffTable] FOREIGN KEY([StaffID])
REFERENCES [dbo].[StaffTable] ([StaffID])
GO
ALTER TABLE [dbo].[StaffAttendanceTable] CHECK CONSTRAINT [FK_StaffAttendanceTable_StaffTable]
GO
ALTER TABLE [dbo].[StaffTable]  WITH CHECK ADD  CONSTRAINT [FK_StaffTable_DesignationTable] FOREIGN KEY([DesignationID])
REFERENCES [dbo].[DesignationTable] ([DesignationID])
GO
ALTER TABLE [dbo].[StaffTable] CHECK CONSTRAINT [FK_StaffTable_DesignationTable]
GO
ALTER TABLE [dbo].[StaffTable]  WITH CHECK ADD  CONSTRAINT [FK_StaffTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[StaffTable] CHECK CONSTRAINT [FK_StaffTable_UserTable]
GO
ALTER TABLE [dbo].[StudentPromotTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentPromotTable_ClassTable] FOREIGN KEY([ClassID])
REFERENCES [dbo].[ClassTable] ([ClassID])
GO
ALTER TABLE [dbo].[StudentPromotTable] CHECK CONSTRAINT [FK_StudentPromotTable_ClassTable]
GO
ALTER TABLE [dbo].[StudentPromotTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentPromotTable_ProgrameSessionTable] FOREIGN KEY([ProgrameSessionID])
REFERENCES [dbo].[ProgrameSessionTable] ([ProgrameSessionID])
GO
ALTER TABLE [dbo].[StudentPromotTable] CHECK CONSTRAINT [FK_StudentPromotTable_ProgrameSessionTable]
GO
ALTER TABLE [dbo].[StudentPromotTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentPromotTable_StudentTable] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentTable] ([StudentID])
GO
ALTER TABLE [dbo].[StudentPromotTable] CHECK CONSTRAINT [FK_StudentPromotTable_StudentTable]
GO
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_ProgrameTable] FOREIGN KEY([ProgrameID])
REFERENCES [dbo].[ProgrameTable] ([ProgrameID])
GO
ALTER TABLE [dbo].[StudentTable] CHECK CONSTRAINT [FK_StudentTable_ProgrameTable]
GO
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_SessionTable] FOREIGN KEY([SessionID])
REFERENCES [dbo].[SessionTable] ([SessionID])
GO
ALTER TABLE [dbo].[StudentTable] CHECK CONSTRAINT [FK_StudentTable_SessionTable]
GO
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[StudentTable] CHECK CONSTRAINT [FK_StudentTable_UserTable]
GO
ALTER TABLE [dbo].[SubjectTable]  WITH CHECK ADD  CONSTRAINT [FK_SubjectTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[SubjectTable] CHECK CONSTRAINT [FK_SubjectTable_UserTable]
GO
ALTER TABLE [dbo].[SubmissionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionFeeTable_ClassTable] FOREIGN KEY([ClassID])
REFERENCES [dbo].[ClassTable] ([ClassID])
GO
ALTER TABLE [dbo].[SubmissionFeeTable] CHECK CONSTRAINT [FK_SubmissionFeeTable_ClassTable]
GO
ALTER TABLE [dbo].[SubmissionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionFeeTable_ProgrameTable] FOREIGN KEY([ProgrameID])
REFERENCES [dbo].[ProgrameTable] ([ProgrameID])
GO
ALTER TABLE [dbo].[SubmissionFeeTable] CHECK CONSTRAINT [FK_SubmissionFeeTable_ProgrameTable]
GO
ALTER TABLE [dbo].[SubmissionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionFeeTable_StudentTable] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentTable] ([StudentID])
GO
ALTER TABLE [dbo].[SubmissionFeeTable] CHECK CONSTRAINT [FK_SubmissionFeeTable_StudentTable]
GO
ALTER TABLE [dbo].[SubmissionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionFeeTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[SubmissionFeeTable] CHECK CONSTRAINT [FK_SubmissionFeeTable_UserTable]
GO
ALTER TABLE [dbo].[TimeTblTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTblTable_ClassTable] FOREIGN KEY([ClassID])
REFERENCES [dbo].[ClassTable] ([ClassID])
GO
ALTER TABLE [dbo].[TimeTblTable] CHECK CONSTRAINT [FK_TimeTblTable_ClassTable]
GO
ALTER TABLE [dbo].[TimeTblTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTblTable_StaffTable] FOREIGN KEY([StaffID])
REFERENCES [dbo].[StaffTable] ([StaffID])
GO
ALTER TABLE [dbo].[TimeTblTable] CHECK CONSTRAINT [FK_TimeTblTable_StaffTable]
GO
ALTER TABLE [dbo].[TimeTblTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTblTable_SubjectTable] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[SubjectTable] ([SubjectID])
GO
ALTER TABLE [dbo].[TimeTblTable] CHECK CONSTRAINT [FK_TimeTblTable_SubjectTable]
GO
ALTER TABLE [dbo].[TimeTblTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTblTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[TimeTblTable] CHECK CONSTRAINT [FK_TimeTblTable_UserTable]
GO
ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_UserTypeTable] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserTypeTable] ([UserTypeID])
GO
ALTER TABLE [dbo].[UserTable] CHECK CONSTRAINT [FK_UserTable_UserTypeTable]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UserTable"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "UserTypeTable"
            Begin Extent = 
               Top = 9
               Left = 401
               Bottom = 122
               Right = 571
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vAllUsers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vAllUsers'
GO
USE [master]
GO
ALTER DATABASE [SchoolMgDb] SET  READ_WRITE 
GO
