CREATE PROCEDURE [dbo].[SupportSettings_AddOrUpdate]
	@Remarks nvarchar(MAX),
	@CreationDate datetimeoffset,
	@BoardName nvarchar(50),
	@BoardNum int,
	@BoardTitle nvarchar(150),
	@BoardContent nvarchar(MAX),
	@StartDate smalldatetime,
	@EventDate smalldatetime,
	@EndDate smalldatetime,
	@MaxCount int,
	@IsClosed bit,
	@Id int

AS
	Declare @CountItems Int 
	Select @CountItems = Count(*) From SupportSettings Where BoardName = @BoardName And BoardNum = @BoardNum

	If @CountItems > 0
	Begin
		-- 업데이트
		SET NOCOUNT OFF;
		UPDATE [SupportSettings] SET [Remarks] = @Remarks, [CreationDate] = @CreationDate, [BoardName] = @BoardName, [BoardNum] = @BoardNum, [BoardTitle] = @BoardTitle, [BoardContent] = @BoardContent, [StartDate] = @StartDate, [EventDate] = @EventDate, [EndDate] = @EndDate, [MaxCount] = @MaxCount, [IsClosed] = @IsClosed WHERE (([Id] = @Id));
		SELECT Id, Remarks, CreationDate, BoardName, BoardNum, BoardTitle, BoardContent, StartDate, EventDate, EndDate, MaxCount, IsClosed FROM SupportSettings WHERE (Id = @Id);
	End
	Else
	Begin
		-- 인서트 
		INSERT INTO [SupportSettings] ([Remarks], [CreationDate], [BoardName], [BoardNum], [BoardTitle], [BoardContent], [StartDate], [EventDate], [EndDate], [MaxCount], [IsClosed]) VALUES (@Remarks, @CreationDate, @BoardName, @BoardNum, @BoardTitle, @BoardContent, @StartDate, @EventDate, @EndDate, @MaxCount, @IsClosed);
		SELECT Id, Remarks, CreationDate, BoardName, BoardNum, BoardTitle, BoardContent, StartDate, EventDate, EndDate, MaxCount, IsClosed FROM SupportSettings WHERE (Id = SCOPE_IDENTITY());
	End
Go
