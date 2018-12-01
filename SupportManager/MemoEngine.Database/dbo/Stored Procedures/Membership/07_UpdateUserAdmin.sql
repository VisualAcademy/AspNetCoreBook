--[7] 관리자가 사용자 정보 업데이트
Create Proc dbo.UpdateUserAdmin
    @DomainID NVarChar(30),		-- 현재 사용자
    @Name NVarChar(50),			-- 이름
    @Password NVarChar(50),		-- 암호
    @Email NVarChar(100),		-- 이메일
    @Description NVarChar(255),	-- 설명(소개)
    @Blocked Bit,				-- 잠금 여부(0 또는 1)
    @UID Int,					-- 현재 사용자 UID

	@PhoneNumber NVarChar(50) = NULL,
	@Address NVarChar(100) = NULL,
	@Gender NVarChar(10) = NULL,
	@BirthDate NVarChar(20) = NULL,
	@Country NVarChar(50) = NULL
	
As
    -- 아이디 변경은 따로 구현할 것...
    --[!] 해당 아이디가 이미 회원가입되어있으면
    --Declare @Result Int
    --Select @Result = Count(*) From Domains Where DomainID = @DomainID

    --If @Result > 0 
    --    Return -1 -- -1이 반환되면 회원가입 안됨...
        
    Begin
        Update Domains  -- 아이디, 이름, 설명
        Set 
            DomainID = @DomainID, Name = @Name, Description = @Description 
        Where UID = @UID

		-- 이메일, 암호, 잠금 여부
        Update UserProfiles 
		Set 
			Email = @Email, Password = @Password, Blocked = @Blocked, 
			PhoneNumber = @PhoneNumber, Address = @Address, Gender = @Gender, 
			BirthDate = @BirthDate, Country = @Country  
        Where UID = @UID
    End
    Select @@RowCount -- 업데이트된 내용이 있으면 1반환
Go