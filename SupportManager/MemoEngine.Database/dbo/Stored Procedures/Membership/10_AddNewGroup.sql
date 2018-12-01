--[10] 그룹을 추가하는 저장 프로시저 : AddNewGroup
Create Proc dbo.AddNewGroup
    @GroupUID NVarChar(50),
    @Name NVarChar(50),
    @Description NVarChar(255),
    --
    @UID Int Output
As
    --[!] 해당 그룹이 이미 등록되어있으면
    Declare @Result Int
    Select @Result = Count(*) From Domains Where DomainID = @GroupUID

    If @Result > 0 
        Return -1 -- -1이 반환되면 회원가입 안됨...

    Insert Domains(DomainID, Name, Description, Type)
    Values(@GroupUID, @Name, @Description, 'Group')

    Select @UID = @@Identity -- Domains 테이블의 가장 마지막 입력된 UID값

    --[!] UID값 반환
    Select @UID
Go
