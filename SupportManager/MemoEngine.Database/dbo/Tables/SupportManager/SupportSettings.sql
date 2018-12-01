CREATE TABLE [dbo].[SupportSettings]
(
	-- 기본 정보
    Id				Int Identity(1, 1) Not Null Primary Key,
    Remarks			NVarChar(Max) Null,						-- 비고
    CreationDate	DateTimeOffset(7) Default(GetDate()),	-- 생성일 

	-- 부모 테이블 정보
    BoardName		NVarChar(50) Null,		-- 게시판이름(확장) : Notice, Free, Qna
    BoardNum		Int Not Null,			-- 해당 게시판의 게시물 번호
    BoardTitle		NVarChar(150) Null,		-- 게시판 제목(이벤트 제목)
    BoardContent	NVarChar(Max) Null,		-- 내용 복사
                 
	-- 설정 정보
    StartDate		SmallDateTime Null,		-- 시작일
    EventDate		SmallDateTime Null,		-- 등록 시점: 1월 1일 0시 0분으로 설정하면 이 시간 이후로부터 Insert 되도록 
    EndDate			SmallDateTime Null,		-- 종료일
    MaxCount		Int Default(1000),		-- 등록자 수 : 1000명으로 등록자 수 제한	
    IsClosed		BIT NULL DEFAULT 0		-- 이벤트 종료	
)
Go
