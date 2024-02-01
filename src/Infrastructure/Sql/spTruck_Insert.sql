USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_Insert]
	@Code NVARCHAR(7),
	@Name NVARCHAR(20),
	@Status TINYINT,
	@Description NVARCHAR(160)
AS
BEGIN
	INSERT INTO dbo.[Trucks] (Code, Name, Status, Description, DateCreated)
	VALUES (@Code, @Name, @Status, @Description, GETDATE())
END

