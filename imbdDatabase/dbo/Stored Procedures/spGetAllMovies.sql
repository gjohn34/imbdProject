CREATE PROCEDURE [dbo].[spGetAllMovies]
AS
BEGIN
	set nocount on;
	SELECT m.Id, m.Title, m.ReleaseYear, m.CreatedAt, m.UpdatedAt, m.DirectorId, d.Id, d.FirstName, d.LastName 
	from dbo.Movies as m 
	INNER JOIN dbo.Directors as d ON m.DirectorId = d.Id
END
