CREATE PROCEDURE [dbo].[spGetAllMovies]
AS
BEGIN
	set nocount on;
	SELECT * FROM dbo.Movies
END
