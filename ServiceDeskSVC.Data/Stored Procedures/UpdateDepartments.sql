CREATE PROCEDURE [dbo].[UpdateDepartments]
	@DepartmentsInput DepartmentUpdateTable READONLY,
	@Success BIT OUTPUT
AS
BEGIN
SET @Success = 1
BEGIN TRY
INSERT INTO [Departments]
SELECT
	src.DepartmentName
FROM @DepartmentsInput src
	LEFT JOIN Departments dep ON src.DepartmentName = dep.DepartmentName
WHERE dep.Id IS NULL
END TRY
BEGIN CATCH
	SET @Success = 0
END CATCH

END
