-- 카테고리별, 부모Id별 일정 관리

--[1] 스케줄 테이블(공통)
CREATE TABLE dbo.ScheduleById 
(
	[Num] [Int] IDENTITY (1, 1) NOT NULL Primary Key,	--일련번호

	[CategoryName] NVarChar(25) Not Null, -- 사용자 ID/그룹 ID ==> CategoryID

	[SYear] [SmallInt] NOT NULL ,						--년
	[SMonth] [SmallInt] NOT NULL ,						--월
	[SDay] [SmallInt] NOT NULL ,						--일
	[SHour] [SmallInt] NOT NULL ,						--시
	[SMinute] [SmallInt] NULL,						--분

	[Title] [NVarChar] (150) NOT NULL ,					--일정제목
	[Content] NTEXT NULL ,					--일정내용
	[PostDate] [SmallDateTime] NULL, 					--등록일

	[Icon] NVarChar(10) NULL, 						-- 아이콘 표시 예비 필드

	[ParentId] [Int] NULL 							-- 부모 항목의 Id 필드(외래키)
)
Go

--[2] 일정 입력 저장 프로시저 : AddScheduleById
Create Procedure dbo.AddScheduleById
	@CategoryName NVarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt,
	@SHour SmallInt,
	@Title NVarChar(150),
	@Content NVarChar(4000),
	@SMinute SmallInt,
	@Icon NVarChar(10),
	@ParentId Int
As
	Insert Into ScheduleById (CategoryName, SYear, SMonth, SDay, SHour, SMinute, Title, Content, PostDate, Icon, ParentId)
	Values
	(
		@CategoryName, @SYear, @SMonth, @SDay, @SHour, @SMinute, @Title, @Content, GetDate(), @Icon, @ParentId
	)
Go

--[3] 일정 출력 저장 프로시저 : GetScheduleById
Create Proc dbo.GetScheduleById
	@CategoryName NVarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt
As
	Select [Num], [CategoryName], [SYear], [SMonth], [SDay], [SHour], [SMinute], [Title], [Content], [PostDate], [Icon], [ParentId] From ScheduleById 
	Where CategoryName = @CategoryName And SYear = @SYear And SMonth = @SMonth And SDay = @SDay
	Order By CAST(CAST(SYear AS VARCHAR) + '-' + CAST(SMonth AS VARCHAR) + '-' + CAST(SDay AS VARCHAR) AS DATETIME) Asc
Go

--[4] 상세 저장 프로시저 : ViewScheduleById
Create Proc dbo.ViewScheduleById
	@CategoryName NVarChar(25),
	@Num Int
As
	Select [Num], [CategoryName], [SYear], [SMonth], [SDay], [SHour], [SMinute], [Title], [Content], [PostDate], [Icon], [ParentId] From ScheduleById Where CategoryName = @CategoryName And Num = @Num
Go

--[5] 수정 : ModifyScheduleById
Create Proc dbo.ModifyScheduleById
	@CategoryName NVarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt,
	@SDay SmallInt,
	@SHour SmallInt,
	@Title NVarChar(150),
	@Content NVarChar(4000),
	@Num Int
As
	Update ScheduleById
	Set
		SYear = @SYear, SMonth = @SMonth,
		SDay = @SDay, SHour = @SHour,
		Title = @Title, Content = @Content
	Where CategoryName = @CategoryName And Num = @Num
Go

--[6] 삭제 : DeleteScheduleById
Create Proc dbo.DeleteScheduleById
	@CategoryName NVarChar(25),
	@Num Int
As
	Delete ScheduleById Where CategoryName = @CategoryName And Num = @Num
Go

--[7] 월별, 커뮤니티별 일정 리스트 출력
Create Proc dbo.GetScheduleByIdByMonthly
	@CategoryName NVarChar(25),
	@SYear SmallInt,
	@SMonth SmallInt
As
	Select [Num], [CategoryName], [SYear], [SMonth], [SDay], [SHour], [SMinute], [Title], [Content], [PostDate], [Icon], [ParentId] From ScheduleById 
	Where CategoryName = @CategoryName And SYear = @SYear And SMonth = @SMonth
Go

--[8] 이번 주 일정 리스트 출력
Create Proc dbo.GetScheduleByIdByCurrentWeek
	@CategoryName NVarChar(25)
As
	Select [Num], [CategoryName], [SYear], [SMonth], [SDay], [SHour], [SMinute], [Title], [Content], [PostDate], [Icon], [ParentId] From ScheduleById 
	Where CategoryName = @CategoryName And CAST(CAST(SYear AS VARCHAR) + '-' + CAST(SMonth AS VARCHAR) + '-' + CAST(SDay AS VARCHAR) AS DATETIME) > DateAdd(day, -5, GetDate()) And CAST(CAST(SYear AS VARCHAR) + '-' + CAST(SMonth AS VARCHAR) + '-' + CAST(SDay AS VARCHAR) AS DATETIME) < DateAdd(day, 9, GetDate())
	Order By CAST(CAST(SYear AS VARCHAR) + '-' + CAST(SMonth AS VARCHAR) + '-' + CAST(SDay AS VARCHAR) AS DATETIME) Asc
Go
