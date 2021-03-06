USE [master]
GO
/****** Object:  Database [dbUniversity]    Script Date: 04/26/2022 16:30:32 ******/
CREATE DATABASE [dbUniversity] ON  PRIMARY 
( NAME = N'dbUniversity', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\dbUniversity.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbUniversity_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\dbUniversity_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbUniversity] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbUniversity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbUniversity] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [dbUniversity] SET ANSI_NULLS OFF
GO
ALTER DATABASE [dbUniversity] SET ANSI_PADDING OFF
GO
ALTER DATABASE [dbUniversity] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [dbUniversity] SET ARITHABORT OFF
GO
ALTER DATABASE [dbUniversity] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [dbUniversity] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [dbUniversity] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [dbUniversity] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [dbUniversity] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [dbUniversity] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [dbUniversity] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [dbUniversity] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [dbUniversity] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [dbUniversity] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [dbUniversity] SET  DISABLE_BROKER
GO
ALTER DATABASE [dbUniversity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [dbUniversity] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [dbUniversity] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [dbUniversity] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [dbUniversity] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [dbUniversity] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [dbUniversity] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [dbUniversity] SET  READ_WRITE
GO
ALTER DATABASE [dbUniversity] SET RECOVERY SIMPLE
GO
ALTER DATABASE [dbUniversity] SET  MULTI_USER
GO
ALTER DATABASE [dbUniversity] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [dbUniversity] SET DB_CHAINING OFF
GO
USE [dbUniversity]
GO
/****** Object:  Table [dbo].[Matter]    Script Date: 04/26/2022 16:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Matter](
	[idMatter] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](63) NOT NULL,
	[description] [varchar](max) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Matter] PRIMARY KEY CLUSTERED 
(
	[idMatter] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Matter] ON
INSERT [dbo].[Matter] ([idMatter], [name], [description], [isActive]) VALUES (1, N'mate1', N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 1)
INSERT [dbo].[Matter] ([idMatter], [name], [description], [isActive]) VALUES (2, N'lenguaje1', N'bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 1)
INSERT [dbo].[Matter] ([idMatter], [name], [description], [isActive]) VALUES (3, N'negocios', N'ccccccccccccccccccccccccccccccccccccccccccccccccccccc', 0)
INSERT [dbo].[Matter] ([idMatter], [name], [description], [isActive]) VALUES (4, N'fisica', N'dddddddddddddddddddddddddddddddddddddddddddddddd', 1)
INSERT [dbo].[Matter] ([idMatter], [name], [description], [isActive]) VALUES (6, N'quimica1', N'eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee', 1)
INSERT [dbo].[Matter] ([idMatter], [name], [description], [isActive]) VALUES (7, N'geologia', N'ffffffffffffffffffffffffffffffffffffffffffffffff', 0)
INSERT [dbo].[Matter] ([idMatter], [name], [description], [isActive]) VALUES (8, N'mate3', N'gggggggggggggggggggggggggggggggggggggggggggggggg', 1)
INSERT [dbo].[Matter] ([idMatter], [name], [description], [isActive]) VALUES (9, N'fisica2', N'hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh', 1)
SET IDENTITY_INSERT [dbo].[Matter] OFF
/****** Object:  Table [dbo].[DocumentType]    Script Date: 04/26/2022 16:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocumentType](
	[idDocumentType] [bigint] IDENTITY(1,1) NOT NULL,
	[code] [varchar](3) NOT NULL,
	[name] [varchar](63) NOT NULL,
	[description] [varchar](max) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[idDocumentType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_code] ON [dbo].[DocumentType] 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_name] ON [dbo].[DocumentType] 
(
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DocumentType] ON
INSERT [dbo].[DocumentType] ([idDocumentType], [code], [name], [description], [isActive]) VALUES (2, N'abc', N'titulo1', N'aaaaaaaaaaaaaaaaaaaaaaaaaaaa', 1)
INSERT [dbo].[DocumentType] ([idDocumentType], [code], [name], [description], [isActive]) VALUES (5, N'aba', N'titulo2', N'bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 1)
INSERT [dbo].[DocumentType] ([idDocumentType], [code], [name], [description], [isActive]) VALUES (6, N'abb', N'titulo3', N'ccccccccccccccccccccccccccccccccccccccccc', 1)
INSERT [dbo].[DocumentType] ([idDocumentType], [code], [name], [description], [isActive]) VALUES (7, N'aaa', N'titulo4', N'dddddddddddddddddddddddddddddddddddddddd', 1)
INSERT [dbo].[DocumentType] ([idDocumentType], [code], [name], [description], [isActive]) VALUES (8, N'aac', N'titulo5', N'eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee', 1)
INSERT [dbo].[DocumentType] ([idDocumentType], [code], [name], [description], [isActive]) VALUES (9, N'aab', N'titulo6', N'ffffffffffffffffffffffffffffffffffffffffffffffff', 1)
INSERT [dbo].[DocumentType] ([idDocumentType], [code], [name], [description], [isActive]) VALUES (10, N'acb', N'titulo7', N'gggggggggggggggggggggggggggggggggg', 1)
SET IDENTITY_INSERT [dbo].[DocumentType] OFF
/****** Object:  StoredProcedure [dbo].[SelectAllDocuments]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllDocuments] 
	-- Add the parameters for the stored procedure here
	@id BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM DocumentType D
	WHERE @id IS NULL AND D.isActive = 1 OR D.idDocumentType = @id AND D.isActive = 1
END
GO
/****** Object:  Table [dbo].[Person]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[idPerson] [bigint] IDENTITY(1,1) NOT NULL,
	[idDocumentType] [bigint] NOT NULL,
	[document] [varchar](63) NOT NULL,
	[name1] [varchar](63) NOT NULL,
	[name2] [varchar](63) NULL,
	[lastname1] [varchar](63) NOT NULL,
	[lastname2] [varchar](63) NULL,
	[birthdayDate] [datetime] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[idPerson] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_idDocumentType] ON [dbo].[Person] 
(
	[idDocumentType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Person] ON
INSERT [dbo].[Person] ([idPerson], [idDocumentType], [document], [name1], [name2], [lastname1], [lastname2], [birthdayDate], [isActive]) VALUES (1, 6, N'cedula', N'pedro', NULL, N'peres', NULL, CAST(0x0000913400000000 AS DateTime), 1)
INSERT [dbo].[Person] ([idPerson], [idDocumentType], [document], [name1], [name2], [lastname1], [lastname2], [birthdayDate], [isActive]) VALUES (2, 10, N'pasaporte', N'jose', N'luis', N'nadal', N'del valle', CAST(0x00008D8100000000 AS DateTime), 1)
INSERT [dbo].[Person] ([idPerson], [idDocumentType], [document], [name1], [name2], [lastname1], [lastname2], [birthdayDate], [isActive]) VALUES (3, 2, N'visa', N'adriana', NULL, N'uslar', NULL, CAST(0x000079DD00000000 AS DateTime), 1)
INSERT [dbo].[Person] ([idPerson], [idDocumentType], [document], [name1], [name2], [lastname1], [lastname2], [birthdayDate], [isActive]) VALUES (4, 8, N'visa', N'maria', NULL, N'acosta', NULL, CAST(0x0000669E00000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Person] OFF
/****** Object:  StoredProcedure [dbo].[EditDocument]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditDocument]
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@code VARCHAR(3),
	@name VARCHAR(63),
	@description VARCHAR(MAX) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE DocumentType 
	SET "name" = @name, "code" = @code, "description" = @description
	WHERE DocumentType.idDocumentType = @id
END
GO
/****** Object:  StoredProcedure [dbo].[CreateNewDocument]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateNewDocument] 
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@code VARCHAR(3),
	@name VARCHAR(63),
	@description VARCHAR(MAX),
	@isActive BIT = 1
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO DocumentType("idDocumentType", "code", "name", "description", "isActive")
	VALUES (@id, @code, @name, @description, @isActive)
	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteMatter]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMatter] 
	-- Add the parameters for the stored procedure here
	@id BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Matter
	SET "isActive" = 0
	WHERE Matter.idMatter = @id
END
GO
/****** Object:  StoredProcedure [dbo].[EditMatter]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditMatter] 
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@name VARCHAR(63),
	@description VARCHAR(63) = NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Matter
	SET Matter.name = @name,
	Matter.description = @description
	WHERE Matter.idMatter = @id
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllMatter]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllMatter] 
	-- Add the parameters for the stored procedure here
	@id BIGINT = NULL
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Matter M
	WHERE @id IS NULL AND M.isActive = 1 OR M.idMatter = @id AND M.isActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[CreateNewMatter]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateNewMatter] 
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@name VARCHAR(63),
	@description VARCHAR(MAX) = NULL,
	@isActive BIT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Matter("idMatter", "name", "description", "isActive")
	VALUES (@id, @name, @description, @isActive)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDocType]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDocType] 
	-- Add the parameters for the stored procedure here
	@id BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE DocumentType
	SET "isActive" = 0
	WHERE DocumentType.idDocumentType = @id
END
GO
/****** Object:  Table [dbo].[Inscription]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscription](
	[idIscription] [bigint] IDENTITY(1,1) NOT NULL,
	[idMatter] [bigint] NOT NULL,
	[idPerson] [bigint] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED 
(
	[idIscription] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inscription] ON
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (1, 2, 3, 1)
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (2, 2, 1, 1)
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (3, 2, 4, 0)
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (5, 6, 2, 1)
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (6, 8, 3, 1)
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (7, 8, 1, 1)
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (8, 3, 4, 1)
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (9, 3, 2, 1)
INSERT [dbo].[Inscription] ([idIscription], [idMatter], [idPerson], [isActive]) VALUES (10, 3, 1, 0)
SET IDENTITY_INSERT [dbo].[Inscription] OFF
/****** Object:  StoredProcedure [dbo].[EditPerson]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditPerson] 
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@idDoc BIGINT,
	@doc VARCHAR(MAX),
	@name1 VARCHAR(63),
	@name2 VARCHAR(63) = NULL,
	@lastname1 VARCHAR(63),
	@lastname2 VARCHAR(63) = NULL,
	@birthdayDate DATETIME	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Person
	SET Person.idDocumentType = @idDoc,
	Person.document = @doc,
	Person.name1 = @name1,
	Person.name2 = @name2,
	Person.lastname1 = @lastname1,
	Person.lastname2 = @lastname2,
	Person.birthdayDate = @birthdayDate
	WHERE Person.idPerson = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePerson]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeletePerson] 
	-- Add the parameters for the stored procedure here
	@id BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Person
	SET "isActive" = 0
	WHERE Person.isActive = @id
END
GO
/****** Object:  StoredProcedure [dbo].[CreateNewPerson]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateNewPerson] 
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@idDoc BIGINT,
	@doc VARCHAR(63),
	@name1 VARCHAR(63),
	@name2 VARCHAR(63) = NULL,
	@lastname1 VARCHAR(63),
	@lastname2 VARCHAR(63) = NULL,
	@birthdayDate DATETIME,
	@isActive BIT = 1
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Person ("idPerson", "idDocumentType", "document", "name1", "name2", "lastname1", "lastname2", "birthdayDate", "isActive")
	VALUES (@id, @idDoc, @doc, @name1, @name2, @lastname1, @lastname2, @birthdayDate, @isActive)
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllPerson]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllPerson] 
	-- Add the parameters for the stored procedure here
	@id BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Person P
	WHERE @id IS NULL AND P.isActive = 1 OR P.idPerson = @id AND P.isActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllInscription]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllInscription] 
	-- Add the parameters for the stored procedure here
	@id BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Inscription I
	WHERE @id IS NULL AND I.isActive = 1 OR I.idIscription = @id AND I.isActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[EditInscription]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditInscription] 
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@idMatter BIGINT,
	@idPerson BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Inscription
	SET Inscription.idMatter = @idMatter,
	Inscription.idPerson = @idPerson
	WHERE Inscription.idIscription = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteInscription]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteInscription] 
	-- Add the parameters for the stored procedure here
	@id BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Inscription
	SET "isActive" = 0
	WHERE Inscription.idIscription = @id
END
GO
/****** Object:  StoredProcedure [dbo].[CreateNewInscription]    Script Date: 04/26/2022 16:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateNewInscription]
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@idMatter BIGINT,
	@idPerson BIGINT,
	@isActive BIT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Inscription("idIscription", "idMatter", "idPerson", "isActive")
	VALUES (@id, @idMatter, @idPerson, @isActive)
END
GO
/****** Object:  ForeignKey [FK_Person_DocumentType1]    Script Date: 04/26/2022 16:30:35 ******/
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_DocumentType1] FOREIGN KEY([idDocumentType])
REFERENCES [dbo].[DocumentType] ([idDocumentType])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_DocumentType1]
GO
/****** Object:  ForeignKey [FK_Inscription_Matter1]    Script Date: 04/26/2022 16:30:35 ******/
ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Matter1] FOREIGN KEY([idMatter])
REFERENCES [dbo].[Matter] ([idMatter])
GO
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Matter1]
GO
/****** Object:  ForeignKey [FK_Inscription_Person1]    Script Date: 04/26/2022 16:30:35 ******/
ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Person1] FOREIGN KEY([idPerson])
REFERENCES [dbo].[Person] ([idPerson])
GO
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Person1]
GO
