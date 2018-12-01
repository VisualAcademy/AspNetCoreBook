--[7] 수정 : ModifyScheduleByCommunity
Create Proc dbo.ModifyScheduleByCommunity
	@CommunityName NVarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt,
	@SHour SmallInt,
	@Title NVarChar(150),
	@Content NVarChar(4000),
	@Num Int
As
	Update ScheduleByCommunity
	Set
		SYear = @SYear, SMonth = @SMonth,
		SDay = @SDay, SHour = @SHour,
		Title = @Title, Content = @Content
	Where CommunityName = @CommunityName And Num = @Num
Go
