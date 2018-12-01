--[4] 일정 입력 저장 프로시저 : AddSchedule
Create Procedure dbo.AddSchedule
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt,
	@SHour SmallInt,
	@Title NVarChar(150),
	@Content NVarChar(4000)
As
	Insert Into Schedule
	Values
	(
		@SYear, @SMonth, @SDay, @SHour, @Title, @Content, GetDate()
	)
Go