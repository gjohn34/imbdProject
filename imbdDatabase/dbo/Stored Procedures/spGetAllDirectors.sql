CREATE PROCEDURE [dbo].[spGetAllDirectors]
AS
BEGIN
	set nocount on;
	select [d].[Id], [d].[FirstName], [d].[LastName], [d].[CreatedAt], [d].[UpdatedAt], 
	[m].[Id], [m].[Title], [m].[ReleaseYear], [m].[CreatedAt], [m].[UpdatedAt] 
	from dbo.Directors as d LEFT JOIN dbo.Movies as m ON d.Id = m.DirectorId
END