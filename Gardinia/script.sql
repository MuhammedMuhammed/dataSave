USE [master]
GO
/****** Object:  Database [BUILDINGProjectsTables]    Script Date: 4/10/2019 9:59:17 PM ******/
CREATE DATABASE [BUILDINGProjectsTables]
GO
ALTER DATABASE [BUILDINGProjectsTables] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BUILDINGProjectsTables].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BUILDINGProjectsTables] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET ARITHABORT OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET RECOVERY FULL 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET  MULTI_USER 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BUILDINGProjectsTables] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BUILDINGProjectsTables] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BUILDINGProjectsTables', N'ON'
GO
ALTER DATABASE [BUILDINGProjectsTables] SET QUERY_STORE = OFF
GO
USE [BUILDINGProjectsTables]
GO
/****** Object:  Table [dbo].[AsBuiltTable]    Script Date: 4/10/2019 9:59:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsBuiltTable](
	[AsbuiltId] [bigint] IDENTITY(1,1) NOT NULL,
	[AsbuiltFiles] [nvarchar](max) NULL,
	[ContractCode] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AsBuiltTable] PRIMARY KEY CLUSTERED 
(
	[AsbuiltId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuildsMainTable]    Script Date: 4/10/2019 9:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildsMainTable](
	[BuildUnitsFrom] [bigint] NULL,
	[BuildUnitsTo] [bigint] NULL,
	[BuildReport] [nvarchar](max) NULL,
	[ContractCode] [nvarchar](450) NOT NULL,
	[BuildType] [nvarchar](max) NULL,
	[projectName] [nvarchar](450) NOT NULL,
	[projectIndexation] [nvarchar](max) NULL,
	[receiptOfTheSite] [nvarchar](max) NULL,
	[locationOfCheckingDrillingBottom] [nvarchar](max) NULL,
	[asbuilt] [nvarchar](max) NULL,
	[implementerCompany] [nvarchar](max) NULL,
	[periodToImplementProject] [nvarchar](max) NULL,
	[projectConsultative] [nvarchar](max) NULL,
	[startingProjectDate] [datetime] NULL,
	[projectrecordingDate] [datetime] NULL,
	[projectOwner] [nvarchar](max) NULL,
	[projectNotes] [nvarchar](max) NULL,
	[DurationProgram] [nvarchar](max) NULL,
	[percentageOfImplementation] [float] NULL,
	[percentageOfImplementationDetails] [nvarchar](max) NULL,
	[contractValue] [money] NULL,
	[FinalClosing] [money] NULL,
	[contractValueFile] [nvarchar](max) NULL,
	[FinalClosingFile] [nvarchar](max) NULL,
	[lastExactractFile] [nvarchar](max) NULL,
	[Savings] [nvarchar](max) NULL,
	[Receipts] [nvarchar](max) NULL,
	[Appropriations] [nvarchar](max) NULL,
	[SiteOrders] [nvarchar](max) NULL,
	[ManagementMails] [nvarchar](max) NULL,
	[Netbudget] [nvarchar](max) NULL,
	[ConstructionSafetyReport] [nvarchar](max) NULL,
	[ExploitationReductionandCancellationNotes] [nvarchar](max) NULL,
	[notices] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[EndingOfContractorDate] [datetime] NULL,
	[AddedPeriodToProject] [nvarchar](max) NULL,
	[LastTimeForEndingProject] [datetime] NULL,
	[Total] [bigint] NULL,
	[ProjectDataTypes] [nvarchar](max) NULL,
	[megaProjectName] [nvarchar](450) NOT NULL,
	[lastExactract] [money] NULL,
	[Division] [money] NULL,
	[savingsValue] [money] NULL,
	[projectPhrase] [nvarchar](max) NULL,
	[percentageOfImplementationAccordingToFinancialStatement] [float] NULL,
 CONSTRAINT [PK_BuildsMainTable] PRIMARY KEY CLUSTERED 
(
	[ContractCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_BuildsMainTable_ContractCode] UNIQUE NONCLUSTERED 
(
	[ContractCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deductionTable]    Script Date: 4/10/2019 9:59:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deductionTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](1000) NULL,
	[amount] [float] NULL,
	[PricePerUnit] [money] NULL,
	[totalValue] [money] NULL,
	[Importer] [nvarchar](1000) NULL,
	[Deduction] [float] NULL,
	[validDeduction] [money] NULL,
	[confirmedDeductionVal] [float] NULL,
	[DeductionPrice] [money] NULL,
	[notes] [nvarchar](1000) NULL,
	[ProjectCode] [nvarchar](450) NULL,
 CONSTRAINT [PK_RecordTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[megaProject]    Script Date: 4/10/2019 9:59:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[megaProject](
	[megaProjectName] [nvarchar](450) NOT NULL,
	[megaProjectFundemental] [money] NULL,
	[noOfPhrases] [int] NULL,
	[MegaProjTimeStrategy] [nvarchar](450) NULL,
	[MegaProjComponents] [nvarchar](450) NULL,
	[MegaProjFinancialStatement] [money] NULL,
	[MegaProjRequiredDependency] [money] NULL,
	[MegaProjPaid] [money] NULL,
	[MegaProjrestOfMoneySpecified] [money] NULL,
	[MegaProjshortage] [money] NULL,
	[MegaProjSavings] [money] NULL,
	[MegaProjExchangeRate] [float] NULL,
	[MegaProjAllContractedValue] [money] NULL,
	[MegaProjImplementedRate] [float] NULL,
	[MegaProjImplementedRateAccordingToFinancialStat] [float] NULL,
 CONSTRAINT [PK_megaProject] PRIMARY KEY CLUSTERED 
(
	[megaProjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nets]    Script Date: 4/10/2019 9:59:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nets](
	[BuildID] [int] NOT NULL,
	[BuildUnitsFrom] [bigint] NULL,
	[BuildUnitsTo] [bigint] NULL,
	[BuildReport] [nvarchar](max) NULL,
	[ContractCode] [nvarchar](450) NULL,
	[Image] [image] NULL,
	[BuildType] [nvarchar](max) NULL,
	[projectName] [nvarchar](450) NOT NULL,
	[projectIndexation] [nvarchar](max) NULL,
	[receiptOfTheSite] [nvarchar](max) NULL,
	[locationOfCheckingDrillingBottom] [nvarchar](max) NULL,
	[asbuilt] [nvarchar](max) NULL,
	[implementerCompany] [nvarchar](max) NULL,
	[periodToImplementProject] [nvarchar](max) NULL,
	[projectConsultative] [nvarchar](max) NULL,
	[startingProjectDate] [datetime] NULL,
	[projectrecordingDate] [datetime] NULL,
	[projectOwner] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhrasesTablle]    Script Date: 4/10/2019 9:59:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhrasesTablle](
	[phrasesName] [nvarchar](450) NOT NULL,
	[phrasesNum] [int] NOT NULL,
	[megaProjName] [nvarchar](450) NOT NULL,
	[TimeStrategy] [nvarchar](450) NULL,
	[phraseComponents] [nvarchar](450) NULL,
	[PhraseFinancialStatement] [money] NULL,
	[PhraseRequiredDependency] [money] NULL,
	[PhrasePaid] [money] NULL,
	[PhraserestOfMoneySpecified] [money] NULL,
	[Phraseshortage] [money] NULL,
	[PhraseSavings] [money] NULL,
	[PhraseExchangeRate] [float] NULL,
	[PhrasesAllContractedValue] [money] NULL,
	[PhraseImplementedRate] [float] NULL,
	[PhraseImplementedRateAccordingToFinancialStat] [float] NULL,
 CONSTRAINT [PK_PhrasesTablle] PRIMARY KEY CLUSTERED 
(
	[phrasesNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectDetails]    Script Date: 4/10/2019 9:59:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectDetails](
	[projectName] [nvarchar](450) NOT NULL,
	[periodToImplementProject] [int] NULL,
	[implementerCompany] [nvarchar](max) NULL,
	[projectOwner] [nvarchar](max) NULL,
	[projectrecordingDate] [datetime] NULL,
	[projectID] [int] IDENTITY(1,1) NOT NULL,
	[startingProjectDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectDetails] PRIMARY KEY CLUSTERED 
(
	[projectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ProjectDetails] UNIQUE NONCLUSTERED 
(
	[projectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectImages]    Script Date: 4/10/2019 9:59:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectImages](
	[Image] [nvarchar](max) NULL,
	[ProjectImagesID] [bigint] IDENTITY(1,1) NOT NULL,
	[ContractCode] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ProjectImages] PRIMARY KEY CLUSTERED 
(
	[ProjectImagesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectReports]    Script Date: 4/10/2019 9:59:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectReports](
	[dustReport] [nvarchar](max) NULL,
	[recordingdateOnDB] [datetime] NOT NULL,
	[projectName] [nvarchar](450) NULL,
	[ContractCode] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_؛ProjectReports] PRIMARY KEY CLUSTERED 
(
	[recordingdateOnDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[projectViews]    Script Date: 4/10/2019 9:59:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[projectViews](
	[BuilDSImages] [image] NULL,
	[ContractCode] [nvarchar](450) NOT NULL,
	[projectName] [nvarchar](450) NOT NULL,
	[ImageType] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SandReport]    Script Date: 4/10/2019 9:59:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SandReport](
	[SandReportCode] [bigint] NOT NULL,
	[avoirdupois] [decimal](18, 0) NULL,
	[SandType] [varchar](50) NULL,
	[reportDate] [datetime] NULL,
	[SandreportContent] [nvarchar](100) NULL,
	[SandReportFile] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_SandReport] PRIMARY KEY CLUSTERED 
(
	[SandReportCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_BuildsMainTable_megaProj]    Script Date: 4/10/2019 9:59:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_BuildsMainTable_megaProj] ON [dbo].[BuildsMainTable]
(
	[megaProjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_BuildsMainTable_projectName]    Script Date: 4/10/2019 9:59:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_BuildsMainTable_projectName] ON [dbo].[BuildsMainTable]
(
	[projectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_؛ProjectReports]    Script Date: 4/10/2019 9:59:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_؛ProjectReports] ON [dbo].[ProjectReports]
(
	[projectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BuildsMainTable] ADD  CONSTRAINT [DF_BuildsMainTable_contractValue]  DEFAULT ((0.0)) FOR [contractValue]
GO
ALTER TABLE [dbo].[BuildsMainTable] ADD  CONSTRAINT [DF_BuildsMainTable_FinalClosing]  DEFAULT ((0.0)) FOR [FinalClosing]
GO
ALTER TABLE [dbo].[BuildsMainTable] ADD  CONSTRAINT [DF_BuildsMainTable_megaProjectName]  DEFAULT ('unKnown') FOR [megaProjectName]
GO
ALTER TABLE [dbo].[BuildsMainTable] ADD  CONSTRAINT [DF_BuildsMainTable_lastExactract]  DEFAULT ((0.0)) FOR [lastExactract]
GO
ALTER TABLE [dbo].[BuildsMainTable] ADD  CONSTRAINT [DF_BuildsMainTable_Division]  DEFAULT ((0.0)) FOR [Division]
GO
ALTER TABLE [dbo].[BuildsMainTable] ADD  CONSTRAINT [DF_BuildsMainTable_savingsValue]  DEFAULT ((0.0)) FOR [savingsValue]
GO
ALTER TABLE [dbo].[megaProject] ADD  CONSTRAINT [DF_megaProject_megaProjectFundemental]  DEFAULT ((0)) FOR [megaProjectFundemental]
GO
ALTER TABLE [dbo].[megaProject] ADD  CONSTRAINT [DF_megaProject_noOfPhrases]  DEFAULT ((1)) FOR [noOfPhrases]
GO
ALTER TABLE [dbo].[AsBuiltTable]  WITH CHECK ADD  CONSTRAINT [FK_AsBuiltTable_BuildsMainTable] FOREIGN KEY([ContractCode])
REFERENCES [dbo].[BuildsMainTable] ([ContractCode])
GO
ALTER TABLE [dbo].[AsBuiltTable] CHECK CONSTRAINT [FK_AsBuiltTable_BuildsMainTable]
GO
ALTER TABLE [dbo].[BuildsMainTable]  WITH CHECK ADD  CONSTRAINT [FK_BuildsMainTable_BuildsMainTable] FOREIGN KEY([ContractCode])
REFERENCES [dbo].[BuildsMainTable] ([ContractCode])
GO
ALTER TABLE [dbo].[BuildsMainTable] CHECK CONSTRAINT [FK_BuildsMainTable_BuildsMainTable]
GO
ALTER TABLE [dbo].[BuildsMainTable]  WITH CHECK ADD  CONSTRAINT [FK_BuildsMainTable_MegaProj] FOREIGN KEY([megaProjectName])
REFERENCES [dbo].[megaProject] ([megaProjectName])
GO
ALTER TABLE [dbo].[BuildsMainTable] CHECK CONSTRAINT [FK_BuildsMainTable_MegaProj]
GO
ALTER TABLE [dbo].[deductionTable]  WITH CHECK ADD  CONSTRAINT [FK_deductionTable_BuildsMainTable] FOREIGN KEY([ProjectCode])
REFERENCES [dbo].[BuildsMainTable] ([ContractCode])
GO
ALTER TABLE [dbo].[deductionTable] CHECK CONSTRAINT [FK_deductionTable_BuildsMainTable]
GO
ALTER TABLE [dbo].[PhrasesTablle]  WITH CHECK ADD  CONSTRAINT [FK_PhrasesTabllemegaProj] FOREIGN KEY([megaProjName])
REFERENCES [dbo].[megaProject] ([megaProjectName])
GO
ALTER TABLE [dbo].[PhrasesTablle] CHECK CONSTRAINT [FK_PhrasesTabllemegaProj]
GO
ALTER TABLE [dbo].[ProjectImages]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImages_BuildsMainTable1] FOREIGN KEY([ContractCode])
REFERENCES [dbo].[BuildsMainTable] ([ContractCode])
GO
ALTER TABLE [dbo].[ProjectImages] CHECK CONSTRAINT [FK_ProjectImages_BuildsMainTable1]
GO
ALTER TABLE [dbo].[ProjectReports]  WITH CHECK ADD  CONSTRAINT [FK_ProjectReports_BuildsMainTable_ContractCode] FOREIGN KEY([ContractCode])
REFERENCES [dbo].[BuildsMainTable] ([ContractCode])
GO
ALTER TABLE [dbo].[ProjectReports] CHECK CONSTRAINT [FK_ProjectReports_BuildsMainTable_ContractCode]
GO
ALTER TABLE [dbo].[ProjectReports]  WITH CHECK ADD  CONSTRAINT [FK_ProjectReports_ProjectReports] FOREIGN KEY([recordingdateOnDB])
REFERENCES [dbo].[ProjectReports] ([recordingdateOnDB])
GO
ALTER TABLE [dbo].[ProjectReports] CHECK CONSTRAINT [FK_ProjectReports_ProjectReports]
GO
USE [master]
GO
ALTER DATABASE [BUILDINGProjectsTables] SET  READ_WRITE 
GO
