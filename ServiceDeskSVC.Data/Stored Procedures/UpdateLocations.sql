CREATE PROCEDURE [dbo].[UpdateLocations]
	@LocationsInput LocationUpdateTable READONLY,
	@Success BIT OUTPUT
AS
BEGIN
SET @Success = 1
BEGIN TRY
	MERGE INTO NSLocations locrt
	USING (
		SELECT
			src.[LocationCity],
			src.[LocationState],
			src.[LocationZip]
		FROM @LocationsInput src
	) loc_src
	ON locrt.[LocationCity] = loc_src.[LocationCity]
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(
		[LocationCity],
		[LocationState],
		[LocationZip]
		)
		VALUES(
		loc_src.[LocationCity],
		'NA',
		00000
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
