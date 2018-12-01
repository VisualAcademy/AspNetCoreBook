--------------------------------------
---답변형 게시판 응용 프로그램
--------------------------------------

--[0] 답변형 게시판(Reply)용 테이블 설계
Create Table dbo.Reply
(
    Num Int Identity(1, 1) Not Null Primary Key,    --번호
    Name NVarChar(25) Not Null,                      --이름
    Email NVarChar(100) Null,                        --이메일	
    Title NVarChar(150) Not Null,                    --제목
    PostDate DateTime Default GetDate() Not Null,   --작성일	
    PostIP NVarChar(15) Not Null,                    --작성IP
    Content Text Not Null,                          --내용
    Password NVarChar(20) Not Null,                  --비밀번호
    ReadCount Int Default 0,                        --조회수
    Encoding NVarChar(10) Not Null,                  --인코딩(HTML/Text)
    Homepage NVarChar(100) Null,                     --홈페이지
    ModifyDate DateTime Null,                       --수정일	
    ModifyIP NVarChar(15) Null,                      --수정IP
    ----------
    Ref Int Not Null,                               --참조(부모글)
    Step Int Default 0,                             --답변깊이(레벨)
    RefOrder Int Default 0                          --답변순서
)
Go

--[7] 답변 게시판(Reply)에 글을 작성하는 저장 프로시저 : WriteReply
--Drop Proc dbo.WriteReply
Create Proc dbo.WriteReply
    @Name NVarChar(25), 
    @Email NVarChar(100), 
    @Title NVarChar(150), 
    @PostIP NVarChar(15), 
    @Content NText, 
    @Password NVarChar(20), 
    @Encoding NVarChar(10), 
    @Homepage NVarChar(100)
As
    --[1] 현재까지 테이블의 Ref의 Max값 받아오기
    Declare @MaxRef Int
    Select @MaxRef = Max(Ref) From Reply

    If @MaxRef is Null
        Set @MaxRef = 1 
    Else
        Set @MaxRef = @MaxRef + 1

    Insert Reply (
        Name, Email, Title, PostIP, Content, 
        Password, Encoding, Homepage, Ref	
    )
    Values (
        @Name, @Email, @Title, @PostIP, @Content, 
        @Password, @Encoding, @Homepage, @MaxRef	
    )
Go

--[8] 답변 게시판(Reply)에서 데이터를 읽어오는 저장 프로시저 : ListReply
--Drop Proc dbo.ListReply
Create Procedure dbo.ListReply
As
    Select * From Reply Order By Ref Desc, RefOrder Asc
Go

--[9] 해당 글을 세부적으로 읽어오는 저장 프로시저 : ViewReply
Create Procedure dbo.ViewReply
    @Num Int
As
    Update Reply Set ReadCount = ReadCount + 1 
    Where Num = @Num

    Select * From Reply Where Num = @Num
Go

--[10] 해당 글을 수정하는 저장 프로시저 : ModifyReply
Create Proc dbo.ModifyReply
    @Name NVarChar(25), 
    @Email NVarChar(100), 
    @Title NVarChar(150), 
    @ModifyIP NVarChar(15), 
    @Content Text, 
    @Encoding NVarChar(10), 
    @Homepage NVarChar(100),
    @Password NVarChar(20), 
    @Num Int
As
    Declare @cnt Int
    Select @cnt = Count(*) From Reply
    Where Num = @Num And Password = @Password

    If @cnt > 0  -- 넘겨져 온 번호와 암호가 맞는 데이터가 있다면...
        Update Reply 
        Set 
            Name = @Name, 
            Email = @Email,
            Title = @Title, 
            ModifyIP = @ModifyIP,
            ModifyDate = GetDate(), 
            Content = @Content,
            Encoding = @Encoding, 
            Homepage = @Homepage
        Where Num = @Num And Password = @Password
    Else
        Return -1 -- 암호가 틀리면 -1을 반환하자...
Go

--[11] 해당 글 지우는 저장 프로시저 : DeleteReply
Create Proc dbo.DeleteReply
    @Password NVarChar(20),
    @Num Int
As
    Declare @cnt Int
    -- 암호와 번호가 맞으면 1을 반환
    Select @cnt = Count(*) From Reply 
    Where Num = @Num And Password = @Password

    If @cnt > 0 
        Delete Reply Where Num = @Num And Password = @Password
    Else	
        Return -1 -- 삭제가 되지 않으면 -1 반환
Go

--[6] 검색 저장 프로시저 : 정적 쿼리문
Create Proc dbo.SearchReply
     @SearchField NVarChar(25),
     @SearchQuery NVarChar(25)
As
    Set @SearchQuery = '%' + @SearchQuery + '%'
    SELECT *
    FROM Reply
    WHERE
     (
         CASE @SearchField 
             WHEN 'Name' THEN Name
             WHEN 'Content' THEN Content
             WHEN 'Title' THEN Title
         ELSE 
             @SearchQuery
         END
     ) 
     LIKE 
     @SearchQuery
    Order By Num Desc
Go

--[12] 답변 게시판(Reply)에 글을 답변하는 저장 프로시저 : ReplyReply
--Drop Proc dbo.ReplyReply
Create Proc dbo.ReplyReply
    @Name NVarChar(25), @Email NVarChar(100), 
    @Title NVarChar(150), @PostIP NVarChar(15), 
    @Content Text, @Password NVarChar(20), 
    @Encoding NVarChar(10), 
    @Homepage NVarChar(100),
    @ParentNum Int -- 부모글의 Num 필드값 받기 -> Ref, Step, RefOrder
