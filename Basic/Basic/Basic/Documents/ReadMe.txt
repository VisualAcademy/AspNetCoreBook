게시판 만들기
	인터넷 상에서 간단히 글을 남기고 볼 수 있는 응용 프로그램

주요 기능
	입력
	출력
	상세
	수정
	삭제
	검색


데모
	입력~검색

설계
	DB : Basic,
	테이블:  Basics
	저장프로시저: 6개 SP

구현
	웹 프로젝트 : 
		C:\ASP.NET\Basic\
		C:\ASP.NET\Basic\Basic\...
			Default.aspx
			Write.aspx
			List.aspx
			View.aspx?Id={0}
			Modify.aspx?Id={0}
			Delete.aspx?Id={0}
			Search.aspx?SearchField={0}&SearchQuery={1}
			
		C:\ASP.NET\Basic\Basic\Documents\Basic.sql
		

배포
	http://www.memoengine.com/Basic/List.aspx : 기본형 게시판 출력
