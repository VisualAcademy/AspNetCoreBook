--TODO: 
--[8] 현재 접속자에 포함된 그룹 정보 읽어오기
Create Proc dbo.GetGroupByUID
    @UID Int
As
    Select GroupUID, DomainID, Name
    From Membership, Groups 
    Where 
        Membership.GroupUID = Groups.UID
        And
        Membership.UserUID = @UID
    Order By DomainID Asc
Go

--GetGroupByUID 5
--Go
