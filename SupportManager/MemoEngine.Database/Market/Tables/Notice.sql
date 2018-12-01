-- 공지사항 테이블 생성
Create Table dbo.Notice
(
	Num Int Identity(1, 1) Primary Key,
	UserID NVarChar(25) Not Null, -- admin, red, ...
	Title NVarChar(150) Not Null,
	Content NVarChar(4000) Not Null,
	PostDate SmallDateTime Default(GetDate())	
)
Go

Create Proc dbo.WriteNotice
	@UserID NVarChar(25),
	@Title NVarChar(150),
	@Content NVarChar(4000)	
As
	Insert Into Notice(UserID, Title, Content)
	Values(@UserID, @Title, @Content)
Go

Create Proc dbo.ListNotice
As
	Select * From Notice Order By Num Desc
Go

Create Proc dbo.ViewNotice
	@Num Int
As
	Select * From Notice Where Num = @Num
Go

Create Proc dbo.ModifyNotice
(
	@Title NVarChar(150),
	@Content NVarChar(4000),
	@Num Int
)
As
	Update Notice
	Set Title = @Title, Content = @Content
	Where Num = @Num
Go

Create Proc dbo.DeleteNotice
	@Num Int
As
	Delete Notice Where Num = @Num
Go

Create Proc dbo.SearchNotice
	@SearchField NVarChar(10),
	@SearchQuery NVarChar(25)	
As
	Set @SearchQuery = '%' + @SearchQuery + '%'
	
	Select * From Notice 
	Where 
		Case @SearchField
			When 'Title' Then Title 
			When 'Content' Then Content 
			Else
				@SearchQuery
			End
		Like 		
			@SearchQuery
	Order By Num Desc
Go








