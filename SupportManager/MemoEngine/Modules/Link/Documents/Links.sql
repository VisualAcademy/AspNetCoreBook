Create Table dbo.Links
(
	Id			Int Identity(1, 1) Not Null Primary Key,
	PortalId	Int Not Null Default(1),
	CreatedDate DateTime Default(GetDate()),
	Title		NVarChar(100) Null,
	Url			NVarChar(250) Null,
	ViewOrder	Int Null,
	Description NVarChar(2000) Null
)
Go
