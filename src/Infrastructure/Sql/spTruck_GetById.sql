USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_GetById]
	@Id INT
AS
BEGIN
	SELECT Id, Code, Name, Status, Description, DateCreated, DateModified
	FROM dbo.[Trucks] 
	WHERE Id = @Id;
END