--[5] 일정 출력 저장 프로시저 : GetScheduleByDomain
Create Proc dbo.GetScheduleByDomain
	@UserID VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt
As
	Select [Num], [UserID], [SYear], [SMonth], [SDay], [SHour], [Title], [PostDate] 
	From ScheduleByDomain 
	Where UserID = @UserID And SYear = @SYear And SMonth = @SMonth And SDay = @SDay
Go
