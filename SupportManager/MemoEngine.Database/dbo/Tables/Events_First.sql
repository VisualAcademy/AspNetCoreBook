CREATE TABLE [dbo].[Events_First]
(
	[Id] INT NOT NULL Identity(1, 1) PRIMARY KEY,
	[UID] INT Not Null,
	[AddDate] DateTime Default(GetDate())
)
