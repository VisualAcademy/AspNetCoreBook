--[12] 관리자가 그룹 정보 업데이트: 나중에 그룹명 변경하는 로직 추가할 것...
Create Proc dbo.UpdateGroupAdmin
    @DomainID NVarChar(30),		-- 현재 사용자
    @Name NVarChar(50),			-- 이름
    @Description NVarChar(255),	-- 설명(소개)
    @UID Int					-- 현재 그룹 UID
As
    --[!] 해당 그룹이 이미 등록되어있으면
    Declare @Result Int
    Select @Result = Count(*) From Domains Where DomainID = @DomainID

    If @Result > 0 
        Return -1 -- -1이 반환되면 회원가입 안됨...
        
    Begin
        Update Domains  -- 아이디, 이름, 설명
        Set 
            DomainID = @DomainID, Name = @Name, 
            Description = @Description 
        Where UID = @UID
    End
    Select @@RowCount -- 업데이트된 내용이 있으면 1반환
Go
