--[8] 삭제 : DeleteSchedule
Create Proc dbo.DeleteSchedule
	@Num Int
As
	Delete Schedule Where Num = @Num
Go
