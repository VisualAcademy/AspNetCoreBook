-----------------------------------------------------------
-- Reply DB �� �α��� ����� ���� �� ���� �ֱ�
-- �ۼ��� : �ڿ���
-----------------------------------------------------------
Use Master
Go

--[1] Reply �����ͺ��̽� ����
--Drop Database Reply
Create Database Reply
Go

--[2] Reply Login ����
--Drop Login Reply
Create Login Reply 
With 
    Password = 'Pa$$w0rd', 
    DEFAULT_DATABASE = Reply,
    CHECK_POLICY = Off
Go

Alter Login Reply Enable
Go

--[3] Reply �����ͺ��̽��� Reply �α��� ����ڿ� db_owner ���� �ο�
Use Reply
Go

--Drop User Reply 
Create User Reply For Login Reply With DEFAULT_SCHEMA = dbo
Go

-- db_owner ���� �ο� 
Exec sp_addrolemember db_owner, Reply
Go

 

