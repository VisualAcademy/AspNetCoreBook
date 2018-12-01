--[5] 현재 사용자에 대한 암호 변경 기능 구현 : ChangePassword
Create Proc dbo.ChangePassword
    @OriginalPassword NVarChar(20),	-- 이전 암호
    @NewPassword NVarChar(20),		-- 새 암호
    @DomainID NVarChar(30)			-- 현재 접속자 아이디
As
    Declare @UID Int
    Select @UID = UID From Users
    Where DomainID = @DomainID And Password = @OriginalPassword

    If @UID > 0
    Begin
        Update UserProfiles
        Set Password = @NewPassword
        Where UID = @UID
        Return 1 -- 업데이트 함	
        --Select @@RowCount
    End	
    Else
        Return -1 -- -1이 반환되면 업데이트 미적용
Go
