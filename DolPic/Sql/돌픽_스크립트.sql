USE DolPic
GO

CREATE TABLE T_DolPic_User
(
	UserId	VARCHAR(12) NOT NULL PRIMARY KEY CLUSTERED,
	Pw		varbinary(64) NOT NULL,
	RegDate	DATETIME	NOT NULL,
	UpdateDate	DATETIME NOT NULL,
	PwUpdateDate	DATETIME NOT NULL
)
GO


CREATE TABLE T_DolPic_HashTag
(
	Seq	SMALLINT IDENTITY(1, 1) NOT NULL, --PRIMARY KEY NONCLUSTERED,
	HashTag VARCHAR(30) NOT NULL,
	Initial	NVARCHAR(1) NOT NULL,
	LikeCnt INT NOT NULL
)
GO
CREATE UNIQUE INDEX PK_T_DolPic_HashTag ON T_DolPic_HashTag (Seq) INCLUDE (HashTag, Initial)
GO
CREATE CLUSTERED INDEX CIX_T_DolPic_HashTag ON T_DolPic_HashTag (Initial ASC, HashTag ASC)
GO
CREATE INDEX PK_T_DolPic_HashTag_01 ON T_DolPic_HashTag (HashTag) INCLUDE (Seq)
GO

CREATE TABLE T_DolPic_Image
(
	Seq INT IDENTITY(1, 1) NOT NULL PRIMARY KEY NONCLUSTERED,
	HashTagSeq SMALLINT NOT NULL REFERENCES T_DolPic_HashTag (Seq),
	ImageSrc VARCHAR(50) NOT NULL,
	TagUrlType TINYINT NOT NULL,
	LikeCnt INT NOT NULL
)
GO
CREATE INDEX IX_T_DolPic_Image_01 ON T_DolPic_Image (HashTagSeq) INCLUDE (Seq, ImageSrc, LikeCnt)
GO
CREATE CLUSTERED INDEX CIX_T_DolPic_Image ON T_DolPic_Image (HashTagSeq)
GO


CREATE TABLE T_DolPic_HashTag_Favorite
(
	Seq SMALLINT NOT NULL REFERENCES T_DolPic_HashTag (Seq),
	UserId VARCHAR(12) NOT NULL REFERENCES T_DolPic_User (UserId),
	
	CONSTRAINT PK_T_DolPic_HashTag_Favorite PRIMARY KEY (Seq, UserId)
)
GO

CREATE TABLE T_DolPic_Image_Like
(
	Seq INT NOT NULL REFERENCES T_DolPic_Image (Seq),
	UserId VARCHAR(12) NOT NULL REFERENCES T_DolPic_User (UserId),
	
	CONSTRAINT PK_T_DolPic_Image_Like PRIMARY KEY (Seq, UserId)
)
GO


--ALTER TABLE T_DolPic_HashTag
--ADD LikeCnt INT NULL
--GO

--UPDATE T_DolPic_HashTag SET
--LikeCnt = 0
--GO

--ALTER TABLE T_DolPic_HashTag
--ALTER COLUMN LikeCnt INT NOT NULL
--GO
