
Create Table Records
(
	Id Int Identity(1, 1) Not Null Primary Key,		-- 일련번호
	Name VarChar(25) Not Null,						-- 이름
	PhoneNumber VarChar(20) Null,					-- 전화번호
	BirthDate VarChar(12) Null,						-- 년-월-일
	AuthCode VarChar(20) Null,						-- 인증코드 

	Field1 VarChar(100) Null,						-- 추가필드1
	Field2 VarChar(100) Null,						-- 추가필드2
	Field3 VarChar(100) Null,						-- 추가필드3
	Field4 VarChar(100) Null						-- 추가필드4
)
Go
