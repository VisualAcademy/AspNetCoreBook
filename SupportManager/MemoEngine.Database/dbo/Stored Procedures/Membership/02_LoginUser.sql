------------------------------------------------------------------------------------------------------
--[!] 저장 프로시저(Stored Procedure) 설계 - 회원 인증 관련
------------------------------------------------------------------------------------------------------

--[2] 회원 로그인 처리 저장 프로시저 : LoginUser : /Login/, Login.aspx, LoginForm.aspx에서 사용
Create Proc dbo.LoginUser
    @DomainID NVarChar(30), 
    @Password NVarChar(50),
    @LastLoginIP NVarChar(15), -- IP주소(입력)
    @OriginLastLoginIP NVarChar(15) Output, -- 이전 IP주소 반환용
    @OriginLastLoginDate DateTime Output   -- 마지막 로그인 시간
As
BEGIN
	
	Set @OriginLastLoginIP = ''
	Set @OriginLastLoginDate = NULL

    Declare @Result Int
    Declare @UID Int	-- UID 고유번호
    Declare @Name NVarChar(30) 
    Select @Result = Count(*), @UID = UID, @Name = Name From Users -- 뷰에서 검색
    Where DomainID = @DomainID And Password = @Password
    Group By UID, Name

    If @Result > 0 -- 로그인 정보 남기기
    Begin
        -- 이전 자료 읽어서 반환
        Select @OriginLastLoginIP = LastLoginIP, 
            @OriginLastLoginDate = LastLoginDate 
        From Users Where UID = @UID
        
        If @OriginLastLoginDate Is Null
            Set @OriginLastLoginDate = GETDATE()
        
        -- 새로운 값으로 업데이트
        Update UserProfiles
        Set 
            LastLoginIP = @LastLoginIP, 
            LastLoginDate = GetDate(),
            VisitedCount = VisitedCount + 1
        Where UID = @UID 	


        -- 로그인 히스토리 테이블에 기록
        Insert LoginHistories(UID, UserID, UserName, LoginIP, LoginDate) 
		Values(@UID, @DomainID, @Name, @LastLoginIP, GetDate())		


        Select '1'
    End
    Else
    Begin	
        If @OriginLastLoginDate Is Null
            Set @OriginLastLoginDate = GETDATE()
        Select '0' -- 0 : 아이디 및 암호 틀림, 1 : Correct
    End
END
Go
