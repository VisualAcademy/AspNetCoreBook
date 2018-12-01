--[9] 현재 사용자가 취득하지 못한 그룹 정보를 읽어오기 : Everyone 제외
Create Proc dbo.GetGroupNotInUse
    @UID Int
As
    Select UID As GroupUID, DomainID, Name 
    From Groups
    Where UID NOT IN (
            Select GroupUID	From Membership
            Where UserUID = @UID
        )
        And 
        DomainID <> 'Everyone'
    Order By DomainID
Go
