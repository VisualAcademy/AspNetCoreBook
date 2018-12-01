--[4] 빌트인(BuiltIn) 관리용 사용자에 대한 권한(역할:Role) 부여

--Insert Membership (UserUID, GroupUID)
--Values(5, 1) -- Administrator -> Administrators(1)
--Go

--Insert Membership (UserUID, GroupUID)
--Values(5, 3) -- Administrator -> Users(3)	
--Go

--Insert Membership (UserUID, GroupUID)
--Values(6, 4) -- Guest -> Guests(4)
--Go

--Insert Membership (UserUID, GroupUID)
--Values(7, 4) -- Anonymous -> Guests(4)
--Go


Insert Membership (UserUID, GroupUID) Select 5, 1 -- Administrator -> Administrators(1)
Where Not Exists (select * from dbo.Membership Where UserUID = 5 And GroupUID = 1) 
Go

Insert Membership (UserUID, GroupUID) Select 5, 3 -- Administrator -> Users(3)	
Where Not Exists (select * from dbo.Membership Where UserUID = 5 And GroupUID = 3)
Go

Insert Membership (UserUID, GroupUID) Select 6, 4 -- Guest -> Guests(4)
Where Not Exists (select * from dbo.Membership Where UserUID = 6 And GroupUID = 4)
Go

Insert Membership (UserUID, GroupUID) Select 7, 4 -- Anonymous -> Guests(4)
Where Not Exists (select * from dbo.Membership Where UserUID = 7 And GroupUID = 4)
Go

