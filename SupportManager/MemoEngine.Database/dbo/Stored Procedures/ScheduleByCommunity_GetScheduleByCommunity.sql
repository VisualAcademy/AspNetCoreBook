--[5] 일정 출력(리스트) 저장 프로시저 : GetScheduleByCommunity
Create Proc dbo.GetScheduleByCommunity
	@CommunityName VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt
As
	Select [Num], [CommunityName], [SYear], [SMonth], [SDay], [SHour], [Title], [PostDate] 
	From ScheduleByCommunity 
	Where CommunityName = @CommunityName And SYear = @SYear And SMonth = @SMonth And SDay = @SDay
Go
