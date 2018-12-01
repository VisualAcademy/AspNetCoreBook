--[6] 상세 저장 프로시저 : ViewScheduleByCommunity
Create Proc dbo.ViewScheduleByCommunity
	@CommunityName VarChar(25),
	@Num Int
As
	Select * From ScheduleByCommunity Where CommunityName = @CommunityName And Num = @Num
Go