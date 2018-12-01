--[1] 스케줄 테이블(공통)
CREATE TABLE dbo.ScheduleByCommunity 
(
	[Num] [Int] IDENTITY (1, 1) NOT NULL Primary Key,	--일련번호

	[CommunityName] NVarChar(25) Not Null, -- 사용자 ID/그룹 ID ==> CommunityID

	[SYear] [SmallInt] NOT NULL ,						--년
	[SMonth] [SmallInt] NOT NULL ,						--월
	[SDay] [SmallInt] NOT NULL ,						--일
	[SHour] [SmallInt] NOT NULL ,						--시
	[Title] [VarChar] (150) NOT NULL ,					--일정제목
	[Content] [NText] NULL ,								--일정내용
	[PostDate] [SmallDateTime] NULL 					--등록일
	-- 추가 기능은 필드로...
)
Go