As
    Declare @ParentRef Int
    Declare @ParentStep Int
    Declare @ParentRefOrder Int
        
    Select @ParentRef = Ref, @ParentStep = Step, @ParentRefOrder = RefOrder
    From Reply
    Where Num = @ParentNum 
    
    Begin Tran 
        -- 비집고 들어갈 자리 만들기
        Update Reply
        Set RefOrder = RefOrder + 1
        Where 
            Ref = @ParentRef And RefOrder > @ParentRefOrder
        -- 부모글보다 Step을 1증가, 보여지는순서도 1증가
        Insert Reply (
            Name, Email, Title, PostIP, Content, Password, 
            Encoding, Homepage, Ref, Step, RefOrder
        )
        Values (
            @Name, @Email, @Title, @PostIP, @Content, @Password, 
            @Encoding, @Homepage, @ParentRef, @ParentStep + 1, @ParentRefOrder + 1
        )	
    Commit Tran	
Go


--테스트URL : http://sample.redplus.net/Web/Reply/List.aspx
--작성자 : 박용준(RedPlus)


--[0] 답변형 게시판 쿼리문 연습
--Drop Table dbo.ReplyTest
Create Table dbo.ReplyTest
(
    Num Int Identity(1, 1) Primary Key Not Null, -- 번호
    Title NVarChar(150) Not Null, -- 제목
    -- ...
    Ref Int Default 0,	--참조글(부모글;최상위글;답변이아닌글;그룹번호;Group)
    Step Int Default 0, --들여쓰기(한단계 답변:한단계들여쓰기;Level;Depth)
    RefOrder Int Default 0 --같은 그룹내에서의 정렬순서(Position)
)
Go

----[1] 처음으로 게시판 글쓰기
--Insert Into ReplyTest(Title, Ref)
--Values('첫번째 부모글', 1)

----[2] 새로운 글 입력 : Write.aspx.cs
--Begin
--	Declare @MaxRef Int
--	Select @MaxRef = Max(Ref) From ReplyTest

--	Insert Into ReplyTest(Title, Ref)
--	Values('두번째 부모글', @MaxRef + 1)
--End

----[3] 첫번째 부모글에 한단계 답변
--Insert ReplyTest(Title, Ref, Step, RefOrder)
--Values('>>첫번째 부모글에 답변', 1, 0+1, 0+1)  

----[4] 첫번째 부모글에 답변의 답변 : [3]번글의 답변
--Insert ReplyTest(Title, Ref, Step, RefOrder)
--Values('>>>>첫번째 부모글에 답변의 답변', 1, 2, 2) 
 
----[5] 두번째 부모글에 답변 : [2]번글의 답변
--Insert ReplyTest(Title, Ref, Step, RefOrder)
--Values('>>두번째 부모글에 답변', 2, 1, 1)  

----[6] 첫번째 부모글에 한단계 답변(나중에) :  
---- [1]번 글에 답변
--Update ReplyTest Set RefOrder = RefOrder + 1
--Where Ref = 1 And RefOrder > 0 -- 부모글의 RefOrder(0)보다 큰 레코드 모드 업데이트

--Insert ReplyTest(Title, Ref, Step, RefOrder)
--Values('>>첫번째 부모글에 답변(나중에)', 1, 0+1, 0+1)  

----[7] [6]번 레코드에 답변
--Update ReplyTest Set RefOrder = RefOrder + 1
--Where Ref = 1 And RefOrder > 1 -- 부모글의 RefOrder(0)보다 큰 레코드 모드 업데이트

--Insert ReplyTest(Title, Ref, Step, RefOrder)
--Values('>>>>첫번째 부모글에 답변(나중에)의 답변', 1, 1+1, 1+1)  

----[!] 데이터 출력
--Select * From ReplyTest Order By Ref Desc, RefOrder Asc


-- 저장 프로시저화
--[1] 입력 저장 프로시저 : 부모 글 입력
-- 현재까지 가장 큰 Ref값을 받아서 그 값에 1을 더해서 새로운
-- Ref(그룹)으로 데이터 저장
Create Procedure dbo.WriteReplyTest
    @Title NVarChar(150)
As	
    --[1] 현재까지 테이블의 Ref의 Max값 받아오기
    Declare @MaxRef Int
    Select @MaxRef = Max(Ref) From ReplyTest
    
    --[2] MaxRef가 0보다 크면
    If @MaxRef > 0
        Begin
                Insert Into ReplyTest(Title, Ref)
                Values(@Title, @MaxRef + 1)
        End
    Else -- 제일 첫번째 레코드 입력할 때만 실행
        Begin
            Insert Into ReplyTest(Title, Ref)
            Values(@Title, 1)
        End
Go
--WriteReplyTest '첫번째 부모글'
--WriteReplyTest '두번째 부모글'

--[2] 출력 저장 프로시저
Create Proc dbo.ListReplyTest
As
    Select * From ReplyTest 
    Order By Ref Desc, RefOrder Asc
Go
--ListReplyTest
--[3] 답변 저장 프로시저
--Drop Proc dbo.ReplyReplyTest
Create Proc dbo.ReplyReplyTest
    @Title NVarChar(150),
    @ParentRef Int,			-- 부모글의 Ref
    @ParentStep Int,		-- 부모글의 Step
    @ParentRefOrder Int	-- 부모글의 RefOrder
As
    Begin Tran 
        Update ReplyTest 
        Set RefOrder = RefOrder + 1
        Where 
            Ref = @ParentRef 
            And 
            RefOrder > @ParentRefOrder

        Insert ReplyTest(Title, Ref, Step, RefOrder)
        Values(@Title, @ParentRef, @ParentStep+1, @ParentRefOrder + 1)  
    Commit Tran
Go
