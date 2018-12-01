--[1] Domains 테이블 : 회원/그룹 필수 정보
Create Table dbo.Domains
(
    UID Int Identity(1, 1) Not Null Primary Key,	--일련번호(Id)
    DomainID NVarChar(30) NOT Null,					--아이디/그룹아이디(UserID)
    Name NVarChar(50) NOT Null,						--이름/그룹명/닉네임(한글 7자, 영문 14자로 제한)
    [Type] NVarChar(10) NOT Null,					--User/Group, 나중에 Type을 DomainType으로 바꿀것.
    [Description] NVarChar(255) Null,				--설명(소개)
    -- Added
    CreatedDate	DateTime Default(GetDate())			--가입일(계정 등록일)
)
Go
