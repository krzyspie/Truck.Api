USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_GetById]
	@Id INT
AS
BEGIN
	SELECT * FROM dbo.[Trucks] WHERE Id = @Id;
END

