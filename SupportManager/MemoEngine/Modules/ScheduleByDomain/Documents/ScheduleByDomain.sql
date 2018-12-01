--[1] 스케줄 테이블(공통)
CREATE TABLE dbo.ScheduleByDomain 
(
	[Num] [Int] IDENTITY (1, 1) NOT NULL Primary Key,	--일련번호

	[UserID] VarChar(25), -- 사용자 ID/그룹 ID ==> DomainID

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

--[2] 일정 입력
Insert Into ScheduleByDomain
Values('RedPlus', 2007, 7, 23, 16, '스케줄 테스트', '스케줄 테스트', GetDate())
Go

--[3] 일정 출력
Select * From ScheduleByDomain 
Where UserID = 'RedPlus' And SYear = '2007' And SMonth = '7' And SDay = '23'
Go

--[4] 일정 입력 저장 프로시저 : AddScheduleByDomain
Create Procedure dbo.AddScheduleByDomain
	@UserID VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt,
	@SHour SmallInt,
	@Title VarChar(150),
	@Content VarChar(8000)
As
	Insert Into ScheduleByDomain
	Values
	(
		@UserID, @SYear, @SMonth, @SDay, @SHour, @Title, @Content, GetDate()
	)
Go

--[5] 일정 출력 저장 프로시저 : GetScheduleByDomain
Create Proc dbo.GetScheduleByDomain
	@UserID VarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt
As
	Select * From ScheduleByDomain 
	Where UserID = @UserID And SYear = @SYear And SMonth = @SMonth And SDay = @SDay
Go

--[6] 상세 저장 프로시저 : ViewScheduleByDomain
Create Proc dbo.ViewScheduleByDomain
	@UserID VarChar(25),
	@Num Int
As
	Select * From ScheduleByDomain Where UserID = @UserID And Num = @Num
Go

--[7] 수정 : ModifyScheduleByDomain
Create Proc dbo.ModifyScheduleByDomain
	@UserID VarChar(25),
	@SYear Int,
	@SMonth Int,
	@SDay Int,
	@SHour Int,
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

--[8] 삭제 : DeleteScheduleByDomain
Create Proc dbo.DeleteScheduleByDomain
	@UserID VarChar(25),
	@Num Int
As
	Delete ScheduleByDomain Where UserID = @UserID And Num = @Num
Go
