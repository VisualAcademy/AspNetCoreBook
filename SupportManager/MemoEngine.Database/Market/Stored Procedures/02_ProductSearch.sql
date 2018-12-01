--[24] 상품 검색 : SearchResults.aspx
CREATE Procedure ProductSearch
(
    @Search NVarChar(7)  -- 검색어(7자로 제한)
)
AS
    SELECT 
        ProductId,
        ModelName,
        ModelNumber,
        SellPrice, 
        ProductImage
    FROM 
        Products
    WHERE 
        ModelNumber LIKE '%' + @Search + '%' 
    OR
        ModelName LIKE '%' + @Search + '%'
    OR
        Description LIKE '%' + @Search + '%'
Go
