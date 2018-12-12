CREATE TABLE [dbo].[Tarefa] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (200)  NOT NULL,
    [Prioridade]  TINYINT         NOT NULL,
    [Concluida]   BIT             NOT NULL,
    [Observacoes] NVARCHAR (1000) NULL,
    CONSTRAINT [PK_Tarefa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

