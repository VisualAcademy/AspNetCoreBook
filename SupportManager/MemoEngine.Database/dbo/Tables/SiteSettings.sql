Create Table dbo.SiteSettings
(
	Id Int Identity(1, 1) Primary Key Not Null, 
	ShowMenu1 Bit Default(0),					-- false : 숨김, true(1) : 보임
	ShowMenu2 Bit Default(0),
	ShowMenu3 Bit Default(0),
	ShowMenu4 Bit Default(0),
	ShowMenu5 Bit Default(0),
	ShowMenu6 Bit Default(0),
	ShowMenu7 Bit Default(0)
)
Go
