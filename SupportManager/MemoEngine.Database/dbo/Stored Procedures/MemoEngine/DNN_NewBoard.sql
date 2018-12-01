-- 일단 생성: 하지만, 실제 사용은 Inline SQL로 대체된다. 
-- 2014-09-11 HeaderHtml과 FooterHtml 필드 추가
Create Proc dbo.DNN_NewBoard
    @BoardAlias NVarChar(50), 
    @Title NVarChar(50), 
    @Description NVarChar(200), 
    @SysopUID Int, 
    @IsPublic Bit, 

    @GroupName NVarChar(50), 
    @GroupOrder Int, 
    @MailEnable Bit,

    @ShowList Bit = 1,
    @MainShowList Bit = 1,
    @BoardStyle Bit, 


    @HeaderHtml NVarChar(4000),
    @FooterHtml NVarChar(4000)
As
    Insert Into Boards (BoardAlias, Title, Description, SysopUID, IsPublic, BoardStyle, GroupName, GroupOrder, MailEnable, HeaderHtml, FooterHtml) 
    Values (@BoardAlias, @Title, @Description, @SysopUID, @IsPublic, @BoardStyle, @GroupName, @GroupOrder, @MailEnable, @HeaderHtml, @FooterHtml)
Go 
