CREATE PROCEDURE [dbo].[RefreshUsers]
	@UsersInput UserUpdateTable READONLY,
	@Success BIT OUTPUT
AS
BEGIN
SET @Success = 1
BEGIN TRY
	MERGE INTO ServiceDesk_Users usrt
	USING (
		SELECT
			src.[SID],
			src.[UserName],
			src.[FirstName],
			src.[LastName],
			src.[EMail],
			src.[LocationId],
			src.[DepartmentId]
		FROM @UsersInput src
	) usr_src
	ON usrt.[SID] = usr_src.[SID]
	WHEN MATCHED THEN
		UPDATE SET
			[UserName] = usr_src.[UserName],
			[FirstName] = usr_src.[FirstName],
			[LastName] = usr_src.[LastName],
			[EMail] = usr_src.[EMail],
			[LocationId] = usr_src.[LocationId],
			[DepartmentId] = usr_src.[DepartmentId]
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(
		[SID],
		[UserName],
		[FirstName],
		[LastName],
		[EMail],
		[LocationId],
		[DepartmentId]
		)
		VALUES(
		usr_src.[SID],
		usr_src.[UserName],
		usr_src.[FirstName],
		usr_src.[LastName],
		usr_src.[EMail],
		usr_src.[LocationId],
		usr_src.[DepartmentId]
		);


END TRY
BEGIN CATCH
	SET @Success = 0
	    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

	RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH

END
