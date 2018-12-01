--[4] 로그인 히스토리 정보 테이블 : 회원이 로그인할 때마다 로그인 정보 기록(IP와 시간)
Create Table dbo.LoginHistories 
(
    [Num] [Int] IDENTITY (1, 1) NOT NULL Primary Key,
	[UID] [Int] NULL,					-- 로그인 사용자의 UID 저장 : UserID로 저장해 놓으면 탈퇴한 아이디로 가입하면 이전 정보가 노출됨.
    [UserID] [NVarChar] (30) NULL,
    [UserName] [NVarChar] (50) NULL,
    [LoginIP] [NVarChar] (15) NULL,
    [LoginDate] [datetime] NULL
)
GO
