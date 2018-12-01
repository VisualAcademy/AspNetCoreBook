--[7] 수정 : ModifyScheduleByDomain
Create Proc dbo.ModifyScheduleByDomain
	@UserID VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt,
	@SHour SmallInt,
	@Title VarChar(150),
	@Content VarChar(8000),
	@Num Int
As
	Update ScheduleByDomain
	Set
		SYear = @SYear, SMonth = @SMonth,
		SDay = @SDay, SHour = @SHour,
		Title = @Title, Content = @Content
	Where UserID = @UserID And Num = @Num
Go
