----[!] 예시문 : 필수 데이터 입력

----[1] 빌트인(BuiltIn) 그룹 권한(역할(Role)) 부여 : Administrators, Everyone, Users, Guests
--Insert Domains (DomainID, Name, Type, Description)
--Values('Administrators', '관리자 그룹', 'Group', '응용 프로그램을 총 관리하는 관리 그룹 계정')
--Go

--Insert Domains (DomainID, Name, Type, Description)
--Values('Everyone', '전체 사용자 그룹', 'Group', '응용 프로그램을 사용하는 모든 사용자 그룹 계정')
--Go

--Insert Domains (DomainID, Name, Type, Description)
--Values('Users', '일반 사용자 그룹', 'Group', '일반 사용자 그룹 계정')
--Go

--Insert Domains (DomainID, Name, Type, Description)
--Values('Guests', '관리자 그룹', 'Group', '게스트 사용자 그룹 계정')
--Go

----[2] 빌트인(BuiltIn) 관리용 사용자 입력 : Administrator, Guest, Anonymous
--Insert Domains (DomainID, Name, Type, Description)
--Values('Administrator', '관리자', 'User', '응용 프로그램을 총 관리하는 사용자 계정')
--Go

--Insert Domains (DomainID, Name, Type, Description)
--Values('Guest', '게스트 사용자', 'User', '게스트 사용자 계정')
--Go

--Insert Domains (DomainID, Name, Type, Description)
--Values('Anonymous', '익명 사용자', 'User', '익명 사용자 계정')
--Go




Set Identity_Insert Domains On
Go

--[!] 예시문 : 필수 데이터 입력

--[1] 빌트인(BuiltIn) 그룹 권한(역할(Role)) 부여 : Administrators, Everyone, Users, Guests
Insert Domains (UID, DomainID, Name, Type, Description) Select 1, 'Administrators', '관리자 그룹', 'Group', '응용 프로그램을 총 관리하는 관리 그룹 계정'
Where Not Exists (select * from dbo.Domains Where UID =  1)
Go

Insert Domains (UID, DomainID, Name, Type, Description) Select 2, 'Everyone', '전체 사용자 그룹', 'Group', '응용 프로그램을 사용하는 모든 사용자 그룹 계정'
Where Not Exists (select * from dbo.Domains Where UID =  2)
Go

Insert Domains (UID, DomainID, Name, Type, Description) Select 3, 'Users', '일반 사용자 그룹', 'Group', '일반 사용자 그룹 계정'
Where Not Exists (select * from dbo.Domains Where UID =  3)
Go

Insert Domains (UID, DomainID, Name, Type, Description) Select 4, 'Guests', '관리자 그룹', 'Group', '게스트 사용자 그룹 계정'
Where Not Exists (select * from dbo.Domains Where UID =  4)
Go

--[2] 빌트인(BuiltIn) 관리용 사용자 입력 : Administrator, Guest, Anonymous
Insert Domains (UID, DomainID, Name, Type, Description) Select 5, 'Administrator', '관리자', 'User', '응용 프로그램을 총 관리하는 사용자 계정'
Where Not Exists (select * from dbo.Domains Where UID =  5)
Go

Insert Domains (UID, DomainID, Name, Type, Description) Select 6, 'Guest', '게스트 사용자', 'User', '게스트 사용자 계정'
Where Not Exists (select * from dbo.Domains Where UID =  6)
Go

Insert Domains (UID, DomainID, Name, Type, Description) Select 7, 'Anonymous', '익명 사용자', 'User', '익명 사용자 계정'
Where Not Exists (select * from dbo.Domains Where UID =  7)
Go

Set Identity_Insert Domains Off
Go
