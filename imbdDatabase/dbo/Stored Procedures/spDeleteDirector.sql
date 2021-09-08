CREATE PROCEDURE [dbo].[spDeleteDirector]
	@Id int = 0
AS
BEGIN
	set nocount on;
	DELETE FROM dbo.Movies
	WHERE DirectorId = @Id;

	DELETE FROM dbo.Directors
	WHERE Id = @Id;
END
