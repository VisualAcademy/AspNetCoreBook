Create Table dbo.BadWords
(
	Id Int Identity(1, 1) Not Null Primary Key,	-- 일련번호
	Word NVarChar(30)							-- 욕설저장
)
Go
