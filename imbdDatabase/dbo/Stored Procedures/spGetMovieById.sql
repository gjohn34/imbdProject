CREATE PROCEDURE [dbo].[spGetMovieById]
	@Id int
AS
BEGIN
	set nocount on;

	select 
	[d].[Id], [d].[FirstName], [d].[LastName], [d].[CreatedAt], [d].[UpdatedAt], 
	[m].[Id], [m].[Title], [m].[ReleaseYear], [m].[CreatedAt], [m].[UpdatedAt] 
	from dbo.Directors as d Inner join dbo.Movies as m On m.DirectorId = d.Id AND d.Id = @Id;
END