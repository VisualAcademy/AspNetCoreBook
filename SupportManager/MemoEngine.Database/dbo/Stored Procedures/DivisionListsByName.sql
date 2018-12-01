CREATE PROCEDURE dbo.DivisionListsByName
	@SearchQuery As NVarChar(50) 
AS

    SELECT Divisions.DivisionId, Divisions.DivisionName, DivisionNameEng  
	From Divisions
	Where DivisionName Like '%' + @SearchQuery + '%'
	Order By DivisionName

RETURN 0