USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_Delete]
	@Id INT
AS
BEGIN
	DELETE FROM dbo.[Truck] WHERE Id = @Id;
END

