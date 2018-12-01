--[1] 스케줄 테이블(공통)
CREATE TABLE dbo.Schedule 
(
	[Num] [Int] IDENTITY (1, 1) NOT NULL Primary Key,	--일련번호
	[SYear] [SmallInt] NOT NULL ,						--년
	[SMonth] [SmallInt] NOT NULL ,						--월
	[SDay] [SmallInt] NOT NULL ,						--일
	[SHour] [SmallInt] NOT NULL ,						--시
	[Title] [NVarChar] (150) NOT NULL ,					--일정제목
	[Content] [Text] NULL ,								--일정내용
	[PostDate] [SmallDateTime] NULL 					--등록일
	-- 추가 기능은 필드로...
)
Go

--[2] 일정 입력
--Insert Into Schedule
--Values(2014, 8, 15, 07, '스케줄 테스트', '스케줄 테스트', GetDate())
--Go

--[3] 일정 출력
--Select * From Schedule 
--Where SYear = '2007' And SMonth = '7' And SDay = '23'
--Go

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

--[5] 일정 출력 저장 프로시저 : GetSchedule
Create Proc dbo.GetSchedule
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt
As
	Select * From Schedule 
	Where SYear = @SYear And SMonth = @SMonth And SDay = @SDay
Go

--[6] 상세 저장 프로시저 : ViewSchedule
Create Proc dbo.ViewSchedule
	@Num Int
As
	Select * From Schedule Where Num = @Num
Go

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

--[8] 삭제 : DeleteSchedule
Create Proc dbo.DeleteSchedule
	@Num Int
As
	Delete Schedule Where Num = @Num
Go
