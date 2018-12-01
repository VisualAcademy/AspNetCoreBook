CREATE PROCEDURE dbo.DivisionLists 
AS

    SELECT Divisions.DivisionId, Divisions.DivisionName, DivisionNameEng  
	From Divisions
	Order By DivisionName

RETURN 0
