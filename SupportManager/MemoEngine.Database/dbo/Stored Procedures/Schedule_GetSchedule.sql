--[5] 일정 출력 저장 프로시저 : GetSchedule
Create Proc dbo.GetSchedule
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt
As
	Select [Num], [SYear], [SMonth], [SDay], [SHour], [Title], [Content], [PostDate] From Schedule 
	Where SYear = @SYear And SMonth = @SMonth And SDay = @SDay
Go
