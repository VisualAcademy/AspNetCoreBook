-- 월별, 커뮤니티별 일정 리스트 출력
Create Proc dbo.GetScheduleByCommunityByMonthly
	@CommunityName VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt
As
	Select [Num], [CommunityName], [SYear], [SMonth], [SDay], [SHour], [Title], [Content], [PostDate] From ScheduleByCommunity 
	Where CommunityName = @CommunityName And SYear = @SYear And SMonth = @SMonth
Go
