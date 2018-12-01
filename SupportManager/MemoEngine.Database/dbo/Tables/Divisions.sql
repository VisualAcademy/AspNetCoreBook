CREATE TABLE [dbo].[Divisions] (
    [DivisionId]      INT           IDENTITY (1, 1) NOT NULL,
    [DivisionName]    NVARCHAR (50) NOT NULL,
    [DivisionNameEng] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([DivisionId] ASC)
);








GO
CREATE NONCLUSTERED INDEX [IX_Divisions_DivisionName]
    ON [dbo].[Divisions]([DivisionName] ASC);

