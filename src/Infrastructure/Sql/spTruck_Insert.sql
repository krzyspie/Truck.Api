USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_Insert]
	@Code NVARCHAR(7),
	@Name NVARCHAR(20),
	@Status NVARCHAR(20),
	@Description NVARCHAR(160) = NULL
AS
BEGIN
	INSERT INTO dbo.[Trucks] (Code, Name, Status, Description, DateCreated)
	OUTPUT INSERTED.Id 
	VALUES (@Code, @Name, @Status, @Description, GETDATE());
END