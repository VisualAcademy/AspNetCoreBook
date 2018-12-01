--[8] 삭제 : DeleteScheduleByCommunity
Create Proc dbo.DeleteScheduleByCommunity
	@CommunityName VarChar(25),
	@Num Int
As
	Delete ScheduleByCommunity Where CommunityName = @CommunityName And Num = @Num
Go
