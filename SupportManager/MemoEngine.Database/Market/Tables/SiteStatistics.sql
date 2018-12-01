--[0] 접속 통계용 테이블 설계
--Drop Table dbo.SiteStatistics
Create Table dbo.SiteStatistics
(
	RecordID Int Identity(1, 1) Primary Key Not Null, 	-- 일련번호
	--
	HitYear SmallInt Default( DatePart(Year, GetDate()) ), 	-- 년도
	HitMonth TinyInt Default( Month( GetDate() ) ),		-- 월
	HitDay TinyInt Default( DatePart(Day, GetDate()) ),		-- 일
	HitWeekDay TinyInt Default( DatePart(WeekDay, GetDate()) ), --요일
	HitHour TinyInt Default( DatePart(Hour, GetDate()) ), 	-- 시
	HitCount Int Default(1),	-- 카운트
	-- 
	CreatedDate SmallDateTime Default(GetDate())	-- 레코드 생성일
)
Go

----[1] 날짜/시간 연습
--Select GetDate()				-- 전체 시간
--Select Year(GetDate())			-- 년도
--Select DatePart(Year, GetDate())
--Select DatePart(yyyy, GetDate())
--Select Month(GetDate())
--Select DatePart(mm, GetDate())

----[2] 한 명의 사용자가 방문할 때 : 현재 시간에 처음 접속할 때
--Insert SiteStatistics Default Values
--Go

----Select * From SiteStatistics
----Go

----[3] 한 명의 사용자가 방문할 때 : 현재 시간에 처음 이후로 접속할 때
--Update SiteStatistics
--Set
--	HitCount = HitCount + 1
--Where
--	HitYear = Year(GetDate())
--	And
--	HitMonth = Month(GetDate())
--	And
--	HitDay = Day(GetDate())
--	And
--	HitHour = DatePart(hh, GetDate())
--Go

----[4] 총 방문자 계산
----Select * From SiteStatistics Order By RecordID Desc
--Select Sum(HitCount) From SiteStatistics
--Go

----[5] 오늘 방문자 수 계산
--Select Sum(HitCount) From SiteStatistics
--Where 
--	HitYear = Year(GetDate())
--	And
--	HitMonth = Month(GetDate())
--	And
--	HitDay = DatePart(dd, GetDate())
--Go

----[6] 오늘 오전 10시 방문자 수 계산
--Select Sum(HitCount) From SiteStatistics
--Where 
--	HitYear = Year(GetDate())
--	And
--	HitMonth = Month(GetDate())
--	And
--	HitDay = DatePart(dd, GetDate())
--	And
--	HitHour = 10
--Go

----[7] 이번달 방문자 수 계산
--Select Sum(HitCount) From SiteStatistics
--Where 
--	HitYear = Year(GetDate())
--	And
--	HitMonth = Month(GetDate())
--Go

----[8] 올해 방문자 수 계산
--Select Sum(HitCount) From SiteStatistics
--Where 
--	HitYear = Year(GetDate())
--Go

----[9] 이번달 중에서 며칠에 가장 많이 들어왔는지???
----이번달 가장 많은 방문자 수(최고 히팅 수)를 기록한 일자와 히팅수를 출력하는 쿼리문
----	- 일별 접속현황을 가져온다.
----	- 일자별 시간 접속을 묶는다.
----	- 최고 방문수(어사 아님) 레코드를 가져온다.
--Select Top 1 HitYear, HitMonth, HitDay, Sum(HitCount) As MaxCount  
--From SiteStatistics 
--Group By HitYear, HitMonth, HitDay 
--Having HitYear=Year(GetDate()) And HitMonth=Month(GetDate()) 
--Order By Sum(HitCount) Desc

----[10] 이번달 가장 많은 방문자 수를 기록한 시간대를 출력하는 쿼리문
--Select Top 1 Sum(HitCount) As MaxCount, HitYear, HitMonth, HitHour 
--From SiteStatistics 
--Group By HitHour, HitYear, HitMonth
--Having HitYear=Year(GetDate()) And HitMonth=Month(GetDate())  
--Order By Sum(HitCount) Desc

----[11] 이번달 가장 많은 방문자 수를 기록한 요일을 출력하는 쿼리문
--Select Top 1 Sum(HitCount) As MaxWeek, HitYear, HitMonth, HitWeekDay 
--From SiteStatistics 
--Group By HitWeekDay, HitYear, HitMonth 
--Having HitYear=Year(GetDate()) And HitMonth=Month(GetDate()) 
--Order By Sum(HitCount) Desc 

----[12] 이번달의 요일별 카운트 통계를 출력하는 쿼리문
--Select Sum(HitCount) As WeekCount, HitYear, HitMonth, HitWeekDay 
--From SiteStatistics 
--Group By HitYear, HitMonth, HitWeekDay
--Having HitYear=Year(GetDate()) And HitMonth=Month(GetDate()) 
--Order By HitWeekDay
--Go

--[!] 카운트 증가 저장 프로시저 : Global.asax Session_Start 이벤트에서 사용
Create Procedure dbo.AddCounter
As
	Declare @Counter Int
	Select @Counter = Sum(HitCount) From SiteStatistics
	Where
		HitYear = Year(GetDate()) And
		HitMonth = Month(GetDate()) And
		HitDay = Day(GetDate()) And
		HitHour = DatePart(hh, GetDate())

	If @Counter Is NULL -- 현재시간에 해당되는 카운트가 없으면 입력
		Insert SiteStatistics Default Values
	Else	-- 기존에 입력된 자료가 있으면 업데이트
		Update SiteStatistics
		Set
			HitCount = HitCount + 1
		Where
			HitYear = Year(GetDate()) And
			HitMonth = Month(GetDate()) And
			HitDay = Day(GetDate()) And
			HitHour = DatePart(hh, GetDate())
Go

--[!] 총 방문자 계산 저장 프로시저
--Select * From SiteStatistics Order By RecordID Desc
Create Proc dbo.GetTotalVisit
As
	Select Sum(HitCount) From SiteStatistics
Go

--[!] 오늘 방문자 수 계산 저장 프로시저
Create Proc dbo.GetTodayVisit
As
	Select Sum(HitCount) From SiteStatistics
	Where 
		HitYear = Year(GetDate())
		And
		HitMonth = Month(GetDate())
		And
		HitDay = DatePart(dd, GetDate())
Go