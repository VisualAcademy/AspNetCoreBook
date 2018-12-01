--[4] 현재 접속자에 대한 회원탈퇴 기능 구현 : DeleteUser : UserInfor.aspx에서 사용
Create Proc dbo.DeleteUser
    @DomainID NVarChar(30)
As
    Declare @UID Int
    Select @UID = UID From Users Where DomainID = @DomainID

    If @UID Is Not Null
    Begin
        Delete Domains Where UID = @UID And Type = 'User'
        Delete UserProfiles Where UID = @UID
        Delete Membership Where UserUID = @UID
        -- 게시판 연동시 2개 정도의 테이블에 있는 정보도 삭제
        --If OBJECT_ID(N'Permission', N'U') Is Not Null
        --Begin
        --	Delete From Permission Where UID = @UID
        --End
        --If OBJECT_ID(N'MailList', N'U') Is Not Null
        --Begin
     --       Delete From MailList Where UID = @UID
        --End
    End
Go
