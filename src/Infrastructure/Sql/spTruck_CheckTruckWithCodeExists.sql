USE TrucksDb
GO

CREATE PROCEDURE [dbo].[spTruck_CheckTruckWithCodeExists]
	@Code NVARCHAR(7)
AS
BEGIN
    DECLARE @CodeExists BIT;

    IF EXISTS (SELECT 1 FROM dbo.[Trucks] WHERE Code = @Code)
        SET @CodeExists = 1;
    ELSE
        SET @CodeExists = 0;

    SELECT @CodeExists;
END