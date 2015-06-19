USE [DolPic]
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_Delete]    Script Date: 06/19/2015 00:33:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_Favorite_Delete]
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_Insert]    Script Date: 06/19/2015 00:33:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_Favorite_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_List]    Script Date: 06/19/2015 00:33:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UP_Favorite_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UP_Favorite_List]
GO
/****** Object:  StoredProcedure [dbo].[UP_Favorite_List]    Script Date: 06/19/2015 00:33:10 ******/
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
/****** Object:  StoredProcedure [dbo].[UP_Favorite_Insert]    Script Date: 06/19/2015 00:33:10 ******/
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
/****** Object:  StoredProcedure [dbo].[UP_Favorite_Delete]    Script Date: 06/19/2015 00:33:10 ******/
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
