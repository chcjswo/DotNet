USE [DolPic]
GO
/****** Object:  ForeignKey [FK__T_DolPic___UserI__75A278F5]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Like] DROP CONSTRAINT [FK__T_DolPic___UserI__75A278F5]
GO
/****** Object:  ForeignKey [FK__T_DolPic_Ha__Seq__74AE54BC]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Like] DROP CONSTRAINT [FK__T_DolPic_Ha__Seq__74AE54BC]
GO
/****** Object:  ForeignKey [FK__T_DolPic___HashT__21B6055D]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_Image] DROP CONSTRAINT [FK__T_DolPic___HashT__21B6055D]
GO
/****** Object:  ForeignKey [FK__T_DolPic___UserI__71D1E811]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like] DROP CONSTRAINT [FK__T_DolPic___UserI__71D1E811]
GO
/****** Object:  ForeignKey [FK__T_DolPic_Im__Seq__70DDC3D8]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like] DROP CONSTRAINT [FK__T_DolPic_Im__Seq__70DDC3D8]
GO
/****** Object:  Table [dbo].[T_DolPic_Image_Like]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like] DROP CONSTRAINT [FK__T_DolPic___UserI__71D1E811]
GO
ALTER TABLE [dbo].[T_DolPic_Image_Like] DROP CONSTRAINT [FK__T_DolPic_Im__Seq__70DDC3D8]
GO
DROP TABLE [dbo].[T_DolPic_Image_Like]
GO
/****** Object:  Table [dbo].[T_DolPic_HashTag_Like]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Like] DROP CONSTRAINT [FK__T_DolPic___UserI__75A278F5]
GO
ALTER TABLE [dbo].[T_DolPic_HashTag_Like] DROP CONSTRAINT [FK__T_DolPic_Ha__Seq__74AE54BC]
GO
DROP TABLE [dbo].[T_DolPic_HashTag_Like]
GO
/****** Object:  Table [dbo].[T_DolPic_Image]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_Image] DROP CONSTRAINT [FK__T_DolPic___HashT__21B6055D]
GO
DROP TABLE [dbo].[T_DolPic_Image]
GO
/****** Object:  Table [dbo].[T_DolPic_User]    Script Date: 06/16/2015 18:20:56 ******/
DROP TABLE [dbo].[T_DolPic_User]
GO
/****** Object:  Table [dbo].[L_Error]    Script Date: 06/16/2015 18:20:56 ******/
DROP TABLE [dbo].[L_Error]
GO
/****** Object:  Table [dbo].[T_DolPic_HashTag]    Script Date: 06/16/2015 18:20:56 ******/
DROP TABLE [dbo].[T_DolPic_HashTag]
GO
/****** Object:  Table [dbo].[T_DolPic_HashTag]    Script Date: 06/16/2015 18:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DolPic_HashTag](
	[Seq] [smallint] IDENTITY(1,1) NOT NULL,
	[HashTag] [varchar](30) NOT NULL,
	[Initial] [nvarchar](1) NOT NULL,
	[LikeCnt] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [CIX_T_DolPic_HashTag] ON [dbo].[T_DolPic_HashTag] 
(
	[Initial] ASC,
	[HashTag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [PK_T_DolPic_HashTag] ON [dbo].[T_DolPic_HashTag] 
(
	[Seq] ASC
)
INCLUDE ( [HashTag],
[Initial]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [PK_T_DolPic_HashTag_01] ON [dbo].[T_DolPic_HashTag] 
(
	[HashTag] ASC
)
INCLUDE ( [Seq]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[L_Error]    Script Date: 06/16/2015 18:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[L_Error](
	[ErrorNumber] [int] NOT NULL,
	[ErrorSeverity] [int] NOT NULL,
	[ErrorState] [int] NOT NULL,
	[ErrorProcedure] [varchar](200) NOT NULL,
	[ErrorLine] [int] NOT NULL,
	[ErrorMessage] [nvarchar](4000) NOT NULL,
	[ErrorContents] [nvarchar](max) NOT NULL,
	[ErrorRegDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_DolPic_User]    Script Date: 06/16/2015 18:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DolPic_User](
	[UserId] [varchar](12) NOT NULL,
	[UserPwd] [varbinary](128) NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[PwUpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK__T_DolPic__1788CC4C03317E3D] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_DolPic_Image]    Script Date: 06/16/2015 18:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DolPic_Image](
	[Seq] [int] IDENTITY(1,1) NOT NULL,
	[HashTagSeq] [smallint] NOT NULL,
	[ImageSrc] [varchar](60) NOT NULL,
	[TagUrlType] [tinyint] NOT NULL,
	[LikeCnt] [int] NOT NULL,
 CONSTRAINT [PK__T_DolPic__CA1E3C891FCDBCEB] PRIMARY KEY NONCLUSTERED 
(
	[Seq] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [CIX_T_DolPic_Image] ON [dbo].[T_DolPic_Image] 
(
	[HashTagSeq] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_T_DolPic_Image_01] ON [dbo].[T_DolPic_Image] 
(
	[HashTagSeq] ASC
)
INCLUDE ( [ImageSrc]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_DolPic_HashTag_Like]    Script Date: 06/16/2015 18:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DolPic_HashTag_Like](
	[Seq] [smallint] NOT NULL,
	[UserId] [varchar](12) NOT NULL,
 CONSTRAINT [PK_T_DolPic_HashTag_Like] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_DolPic_Image_Like]    Script Date: 06/16/2015 18:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DolPic_Image_Like](
	[Seq] [int] NOT NULL,
	[UserId] [varchar](12) NOT NULL,
 CONSTRAINT [PK_T_DolPic_Image_Like] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK__T_DolPic___UserI__75A278F5]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Like]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic___UserI__75A278F5] FOREIGN KEY([UserId])
REFERENCES [dbo].[T_DolPic_User] ([UserId])
GO
ALTER TABLE [dbo].[T_DolPic_HashTag_Like] CHECK CONSTRAINT [FK__T_DolPic___UserI__75A278F5]
GO
/****** Object:  ForeignKey [FK__T_DolPic_Ha__Seq__74AE54BC]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Like]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic_Ha__Seq__74AE54BC] FOREIGN KEY([Seq])
REFERENCES [dbo].[T_DolPic_HashTag] ([Seq])
GO
ALTER TABLE [dbo].[T_DolPic_HashTag_Like] CHECK CONSTRAINT [FK__T_DolPic_Ha__Seq__74AE54BC]
GO
/****** Object:  ForeignKey [FK__T_DolPic___HashT__21B6055D]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_Image]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic___HashT__21B6055D] FOREIGN KEY([HashTagSeq])
REFERENCES [dbo].[T_DolPic_HashTag] ([Seq])
GO
ALTER TABLE [dbo].[T_DolPic_Image] CHECK CONSTRAINT [FK__T_DolPic___HashT__21B6055D]
GO
/****** Object:  ForeignKey [FK__T_DolPic___UserI__71D1E811]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic___UserI__71D1E811] FOREIGN KEY([UserId])
REFERENCES [dbo].[T_DolPic_User] ([UserId])
GO
ALTER TABLE [dbo].[T_DolPic_Image_Like] CHECK CONSTRAINT [FK__T_DolPic___UserI__71D1E811]
GO
/****** Object:  ForeignKey [FK__T_DolPic_Im__Seq__70DDC3D8]    Script Date: 06/16/2015 18:20:56 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic_Im__Seq__70DDC3D8] FOREIGN KEY([Seq])
REFERENCES [dbo].[T_DolPic_Image] ([Seq])
GO
ALTER TABLE [dbo].[T_DolPic_Image_Like] CHECK CONSTRAINT [FK__T_DolPic_Im__Seq__70DDC3D8]
GO
