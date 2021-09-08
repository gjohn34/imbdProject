CREATE PROCEDURE [dbo].[spUpdateMovie]
	@Id int,
	@DirectorId int,
	@Title nvarchar(50),
	@ReleaseYear int
AS
BEGIN
	set nocount on;
	UPDATE dbo.Movies
	SET 
	Title = CASE @Title WHEN '' THEN Title ELSE @Title END,
	ReleaseYear = CASE @ReleaseYear WHEN 0 THEN ReleaseYear ELSE @ReleaseYear END,
	DirectorId = CASE @DirectorId WHEN 0 THEN DirectorId ELSE @DirectorId END
	WHERE Id = @Id;
END
