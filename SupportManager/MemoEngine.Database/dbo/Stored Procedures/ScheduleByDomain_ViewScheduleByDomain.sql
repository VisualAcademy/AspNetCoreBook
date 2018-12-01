--[6] 상세 저장 프로시저 : ViewScheduleByDomain
Create Proc dbo.ViewScheduleByDomain
	@UserID VarChar(25),
	@Num Int
As
	Select [Num], [UserID], [SYear], [SMonth], [SDay], [SHour], [Title], [Content], [PostDate] 
	From ScheduleByDomain 
	Where UserID = @UserID And Num = @Num
Go
