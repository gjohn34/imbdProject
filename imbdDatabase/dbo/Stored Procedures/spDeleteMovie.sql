CREATE PROCEDURE [dbo].[spDeleteMovie]
	@Id int
AS
BEGIN
	set nocount on;
	DELETE FROM dbo.Movies WHERE Id = @Id;
END
