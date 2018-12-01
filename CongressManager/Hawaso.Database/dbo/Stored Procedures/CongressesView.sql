-- 해당 글을 세부적으로 읽어오는 저장 프로시저: CongressesView
CREATE PROCEDURE [dbo].[CongressesView]
    @Id Int
As
    -- 조회수 카운트 1증가
    Update Congresses Set ReadCount = ReadCount + 1 Where Id = @Id
    
    -- 모든 항목 조회
    Select * From Congresses Where Id = @Id
Go
