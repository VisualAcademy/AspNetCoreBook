--[7] 수정 : ModifySchedule
Create Proc dbo.ModifySchedule
	@SYear Int,
	@SMonth Int,
	@SDay Int,
	@SHour Int,
	@Title NVarChar(150),
	@Content NVarChar(4000),
	@Num Int
As
	Update Schedule
	Set
		SYear = @SYear, SMonth = @SMonth,
		SDay = @SDay, SHour = @SHour,
		Title = @Title, Content = @Content
	Where Num = @Num
Go
