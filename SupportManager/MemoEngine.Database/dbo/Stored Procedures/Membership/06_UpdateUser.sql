--[6] 현재 접속자의 프로필 정보를 업데이트 : UpdateUser
Create Proc dbo.UpdateUser
    @Email NVarChar(100),		-- 이메일
    @Description NVarChar(255),	-- 설명(소개)
    @DomainID NVarChar(30),		-- 현재 접속자

    @PhoneNumber NVarChar(30) = NULL,
    @Address NVarChar(100) = NULL,
    @Gender NVarChar(10) = NULL,
    @BirthDate NVarChar(20) = NULL,
    @Country NVarChar(50) = NULL

As
    Declare @UID Int
    Select @UID = UID From Domains Where DomainID = @DomainID

    If @UID Is Not Null
    Begin
        Update Domains Set Description = @Description 
        Where UID = @UID

        Update UserProfiles 
            Set Email = @Email, PhoneNumber = @PhoneNumber, 
                Address = @Address, Gender = @Gender, 
                BirthDate = @BirthDate, Country = @Country 
        Where UID = @UID
    End

    Select @@RowCount -- 업데이트된 내용이 있으면 1반환
Go
