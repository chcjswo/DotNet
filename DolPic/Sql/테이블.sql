USE [DolPic]
GO
/****** Object:  ForeignKey [FK__T_DolPic___UserI__19DFD96B]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Favorite] DROP CONSTRAINT [FK__T_DolPic___UserI__19DFD96B]
GO
/****** Object:  ForeignKey [FK__T_DolPic_Ha__Seq__18EBB532]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Favorite] DROP CONSTRAINT [FK__T_DolPic_Ha__Seq__18EBB532]
GO
/****** Object:  ForeignKey [FK__T_DolPic___UserI__71D1E811]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like] DROP CONSTRAINT [FK__T_DolPic___UserI__71D1E811]
GO
/****** Object:  ForeignKey [FK__T_DolPic_Im__Seq__70DDC3D8]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like] DROP CONSTRAINT [FK__T_DolPic_Im__Seq__70DDC3D8]
GO
/****** Object:  Table [dbo].[T_DolPic_Image_Like]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like] DROP CONSTRAINT [FK__T_DolPic___UserI__71D1E811]
GO
ALTER TABLE [dbo].[T_DolPic_Image_Like] DROP CONSTRAINT [FK__T_DolPic_Im__Seq__70DDC3D8]
GO
DROP TABLE [dbo].[T_DolPic_Image_Like]
GO
/****** Object:  Table [dbo].[T_DolPic_HashTag_Favorite]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Favorite] DROP CONSTRAINT [FK__T_DolPic___UserI__19DFD96B]
GO
ALTER TABLE [dbo].[T_DolPic_HashTag_Favorite] DROP CONSTRAINT [FK__T_DolPic_Ha__Seq__18EBB532]
GO
DROP TABLE [dbo].[T_DolPic_HashTag_Favorite]
GO
/****** Object:  Table [dbo].[T_DolPic_User]    Script Date: 06/18/2015 18:53:01 ******/
DROP TABLE [dbo].[T_DolPic_User]
GO
/****** Object:  Table [dbo].[T_DolPic_User]    Script Date: 06/18/2015 18:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DolPic_User](
	[UserId] [varchar](12) NOT NULL,
	[UserPwd] [varbinary](64) NOT NULL,
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
/****** Object:  Table [dbo].[T_DolPic_HashTag_Favorite]    Script Date: 06/18/2015 18:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DolPic_HashTag_Favorite](
	[Seq] [smallint] NOT NULL,
	[UserId] [varchar](12) NOT NULL,
	[RegDate] [datetime] NOT NULL,
 CONSTRAINT [PK_T_DolPic_HashTag_Favorite] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_DolPic_Image_Like]    Script Date: 06/18/2015 18:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DolPic_Image_Like](
	[Seq] [int] NOT NULL,
	[UserId] [varchar](12) NOT NULL,
	[RegDate] [datetime] NOT NULL,
 CONSTRAINT [PK_T_DolPic_Image_Like] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK__T_DolPic___UserI__19DFD96B]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Favorite]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic___UserI__19DFD96B] FOREIGN KEY([UserId])
REFERENCES [dbo].[T_DolPic_User] ([UserId])
GO
ALTER TABLE [dbo].[T_DolPic_HashTag_Favorite] CHECK CONSTRAINT [FK__T_DolPic___UserI__19DFD96B]
GO
/****** Object:  ForeignKey [FK__T_DolPic_Ha__Seq__18EBB532]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_HashTag_Favorite]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic_Ha__Seq__18EBB532] FOREIGN KEY([Seq])
REFERENCES [dbo].[T_DolPic_HashTag] ([Seq])
GO
ALTER TABLE [dbo].[T_DolPic_HashTag_Favorite] CHECK CONSTRAINT [FK__T_DolPic_Ha__Seq__18EBB532]
GO
/****** Object:  ForeignKey [FK__T_DolPic___UserI__71D1E811]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic___UserI__71D1E811] FOREIGN KEY([UserId])
REFERENCES [dbo].[T_DolPic_User] ([UserId])
GO
ALTER TABLE [dbo].[T_DolPic_Image_Like] CHECK CONSTRAINT [FK__T_DolPic___UserI__71D1E811]
GO
/****** Object:  ForeignKey [FK__T_DolPic_Im__Seq__70DDC3D8]    Script Date: 06/18/2015 18:53:01 ******/
ALTER TABLE [dbo].[T_DolPic_Image_Like]  WITH CHECK ADD  CONSTRAINT [FK__T_DolPic_Im__Seq__70DDC3D8] FOREIGN KEY([Seq])
REFERENCES [dbo].[T_DolPic_Image] ([Seq])
GO
ALTER TABLE [dbo].[T_DolPic_Image_Like] CHECK CONSTRAINT [FK__T_DolPic_Im__Seq__70DDC3D8]
GO
