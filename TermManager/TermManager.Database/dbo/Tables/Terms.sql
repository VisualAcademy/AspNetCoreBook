Create Table Terms
(
	Id Int Primary Key Identity(1, 1) Not Null, -- 일련번호
	Title NVarChar(100) Null,					-- 용어
	Description NVarChar(Max) Null,				-- 설명
	CreationDate DateTime Default(GetDate())	-- 등록일
)
Go
