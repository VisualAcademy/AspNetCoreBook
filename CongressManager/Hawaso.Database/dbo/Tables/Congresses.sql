-- 게시판용 테이블 설계 
CREATE TABLE [dbo].[Congresses]
(
    [Id]            INT NOT NULL PRIMARY KEY Identity(1, 1),    -- 일련번호

    -- 5W1H
    Name            NVarChar(25) Not Null,                      -- 이름
    PostDate        DateTime Default GetDate() Not Null,        -- 작성일 
    PostIp          NVarChar(15) Null,                          -- 작성IP
    Title           NVarChar(150) Not Null,                     -- 제목
    Content         NText Not Null,                             -- 내용
    Category        NVarChar(20) Default('Free') Null,          -- 카테고리(확장...) => '공지', '자유', '자료', '사진', ...

    Email           NVarChar(100) Null,                         -- 이메일 
    Password        NVarChar(255) Null,                         -- 비밀번호
    ReadCount       Int Default 0,                              -- 조회수
    Encoding        NVarChar(10) Not Null,                      -- 인코딩(HTML/Text/Mixed)
    Homepage        NVarChar(100) Null,                         -- 홈페이지
    ModifyDate      DateTime Null,                              -- 수정일 
    ModifyIp        NVarChar(15) Null,                          -- 수정IP
    FileName        NVarChar(255) Null,                         -- 파일명
    FileSize        Int Default 0,                              -- 파일크기
    DownCount       Int Default 0,                              -- 다운수 
    CommentCount    Int Default 0,                              -- 댓글수

    Ref             Int Not Null,                               -- 참조(부모글)
    Step            Int Default 0,                              -- 답변깊이(레벨)
    RefOrder        Int Default 0,                              -- 답변순서
    AnswerNum       Int Default 0,                              -- 답변수
    ParentNum       Int Default 0,                              -- 부모글번호

    Num             Int Null,                                   -- 번호(확장...)
    UserId          Int Null,                                   -- (확장...) 사용자 테이블 Id
    CategoryId      Int Null Default 0,                         -- (확장...) 카테고리 테이블 Id
    BoardId         Int Null Default 0,                         -- (확장...) 게시판(Boards) 테이블 Id
    AplicationId    Int Null Default 0                          -- (확장용) 응용 프로그램 Id
)
Go

