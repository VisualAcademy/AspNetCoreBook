--[6] 상세 저장 프로시저 : ViewSchedule
Create Proc dbo.ViewSchedule
	@Num Int
As
	Select * From Schedule Where Num = @Num
Go
