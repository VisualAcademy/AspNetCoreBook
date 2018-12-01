CREATE TABLE [dbo].[SupportRegistrations]
(
    [Id] INT Identity(1, 1) NOT NULL PRIMARY KEY,	-- 일련번호

    [SupportSettingId] Int Null,					-- SupportSettings.Id

    BoardName		NVarChar(50) Null,	-- 게시판이름(확장): Notice, Free, Qna
    BoardNum		Int Null,			-- 해당 게시판의 게시물 번호
    BoardTitle		NVarChar(150) Null,	-- 게시판 제목(이벤트 제목)

    CreationDate	DateTimeOffset(7) Default(GetDate()),	-- 생성일 

    UserId			Int				Null,		-- 사용자 Id
    Username		NVarChar(25) Not Null,		-- 사용자 아이디
    NickName		NVarChar(100) Null,			-- 닉네임 

    
    Name			NVarChar(25) Null,			-- 대표자 이름
    Mobile			NVarchar(25) Null,			-- 연락처
    Company			NVarChar(100) Null,			-- 단체명
    Homepage		NVarChar(255) Null,			-- 홈페이지
    SupportDate		NVarChar(255)	Null,		-- 일자 및 시간 
    Recipient		NVarChar(100) Null,			-- 받는 사람
    Product			NVarChar(Max) Null			-- 등록 물품
)
Go
