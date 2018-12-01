--[11] 그룹리스트를 출력하는 저장 프로시저 : GetGroups
Create Proc dbo.GetGroups
As
    Select [UID], [DomainID], [Name], [Type], [Description] 
	From Groups 
	Order By UID ASC
Go
