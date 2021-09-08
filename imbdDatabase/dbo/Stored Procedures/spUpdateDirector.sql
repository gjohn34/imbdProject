CREATE PROCEDURE [dbo].[spUpdateDirector]
	@Id int,
	@FirstName nvarchar(20),
	@LastName nvarchar(20)
AS
BEGIN
	UPDATE dbo.Directors
	SET 
	FirstName = CASE WHEN @FirstName = '' THEN FirstName ELSE @FirstName END,
	LastName = CASE WHEN @LastName = '' THEN FirstName ELSE @LastName END,
	UpdatedAt = getutcdate()
	WHERE Id = @Id;
END