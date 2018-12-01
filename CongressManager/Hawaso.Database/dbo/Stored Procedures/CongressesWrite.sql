-- 게시판에 글 작성: CongressesWrite
CREATE PROCEDURE [dbo].[CongressesWrite]
    -- 5W1H
    @Name       NVarChar(25), 
    @PostIp     NVarChar(15), 
    @Title      NVarChar(150), 
    @Content    NText, 
	@Category   NVarChar(10), 

    @Email      NVarChar(100), 
    @Password   NVarChar(255), 
    @Encoding   NVarChar(10), 
    @Homepage   NVarChar(100),
    @FileName   NVarChar(255),
    @FileSize   Int
As
    Declare @MaxRef Int
    Select @MaxRef = Max(IsNull(Ref, 0)) From Congresses
 
    If @MaxRef Is Null Or @MaxRef = 0
        Set @MaxRef = 1 -- 테이블 생성 후 처음만 비교
    Else
        Set @MaxRef = @MaxRef + 1

    Insert Congresses
    (
        Name, Email, Title, PostIp, Content, Password, Encoding, 
        Homepage, Ref, FileName, FileSize,
		Category 
    )
    Values
    (
        @Name, @Email, @Title, @PostIp, @Content, @Password, @Encoding, 
        @Homepage, @MaxRef, @FileName, @FileSize,
		@Category
    )
Go
