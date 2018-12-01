------------------------------------------------------------------------------------------------------
--[!] 저장 프로시저(Stored Procedure) 설계 - 회원 인증 관련
------------------------------------------------------------------------------------------------------

--[1] 회원 가입 저장 프로시저 : UserRepository.AddUserUpgrade()와 Register.aspx에서 사용
Create Proc dbo.AddUser
    @DomainID			NVarChar(30),
    @Name				NVarChar(50),
    @Description		NVarChar(255), 
    --	
    @Password			NVarChar(100),
    @Email				NVarChar(100),
    @Blocked			Bit, 
    @GroupUID			Int,				-- 기본은 'Users' 그룹 권한의 UID값, 'Administrators', 'Users', 'Guests' 중 'Users'의 고유 UID 값
    --
    @UID				Int Output,			-- 반환형 매개변수

    -- 추가된 매개변수
    @PhoneNumber		NVarChar(30),
    @Address			NVarChar(140),
    @Gender				NVarChar(5), 
    @BirthDate			NVarChar(12),
    @Country			NVarChar(30)
As
    If @UID Is Null
        Set @UID = 0

    --[!] 해당 아이디가 이미 회원가입되어있으면
    Declare @Result Int
    Select @Result = Count(*) From Domains Where DomainID = @DomainID

    If @Result > 0 
        Return -1 -- -1이 반환되면 회원가입 안됨...

    --[a] Domains 테이블에 데이터 입력
    If @Description <> '' 
        Insert Domains (DomainID, Name, Type, Description) 
        Values(@DomainID, @Name, 'User', @Description)	
    Else
        Insert Domains (DomainID, Name, Type, Description) 
        Values(@DomainID, @Name, 'User', NULL)	
    
    -- Select @UID = @@Identity -- Domains 테이블의 가장 마지막 입력된 UID값
    Select @UID = SCOPE_IDENTITY() -- 

    --[b] UserProfiles 테이블에 데이터 입력
    If @Email <> '' 
        Insert UserProfiles (UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked, PhoneNumber, Address, Gender, BirthDate, Country)
        Values (@UID, @Password, @Email, Null, Null, 0, @Blocked, @PhoneNumber, @Address, @Gender, @BirthDate, @Country)
    Else
        Insert UserProfiles (UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked, PhoneNumber, Address, Gender, BirthDate, Country)
        Values (@UID, @Password, Null, Null, Null, 0, @Blocked, @PhoneNumber, @Address, @Gender, @BirthDate, @Country)
    
    SELECT UID FROM Domains WHERE DomainID = 'Users'

    --[c] Membership 테이블에 데이터 입력
    Insert Membership (UserUID, GroupUID) 
    Values(@UID, @GroupUID) -- 모든 회원은 기본이 Users 권한

    --[!] UID값 반환
    -- Select @UID
Go
