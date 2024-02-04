USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_Update]
	@Id INT,
	@Code NVARCHAR(7),
	@Name NVARCHAR(20),
	@Status NVARCHAR(20),
	@Description NVARCHAR(255) = NULL
AS
BEGIN
	UPDATE dbo.[Trucks]
	SET Code = @Code, Name = @Name, Status = @Status, Description = @Description, DateModified = GETDATE()
	WHERE Id = @Id
END
