USE [DolPic]
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicImageLike_Insert]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_DolPicImageLike_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_DolPicImageLike_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UP_Image_Select]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Image_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_Image_Select]
GO
/****** Object:  StoredProcedure [dbo].[UPA_HashTag_Delete]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_HashTag_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UPA_HashTag_Delete]
GO
/****** Object:  StoredProcedure [dbo].[UPA_HashTag_Insert]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_HashTag_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UPA_HashTag_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UPA_HashTag_List]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_HashTag_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UPA_HashTag_List]
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicImage_Insert]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_DolPicImage_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_DolPicImage_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UP_Initial_List]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Initial_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_Initial_List]
GO
/****** Object:  StoredProcedure [dbo].[UP_MainImage_List]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_MainImage_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_MainImage_List]
GO
/****** Object:  StoredProcedure [dbo].[UPA_DolPicImage_Insert]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_DolPicImage_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UPA_DolPicImage_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UPA_DolPicImage_List]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_DolPicImage_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UPA_DolPicImage_List]
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicUser_Insert]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_DolPicUser_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_DolPicUser_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicUser_Login]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_DolPicUser_Login]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_DolPicUser_Login]
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_Delete]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_Favorite_Delete]
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_Insert]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_Favorite_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_List]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_Favorite_List]
GO
/****** Object:  StoredProcedure [dbo].[UP_HashTag_Insert]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_HashTag_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_HashTag_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UP_HashTag_List]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_HashTag_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_HashTag_List]
GO
/****** Object:  StoredProcedure [dbo].[UP_HotDolPic_List]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_HotDolPic_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_HotDolPic_List]
GO
/****** Object:  StoredProcedure [dbo].[P_ErrorLog_Insert]    Script Date: 06/19/2015 18:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_ErrorLog_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_ErrorLog_Insert]
GO
/****** Object:  StoredProcedure [dbo].[P_ErrorLog_Insert]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_ErrorLog_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_ErrorLog_Insert]
	@ErrorContents NVARCHAR(MAX)
AS

BEGIN
	SET NOCOUNT ON
	
	IF ERROR_NUMBER() IS NULL
        RETURN
        
    DECLARE
        @ErrorMessage    NVARCHAR(4000),
        @ErrorNumber     INT,
        @ErrorSeverity   INT,
        @ErrorState      INT,
        @ErrorLine       INT,
        @ErrorProcedure  NVARCHAR(200); 

    SELECT
        @ErrorNumber = ERROR_NUMBER(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorLine = ERROR_LINE(),
        @ErrorProcedure = ISNULL(ERROR_PROCEDURE(), ''-''); 
        SELECT @ErrorMessage = ''Message: ''+ ERROR_MESSAGE(); 

	INSERT INTO L_Error ( ErrorNumber, ErrorSeverity, ErrorState, ErrorProcedure, ErrorLine, ErrorMessage, ErrorContents, ErrorRegDate )
	VALUES( @ErrorNumber, @ErrorSeverity, @ErrorState, @ErrorProcedure, @ErrorLine, @ErrorMessage, @ErrorContents, GETDATE() )


    SET NOCOUNT OFF
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_HotDolPic_List]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_HotDolPic_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[UP_HotDolPic_List]
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY
	
	SELECT Seq, B.LikeCnt, TagUrlType, HashTag
	FROM T_DolPic_HashTag A
	JOIN 
	(
		SELECT TOP 5 HashTagSeq, SUM(LikeCnt) LikeCnt, MAX(TagUrlType) TagUrlType
		FROM T_DolPic_Image
		GROUP BY HashTagSeq
		ORDER BY LikeCnt DESC
	) B
		ON A.Seq = B.HashTagSeq
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''null''

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_HashTag_List]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_HashTag_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[UP_HashTag_List]
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	SELECT Seq, HashTag, Initial
	FROM T_DolPic_HashTag
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''null''

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_HashTag_Insert]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_HashTag_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[UP_HashTag_Insert]
	@HashTag	varchar(30),
	@Initial		nvarchar(1),
	@RetCode	tinyint	output
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY
		
	-- 기등록 검사
	IF EXISTS (SELECT * FROM T_DolPic_HashTag
				 WHERE HashTag = @HashTag)
		BEGIN
		
			SET @RetCode = 1
			RETURN ISNULL(ERROR_NUMBER(), 0)
		
		END
		
	BEGIN TRAN	
	
	INSERT INTO T_DolPic_HashTag VALUES (@HashTag, @Initial, 0)
		
	SET @RetCode = 0
	
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	SET @RetCode = 99

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@HashTag='' + @HashTag
								+ ''@Initial='' + @Initial

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_List]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UP_Favorite_List]
	@UserId		varchar(12)
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	SELECT A.Seq, HashTag
	FROM T_DolPic_HashTag A
	JOIN T_DolPic_HashTag_Favorite B
		ON A.Seq = B.Seq
	WHERE UserId = @UserId
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''null''

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_Insert]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UP_Favorite_Insert]
	@Seq			int,
	@UserId		varchar(12),
	@RetCode	tinyint	output
AS

SET XACT_ABORT ON
SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	-- 등록된 즐겨찾기면 그냥 리턴
	IF EXISTS (SELECT Seq FROM T_DolPic_HashTag_Favorite WHERE Seq = @Seq AND UserId = @UserId)
		BEGIN
		
			SET @RetCode = 1
			RETURN ISNULL(ERROR_NUMBER(), 0)			
			
		END
		
	BEGIN TRAN	
	
	INSERT INTO T_DolPic_HashTag_Favorite VALUES (@Seq, @UserId, GETDATE())
	
	SET @RetCode = 0
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	SET @RetCode = 99

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@Seq='' + CONVERT(NVARCHAR(MAX), @Seq)
						+ ''@UserId='' + @UserId

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_Delete]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROC [dbo].[UP_Favorite_Delete]
	@Seq			int,
	@UserId		varchar(12),
	@RetCode	tinyint	output
AS

SET XACT_ABORT ON
SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY
		
	BEGIN TRAN	
	
	DELETE FROM T_DolPic_HashTag_Favorite
	WHERE Seq = @Seq
	AND UserId = @UserId
	
	SET @RetCode = 0
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	SET @RetCode = 99

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@Seq='' + CONVERT(NVARCHAR(MAX), @Seq)
						+ ''@UserId='' + @UserId

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicUser_Login]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_DolPicUser_Login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UP_DolPicUser_Login]
	@UserId	varchar(12),
	@UserPwd	varchar(30),
	@RetCode	tinyint	output
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	DECLARE @pwdEncrypted varbinary(64)

	SELECT @pwdEncrypted = UserPwd
	FROM T_DolPic_User 
	WHERE UserId = @UserId

	IF @@ROWCOUNT = 0
		BEGIN
		
			SET @RetCode = 9
			RETURN ISNULL(ERROR_NUMBER(), 0)
			
		END

	IF PWDCOMPARE(@UserPwd, @pwdEncrypted) <> 1
		BEGIN
		
			SET @RetCode = 4
			RETURN ISNULL(ERROR_NUMBER(), 0)
			
		END
		
	SET @RetCode = 0
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	SET @RetCode = 99

	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@UserId='' + @UserId
								+ ''@UserPwd='' + @UserId

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicUser_Insert]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_DolPicUser_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UP_DolPicUser_Insert]
	@UserId	varchar(12),
	@UserPwd	varchar(20),
	@RetCode	tinyint	output
AS

SET XACT_ABORT ON
SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY
		
	-- 기등록 검사
	IF EXISTS (SELECT * FROM T_DolPic_User
				 WHERE UserId = @UserId)
		BEGIN
		
			SET @RetCode = 1
			RETURN ISNULL(ERROR_NUMBER(), 0)
		
		END
		
	BEGIN TRAN	
	
	INSERT INTO T_DolPic_User VALUES
	(@UserId, PWDENCRYPT(@UserPwd), GETDATE(), GETDATE(), GETDATE())
		
	SET @RetCode = 0
	
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	SET @RetCode = 99

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@UserId='' + @UserId
								+ ''@UserPwd='' + @UserId

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UPA_DolPicImage_List]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_DolPicImage_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UPA_DolPicImage_List]
	@Seq		int
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	SELECT Seq, ImageSrc, TagUrlType, LikeCnt
	FROM T_DolPic_Image
	WHERE HashTagSeq = @Seq
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''null''

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UPA_DolPicImage_Insert]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_DolPicImage_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UPA_DolPicImage_Insert]
	@Seq			int,
	@ImageSrc	varchar(50),
	@TagUrlType		tinyint
AS

SET XACT_ABORT ON
SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	-- 등록된 이미지면 그냥 리턴
	IF EXISTS (SELECT HashTagSeq FROM T_DolPic_Image WHERE HashTagSeq = @Seq AND ImageSrc = @ImageSrc)
		RETURN ISNULL(ERROR_NUMBER(), 0)
		
	BEGIN TRAN	
	
	INSERT INTO T_DolPic_Image VALUES (@Seq, @ImageSrc, @TagUrlType, 0)
		
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@Seq='' + CONVERT(NVARCHAR(MAX), @Seq)
						+ ''@ImageSrc='' + @ImageSrc
						+ ''@TagUrlType='' + CONVERT(NVARCHAR(MAX), @TagUrlType)

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_MainImage_List]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_MainImage_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UP_MainImage_List]
	@HashTag varchar(30),
	@CurPage tinyint,
	@PageListSize tinyint,
	@TotalCnt		int = 0 output
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	DECLARE @nStartIdx INT
	DECLARE @nEndIdx INT
	DECLARE @nPageSize INT
	SET @nPageSize = @PageListSize

	SET @nStartIdx = @nPageSize * (@CurPage - 1)

	IF (@nStartIdx % @nPageSize) = 0
		SET @nStartIdx = @nStartIdx + 1

	SET @nEndIdx = @nStartIdx + @nPageSize - 1

	;WITH _with AS
	(
		SELECT B.Seq, HashTagSeq, ImageSrc, B.LikeCnt, HashTag, ROW_NUMBER() OVER(ORDER BY B.Seq DESC ) AS ROW_NUM
		FROM T_DolPic_HashTag A
		JOIN T_DolPic_Image B
			ON A.Seq = B.HashTagSeq
		WHERE	CASE (@HashTag)
					WHEN '''' THEN @HashTag
					ELSE HashTag
				END = @HashTag
	)

	SELECT * 
	FROM _with
	WHERE ROW_NUM BETWEEN @nStartIdx AND @nEndIdx
	ORDER BY ROW_NUM 

	SELECT @TotalCnt = COUNT(*)
	FROM T_DolPic_HashTag A
	JOIN T_DolPic_Image B
		ON A.Seq = B.HashTagSeq
	WHERE	CASE (@HashTag)
					WHEN '''' THEN @HashTag
					ELSE HashTag
				END = @HashTag
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@HashTag='' + @HashTag
						+ ''@CurPage='' + CONVERT(NVARCHAR(MAX), @CurPage)
						+ ''@PageListSize='' + CONVERT(NVARCHAR(MAX), @PageListSize)

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_Initial_List]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Initial_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UP_Initial_List]
	@UserId		varchar(12)
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	--SELECT Seq, HashTag, A.Initial, InitialCnt
	--FROM T_DolPic_HashTag A
	--JOIN 
	--(
	--	SELECT Initial, COUNT(*) InitialCnt
	--	FROM T_DolPic_HashTag
	--	GROUP BY Initial
	--) B
	--	ON A.Initial = B.Initial
	--ORDER BY Initial
	
	SELECT A.Seq, HashTag, A.Initial, InitialCnt, B.Seq FavoriteSeq
	FROM
	(
		SELECT Seq, HashTag, A.Initial, InitialCnt
		FROM T_DolPic_HashTag A
		JOIN 
		(
			SELECT Initial, COUNT(*) InitialCnt
			FROM T_DolPic_HashTag
			GROUP BY Initial
		) B
			ON A.Initial = B.Initial
	) A
	LEFT JOIN T_DolPic_HashTag_Favorite B
		ON A.Seq = B.Seq
		AND UserId = @UserId
	ORDER BY Initial
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@contents=null''

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicImage_Insert]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_DolPicImage_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[UP_DolPicImage_Insert]
	@Seq			int,
	@ImageSrc	varchar(40),
	@TagUrlType		tinyint
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	-- 등록된 이미지면 그냥 리턴
	IF EXISTS (SELECT HashTagSeq FROM T_DolPic_Image WHERE HashTagSeq = @Seq AND ImageSrc = @ImageSrc)
		RETURN ISNULL(ERROR_NUMBER(), 0)
		
	BEGIN TRAN	
	
	INSERT INTO T_DolPic_Image VALUES (@Seq, @ImageSrc, @TagUrlType, 0)
		
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@Seq='' + CONVERT(NVARCHAR(MAX), @Seq)
								+ ''@ImageSrc='' + @ImageSrc
								+ ''@TagUrlType='' + CONVERT(NVARCHAR(MAX), @TagUrlType)

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH' 
END
GO
/****** Object:  StoredProcedure [dbo].[UPA_HashTag_List]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_HashTag_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UPA_HashTag_List]
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	SELECT Seq, HashTag, Initial
	FROM T_DolPic_HashTag
	ORDER BY Seq
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''null''

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UPA_HashTag_Insert]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_HashTag_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UPA_HashTag_Insert]
	@HashTag	varchar(30),
	@Initial		nvarchar(1),
	@RetCode	tinyint	output
AS

SET XACT_ABORT ON
SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY
		
	-- 기등록 검사
	IF EXISTS (SELECT * FROM T_DolPic_HashTag
				 WHERE HashTag = @HashTag)
		BEGIN
		
			SET @RetCode = 1
			RETURN ISNULL(ERROR_NUMBER(), 0)
		
		END
		
	BEGIN TRAN	
	
	INSERT INTO T_DolPic_HashTag VALUES (@HashTag, @Initial, 0)
		
	SET @RetCode = 0
	
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	SET @RetCode = 99

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@HashTag='' + @HashTag
								+ ''@Initial='' + @Initial

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UPA_HashTag_Delete]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPA_HashTag_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UPA_HashTag_Delete]
	@Seq		int,
	@RetCode	tinyint	output
AS

SET XACT_ABORT ON
SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY
		
	DELETE FROM T_DolPic_Image_Like
	WHERE Seq = @Seq
		
	DELETE FROM T_DolPic_Image
	WHERE HashTagSeq = @Seq
		
	DELETE FROM T_DolPic_HashTag
	WHERE Seq = @Seq
	
	SET @RetCode = 0
	
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@Seq='' + CONVERT(NVARCHAR(MAX), @Seq)
						
	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_Image_Select]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Image_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UP_Image_Select]
	@Seq int,
	@UserId varchar(12),
	@SearchHashTag varchar(20),
	@ImageSrc varchar(60) output,
	@HashTag varchar(20) output,
	@PrevSeq int output,
	@NextSeq int output,
	@IsLike tinyint = 0 output,
	@LikeCnt int output
AS

SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	SELECT @ImageSrc = ImageSrc, @HashTag = HashTag, @LikeCnt = B.LikeCnt
	FROM T_DolPic_HashTag A
	JOIN T_DolPic_Image B
		ON A.Seq = B.HashTagSeq
	WHERE B.Seq = @Seq
	
	SELECT TOP 1 @PrevSeq = B.Seq
	FROM T_DolPic_HashTag A
	JOIN T_DolPic_Image B
		ON A.Seq = B.HashTagSeq
	WHERE B.Seq < @Seq
	AND	CASE (@SearchHashTag)
				WHEN '''' THEN @SearchHashTag
				ELSE HashTag
			END = @SearchHashTag
	ORDER BY B.Seq DESC
	
	SELECT TOP 1 @NextSeq = B.Seq
	FROM T_DolPic_HashTag A
	JOIN T_DolPic_Image B
		ON A.Seq = B.HashTagSeq
	WHERE B.Seq > @Seq
	AND	CASE (@SearchHashTag)
				WHEN '''' THEN @SearchHashTag
				ELSE HashTag
			END = @SearchHashTag
	ORDER BY B.Seq
	
	IF EXISTS (SELECT * FROM T_DolPic_Image_Like WHERE Seq = @Seq AND UserId = @UserId)
		SET @IsLike = 1

	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@Seq='' + CONVERT(NVARCHAR(MAX), @Seq)

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicImageLike_Insert]    Script Date: 06/19/2015 18:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_DolPicImageLike_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UP_DolPicImageLike_Insert]
	@Seq			int,
	@UserId		varchar(12),
	@RetCode	tinyint	output,
	@LikeCnt		int	output
AS

SET XACT_ABORT ON
SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	-- 등록된 좋아요면 그냥 리턴
	IF EXISTS (SELECT Seq FROM T_DolPic_Image_Like WHERE Seq = @Seq AND UserId = @UserId)
		BEGIN
		
			SET @RetCode = 1
			RETURN ISNULL(ERROR_NUMBER(), 0)			
			
		END
		
	BEGIN TRAN	
	
	INSERT INTO T_DolPic_Image_Like VALUES (@Seq, @UserId, GETDATE())
	
	UPDATE T_DolPic_Image SET
		LikeCnt = LikeCnt + 1
	WHERE Seq = @Seq
	
	SELECT @LikeCnt = LikeCnt
	FROM T_DolPic_Image
	WHERE Seq = @Seq
		
	SET @RetCode = 0
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	SET @RetCode = 99

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = ''@Seq='' + CONVERT(NVARCHAR(MAX), @Seq)
						+ ''@UserId='' + @UserId

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
' 
END
GO
