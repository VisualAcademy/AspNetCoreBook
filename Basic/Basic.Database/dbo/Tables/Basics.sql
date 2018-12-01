--[0] 기본형 게시판(Basic)용 테이블 설계
--[!] Drop Table dbo.Basics
Create Table dbo.Basics
(
	Id Int Identity(1, 1) Not Null Primary Key, 		--번호
	Name NVarChar(25) Not Null,							--이름
	Email NVarChar(100) Null, 							--이메일	
	Title NVarChar(150) Not Null,						--제목
	PostDate DateTime Default GetDate(),				--작성일	
	PostIp NVarChar(15) Not Null,						--작성IP
	Content NText Not Null,								--내용
	Password NVarChar(20) Not Null,						--비밀번호
	ReadCount Int Default 0,							--조회수
	Encoding NVarChar(10) Not Null,					--인코딩(HTML/Text/Mixed)
	Homepage NVarChar(100) Null,						--홈페이지
	ModifyDate SmallDateTime Null,					--수정일	
	ModifyIp NVarChar(15) Null						--수정IP
)
Go

----[!] 6개 예시문
----[1] 입력 : Write.aspx
--Insert Basics
--Values
--(
--	'홍길동',
--	'h@h.com',
--	'홍길동입니다.(냉무)',
--	GetDate(),
--	'127.0.0.1',
--	'안녕하세요.',
--	'1234',
--	0,
--	'Text',
--	'http://www.a.com/',
--	NULL,	--널
--	''	--빈(Empty)
--)
--Go

----[2] 출력 : List.aspx
--Select 
--	Id, Name, Email, 
--	Title, PostDate, ReadCount
--From Basics --Join On
----Where 
----Group By
----Having
--Order By Id Desc
--Go

----[3] 상세 : View.aspx
--Select *
--From Basics
--Where Id = 5
--Go

----[4] 수정 : Modify.aspx
--Begin Tran
--	Update Basics
--	Set
--		Name = '백두산',
--		Email = 'b@b.com',
--		Homepage = 'http://b.com/',
--		Title = '새로운 제목',
--		Content	= '<u>내용</u>',
--		Encoding = 'HTML',
--		ModifyDate = GetDate(),
--		ModifyIP = '127.0.0.1'
--	Where Id = 5
----RollBack Tran
--Commit Tran
--Go

----[5] 삭제 : Delete.aspx
--Begin Transaction
--	Delete Basics
--	Where Id = 5
----RollBack Transaction
--Commit Transaction
--Go

----[6] 검색 : Search.aspx
--Select *
--From Basics
--Where
--	Name Like '%홍길동%'
--	Or 
--	Title Like '홍%'
--	Or
--	Content Like '%3'
--Go


----[!] 6개 저장 프로시저
----[7] 기본형 게시판(Basics)에 글을 작성하는 저장 프로시저 : WriteBasics
--Create Proc dbo.WriteBasics
--	@Name VarChar(25), 
--	@Email VarChar(100), 
--	@Title VarChar(150), 
--	@PostIP VarChar(15), 
--	@Content Text, 
--	@Password VarChar(20), 
--	@Encoding VarChar(10), 
--	@Homepage VarChar(100)	
----With Encryption
--As
--	Insert Basics
--	(
--		Name, Email, Title, PostIP, Content, 
--		Password, Encoding, Homepage
--	)
--	Values
--	(
--		@Name, @Email, @Title, @PostIP, @Content, 
--		@Password, @Encoding, @Homepage
--	)
--Go

----[8] 기본형 게시판(Basics)에서 데이터를 읽어오는 저장 프로시저 : ListBasics
--Create Procedure dbo.ListBasics
--As
--	Select * 
--	From Basics 
--	Order By Id Desc
--Go

----[9] 조회수 증가시켜주는 저장 프로시저 : UpdateReadCount
--Create Proc dbo.UpdateReadCountBasics
--	@Id Int
--As
--	Update Basics 
--	Set ReadCount = ReadCount + 1 
--	Where Id = @Id
--Go

----[10] 해당 글을 세부적으로 읽어오는 저장 프로시저 : ViewBasics
--Create Procedure dbo.ViewBasics
--	@Id Int
--As
--	Update Basics 
--	Set ReadCount = ReadCount + 1 
--	Where Id = @Id

--	Select *
--	From Basics 
--	Where Id = @Id
--Go

----[11] 해당 글에 대한 비밀번호 읽어오는 저장 프로시저 : ReadPassword
--Create Proc dbo.ReadPasswordBasics
--	@Id Int
--As 
--	Select Password 
--	From Basics 
--	Where Id = @Id
--Go

----[12] 해당 글 지우는 저장 프로시저 : DeleteBasics
--Create Proc dbo.DeleteBasics
--	@Id Int
--As
--	Delete Basics Where Id = @Id
--Go

----[13] 해당 글을 수정하는 저장 프로시저 : ModifyBasics
--Create Proc dbo.ModifyBasics
--	@Name VarChar(25), 
--	@Email VarChar(100), 
--	@Title VarChar(150), 
--	@ModifyIP VarChar(15), 
--	@ModifyDate DateTime,
--	@Content Text, 
--	@Encoding VarChar(10), 
--	@Homepage VarChar(100),
--	@Id Int
--As
--	Update Basics 
--	Set 
--		Name = @Name,
--		Email = @Email,
--		Title = @Title,
--		ModifyIP = @ModifyIP,
--		ModifyDate = @ModifyDate,
--		Content = @Content,
--		Encoding = @Encoding,
--		Homepage = @Homepage
--	Where Id = @Id
--Go

----[14] 검색 저장 프로시저 : 동적 SQL문
--Create Proc dbo.SearchBasics
--	@SearchField VarChar(25),
--	@SearchQuery VarChar(25)
--As
--	Declare @strSql VarChar(150) -- 변수 선언
--	Set @strSql = '
--	Select * From Basics 
--	Where ' 
--		+ @SearchField + ' Like ''%' 
--		+ @SearchQuery + '%'' Order By Id Desc'
--	--Print @strSql
--	Exec (@strSql)
--Go

--SearchBasics 'Name', '홍길동'
--Go


----테스트URL : http://www.memoengine.com/Basic/List.aspx
----작성자 : 박용준(RedPlus)
