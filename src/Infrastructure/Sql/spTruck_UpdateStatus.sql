USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_UpdateStatus]
	@Id INT,
	@Status NVARCHAR(20)
AS
BEGIN
	UPDATE dbo.[Trucks]
	SET Status = @Status, DateModified = GETDATE()
	WHERE Id = @Id
END
