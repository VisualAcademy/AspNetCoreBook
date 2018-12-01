-- 댓글 테이블 생성
CREATE TABLE [dbo].[CongressesComments]
(
    Id          Int Identity(1, 1) 
                Not Null Primary Key,               -- 일련번호
    ArticleId   Int Not Null,                       -- 해당 게시판의 게시물 번호(BoardId)
    Name        NVarChar(25) Not Null,              -- 작성자
    Opinion     NVarChar(4000) Not Null,            -- 댓글 내용
    PostDate    DATETIME Default(GetDate()),        -- 작성일

    BoardName   NVarChar(50) Null,                  -- 게시판이름(확장): Notice, Free, Photo, Data
    Password    NVarChar(255) Not Null,             -- 댓글 삭제용 암호

    Num             Int Null,                       -- 번호(확장...)
    UserId          Int Null,                       -- (확장...) 사용자 테이블 Id
    CategoryId      Int Null Default 0,             -- (확장...) 카테고리 테이블 Id
    BoardId         Int Null Default 0,             -- (확장...) 게시판(Boards) 테이블 Id
    AplicationId    Int Null Default 0              -- (확장용) 응용 프로그램 Id
)
Go
