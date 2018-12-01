--[3] 현재 접속자에 대한 모든 정보를 출력 : GetUser : UserInfor.aspx에서 사용
Create Proc dbo.GetUser
    @DomainID NVarChar(30)
As
    Select 
		[UID], [DomainID], [Name], [CreatedDate], [Password], [Email], 
		[LastLoginDate], [LastLoginIP], [VisitedCount], [Description], 
		[Blocked], [Type], [PhoneNumber], [Address], [Gender], 
		[BirthDate], [Country] 
	From Users 
	Where DomainID = @DomainID
Go
