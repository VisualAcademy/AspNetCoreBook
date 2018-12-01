--[2] UserProfiles 테이블 : 회원 기타 정보, 회원(Users) = Domains + UserProfiles
Create Table dbo.UserProfiles
(
    Id	Int Identity(1, 1) Primary Key Not Null,	-- 일련번호
    UID Int Not Null,				-- Domains 테이블의 UID값
    Password NVarChar(50) Null,		-- 암호
    Email NVarChar(100) Null,		-- 이메일
    LastLoginDate DateTime Null, 	-- 마지막 로그인 시간
    LastLoginIP NVarChar(16) Null,	-- 마지막 로그인 IP주소
    VisitedCount Int Default(0),	-- 방문 횟수
    Blocked Bit Default(0),			-- 계정 사용 안함 체크박스: 계정 사용(0) 또는 잠금(1)

    -- 기타 필요한 정보가 있으면 사용자가 더 추가	
    -- ZipCode
    -- Address
    -- PhoneNumber

    PhoneNumber NVarChar(30) NULL, 
    Address     NVarChar(500) NULL,
    Gender		NVarChar(10) NULL,
    BirthDate	NVarChar(20) NULL,
    Country		NVarChar(50) NULL,

    -- 추가...
    IsSleep	
        Bit 
        Default(0),						-- 휴면 사용자 여부
    SleepDate 
        DateTimeOffset(7) 
        Default(GetDate())				-- 휴면 전환 시점
)
Go
