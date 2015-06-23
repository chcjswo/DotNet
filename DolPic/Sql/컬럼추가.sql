

ALTER TABLE T_DolPic_Image
ADD IsView tinyint
GO

UPDATE T_DolPic_Image SET
	IsView = 1
GO

ALTER TABLE T_DolPic_Image
ALTER COLUMN IsView  tinyint NOT NULL
GO
