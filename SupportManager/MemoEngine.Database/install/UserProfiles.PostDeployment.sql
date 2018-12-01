--[3] 관리용 사용자에 대한 추가 프로필 정보 입력
--Insert UserProfiles(UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked)
--Values(5, 'me', null, null, null, 0, 0)
--Go

--Insert UserProfiles(UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked)
--Values(6, 'me', null, null, null, 0, 1)
--Go

--Insert UserProfiles(UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked)
--Values(7, 'me', null, null, null, 0, 1)
--Go

Set Identity_Insert UserProfiles On
Go

Insert UserProfiles (Id, UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked) 
Select 1, 5, 'me', null, null, null, 0, 0
Where Not Exists (select * from dbo.UserProfiles Where Id =  1)
Go

Insert UserProfiles (Id, UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked) 
Select 2, 6, 'me', null, null, null, 0, 1
Where Not Exists (select * from dbo.UserProfiles Where Id =  2)
Go

Insert UserProfiles (Id, UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked) 
Select 3, 7, 'me', null, null, null, 0, 1
Where Not Exists (select * from dbo.UserProfiles Where Id =  3)
Go

Set Identity_Insert UserProfiles On
Go
