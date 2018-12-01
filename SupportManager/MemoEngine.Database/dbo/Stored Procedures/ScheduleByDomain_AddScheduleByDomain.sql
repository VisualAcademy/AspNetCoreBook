
--[4] 일정 입력 저장 프로시저 : AddScheduleByDomain
Create Procedure dbo.AddScheduleByDomain
	@UserID VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt,
	@SHour SmallInt,
	@Title VarChar(150),
	@Content VarChar(8000)
As
	Insert Into ScheduleByDomain
	Values
	(
		@UserID, @SYear, @SMonth, @SDay, @SHour, @Title, @Content, GetDate()
	)
Go
