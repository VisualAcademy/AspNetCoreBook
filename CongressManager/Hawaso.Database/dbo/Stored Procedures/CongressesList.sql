-- 게시판에서 전체 데이터 조회 
CREATE PROCEDURE [dbo].[CongressesList]
    @PageNumber Int = 1,
    @PageSize Int = 10
AS
    Select 
        [Id], [Name], [PostDate], [PostIp], [Title], [Content], [Category], 
        [Email], [ReadCount], [FileName], [FileSize], [DownCount], [CommentCount], [Step] 
    From Congresses Order By Ref Desc, RefOrder Asc
    Offset ((@PageNumber - 1) * @PageSize) Rows Fetch Next @PageSize Rows Only;
Go
