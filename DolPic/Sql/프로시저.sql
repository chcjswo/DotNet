USE [DolPic]
GO
/****** Object:  StoredProcedure [dbo].[UP_DolPicImage_Like]    Script Date: 06/18/2015 00:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[UP_DolPicImage_Like]
	@Seq			int,
	@UserId		varchar(12),
	@RetCode	tinyint	output
AS

SET XACT_ABORT ON
SET NOCOUNT ON
SET LOCK_TIMEOUT 3000
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN TRY

	-- 등록된 이미지면 그냥 리턴
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
		
	SET @RetCode = 0
	COMMIT
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH

	SET @RetCode = 99

	IF (XACT_STATE()) = -1 ROLLBACK
	ELSE IF (XACT_STATE()) =  1 COMMIT
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = '@Seq=' + CONVERT(NVARCHAR(MAX), @Seq)
						+ '@UserId=' + @UserId

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
go


USE [DolPic]
GO
/****** Object:  StoredProcedure [dbo].[UP_MainImage_List]    Script Date: 06/17/2015 23:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[UP_MainImage_List]
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
					WHEN '' THEN @HashTag
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
					WHEN '' THEN @HashTag
					ELSE HashTag
				END = @HashTag
	
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END TRY
BEGIN CATCH
	
	DECLARE @ErrorContents NVARCHAR(MAX)
	SET @ErrorContents = '@HashTag=' + @HashTag
						+ '@CurPage=' + CONVERT(NVARCHAR(MAX), @CurPage)
						+ '@PageListSize=' + CONVERT(NVARCHAR(MAX), @PageListSize)

	EXEC P_ErrorLog_Insert @ErrorContents = @ErrorContents
	RETURN ISNULL(ERROR_NUMBER(), 0)
	
END CATCH
