--[8] 삭제 : DeleteScheduleByDomain
Create Proc dbo.DeleteScheduleByDomain
	@UserID VarChar(25),
	@Num Int
As
	Delete ScheduleByDomain Where UserID = @UserID And Num = @Num
Go
