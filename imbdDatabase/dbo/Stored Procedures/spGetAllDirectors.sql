CREATE PROCEDURE [dbo].[spGetAllDirectors]
AS
BEGIN
	set nocount on;
	SELECT * from dbo.Directors;
END