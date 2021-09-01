CREATE PROCEDURE [dbo].[spInsertMovie]
	@Id int output,
	@DirectorId int,
	@Title nvarchar(50),
	@ReleaseYear int,
	@CreatedAt datetime2,
	@UpdatedAt datetime2
AS
BEGIN
	set nocount on;
	insert into dbo.Movies (Title, DirectorId, ReleaseYear, CreatedAt, UpdatedAt)
	values (@Title, @DirectorId, @ReleaseYear, @CreatedAt, @UpdatedAt);

	select @Id = SCOPE_IDENTITY();
END
