-- 커뮤니티(Communities 테이블)별 일정 관리: GOT7, 2PM, 2AM에 따른 일정 관리 모듈

--[1] 스케줄 테이블(공통)
CREATE TABLE dbo.ScheduleByCommunity 
(
	[Num] [Int] IDENTITY (1, 1) NOT NULL Primary Key,	--일련번호

	[CommunityName] VarChar(25), -- 사용자 ID/그룹 ID ==> CommunityID

	[SYear] [SmallInt] NOT NULL ,						--년
	[SMonth] [SmallInt] NOT NULL ,						--월
	[SDay] [SmallInt] NOT NULL ,						--일
	[SHour] [SmallInt] NOT NULL ,						--시
	[Title] [VarChar] (150) NOT NULL ,					--일정제목
	[Content] [Text] NULL ,								--일정내용
	[PostDate] [SmallDateTime] NULL 					--등록일
	-- 추가 기능은 필드로...
)
Go

----[2] 일정 입력
--Insert Into ScheduleByCommunity
--Values('RedPlus', 2007, 7, 23, 16, '스케줄 테스트', '스케줄 테스트', GetDate())
--Go

----[3] 일정 출력
--Select * From ScheduleByCommunity 
--Where CommunityName = 'RedPlus' And SYear = '2007' And SMonth = '7' And SDay = '23'
--Go

--[4] 일정 입력 저장 프로시저 : AddScheduleByCommunity
Create Procedure dbo.AddScheduleByCommunity
	@CommunityName VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt,
	@SHour SmallInt,
	@Title VarChar(150),
	@Content VarChar(8000)
As
	Insert Into ScheduleByCommunity
	Values
	(
		@CommunityName, @SYear, @SMonth, @SDay, @SHour, @Title, @Content, GetDate()
	)
Go

--[5] 일정 출력 저장 프로시저 : GetScheduleByCommunity
Create Proc dbo.GetScheduleByCommunity
	@CommunityName VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt
As
	Select * From ScheduleByCommunity 
	Where CommunityName = @CommunityName And SYear = @SYear And SMonth = @SMonth And SDay = @SDay
Go

--[6] 상세 저장 프로시저 : ViewScheduleByCommunity
Create Proc dbo.ViewScheduleByCommunity
	@CommunityName VarChar(25),
	@Num Int
As
	Select * From ScheduleByCommunity Where CommunityName = @CommunityName And Num = @Num
Go

--[7] 수정 : ModifyScheduleByCommunity
Create Proc dbo.ModifyScheduleByCommunity
	@CommunityName VarChar(25),
	@SYear Int,
	@SMonth Int,
	@SDay Int,
	@SHour Int,
	@Title VarChar(150),
	@Content VarChar(8000),
	@Num Int
As
	Update ScheduleByCommunity
	Set
		SYear = @SYear, SMonth = @SMonth,
		SDay = @SDay, SHour = @SHour,
		Title = @Title, Content = @Content
	Where CommunityName = @CommunityName And Num = @Num
Go

--[8] 삭제 : DeleteScheduleByCommunity
Create Proc dbo.DeleteScheduleByCommunity
	@CommunityName VarChar(25),
	@Num Int
As
	Delete ScheduleByCommunity Where CommunityName = @CommunityName And Num = @Num
Go

-- 월별, 커뮤니티별 일정 리스트 출력
Create Proc dbo.GetScheduleByCommunityByMonthly
	@CommunityName VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt
As
	Select * From ScheduleByCommunity 
	Where CommunityName = @CommunityName And SYear = @SYear And SMonth = @SMonth
Go

-- GetScheduleByCommunityByMonthly 'devlec', 2014, 10
