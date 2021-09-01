CREATE PROCEDURE [dbo].[spGetMovieById]
	@Id int
AS
BEGIN
	set nocount on;
	SELECT * FROM dbo.Movies
	WHERE @Id = Id
END