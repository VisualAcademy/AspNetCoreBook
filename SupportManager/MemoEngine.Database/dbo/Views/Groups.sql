------------------------------------------------------------------------------------------------------
--[!] 뷰(View) 설계 - 회원 인증 관련
------------------------------------------------------------------------------------------------------

--[1] 그룹 리스트 : Groups
--    /Models/Group.cs 
--    /ViewModels/GroupViewModel.cs 
Create View dbo.Groups
As
    Select 
        UID, 
        DomainID, 
        Name, 
        Type, 
        Description 
    From 
        Domains
    Where 
        Type = 'Group' 
    With Check Option -- 조건절에 해당하는 데이터만 입력/수정 가능
Go
-- Select * From groups
