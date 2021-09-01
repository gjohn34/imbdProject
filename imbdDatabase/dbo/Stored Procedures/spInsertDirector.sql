CREATE PROCEDURE [dbo].[spInsertDirector]
	@Id int output,
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@CreatedAt datetime2,
	@UpdatedAt datetime2
AS
BEGIN
	set nocount on;
	INSERT into dbo.Directors (FirstName, LastName, CreatedAt, UpdatedAt)
	VALUES (@FirstName, @LastName, @CreatedAt, @UpdatedAt);
	select @Id = SCOPE_IDENTITY();
END