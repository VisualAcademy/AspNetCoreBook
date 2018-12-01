-----------------------------------------------------------
-- Reply DB 및 로그인 사용자 생성 후 권한 주기
-- 작성자 : 박용준
-----------------------------------------------------------
Use Master
Go

--[1] Reply 데이터베이스 생성
--Drop Database Reply
Create Database Reply
Go

--[2] Reply Login 생성
--Drop Login Reply
Create Login Reply 
With 
    Password = 'Pa$$w0rd', 
    DEFAULT_DATABASE = Reply,
    CHECK_POLICY = Off
Go

Alter Login Reply Enable
Go

--[3] Reply 데이터베이스에 Reply 로그인 사용자에 db_owner 권한 부여
Use Reply
Go

--Drop User Reply 
Create User Reply For Login Reply With DEFAULT_SCHEMA = dbo
Go

-- db_owner 권한 부여 
Exec sp_addrolemember db_owner, Reply
Go

 

