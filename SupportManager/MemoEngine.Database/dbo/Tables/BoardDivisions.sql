CREATE TABLE [dbo].[BoardDivisions]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TID] INT NOT NULL, 
    [DivisionId] INT NOT NULL, 
    [DivisionSort] [int] NOT NULL Default(0),
    [CreationDate] DATETIME NULL DEFAULT GetDate(), 
    CONSTRAINT [FK_BoardDivisions_Board] FOREIGN KEY (TID) REFERENCES [Boards]([TID]), 
    CONSTRAINT [FK_BoardDivisions_Division] FOREIGN KEY (DivisionId) REFERENCES [Divisions]([DivisionId])
)
