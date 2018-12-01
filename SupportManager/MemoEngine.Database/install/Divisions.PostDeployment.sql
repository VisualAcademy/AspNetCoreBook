Set Identity_Insert Divisions On
Go

--Insert Into Divisions (DivisionName, DivisionNameEng) Values (N'사진', 'PHOTO');
--Go

Delete Divisions Where DivisionId In (1, 2)
Go

Insert Into Divisions (DivisionId, DivisionName, DivisionNameEng) Values (1, N'잡담', 'TALK');
Insert Into Divisions (DivisionId, DivisionName, DivisionNameEng) Values (2, N'사진', 'PHOTO');
Go

Set Identity_Insert Divisions Off
Go
