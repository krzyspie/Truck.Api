USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_GetFilteredAndSorted]
	@FilterBy NVARCHAR(50),
    @FilterValue NVARCHAR(50), 
    @SortBy NVARCHAR(50),
    @SortDirection NVARCHAR(4)
AS
BEGIN
	DECLARE @SqlQuery NVARCHAR(MAX);

    SET @SqlQuery = 
        'SELECT Id, Code, Name, Status, Description, DateCreated, DateModified ' +
        'FROM dbo.[Trucks] ' +
        'WHERE ' + QUOTENAME(@FilterBy) + ' = @FilterValue ' +
        'ORDER BY ' + QUOTENAME(@SortBy) + ' ' + @SortDirection;

		EXEC sp_executesql @SqlQuery, 
        N'@FilterValue NVARCHAR(50)', 
        @FilterValue = @FilterValue;
END