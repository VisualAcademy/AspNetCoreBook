CREATE TABLE [dbo].[SampleData]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1),
	Name NVarChar(Max) Null,
	Num Int Null,
	IntData Int Null,
	DoubleData Float Null,
	FloatData Float Null,
	StringData NVarChar(Max) Null
)
Go
