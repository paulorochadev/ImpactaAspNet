Create procedure TarefaInserir
	@nome			nvarchar(200),
	@prioridade		tinyint,
	@concluida		bit,
	@observacoes	nvarchar(1000)
as
INSERT INTO [dbo].[Tarefa]
           ([Nome]
           ,[Prioridade]
           ,[Concluida]
           ,[Observacoes])
	output inserted.Id
    VALUES
           (@nome		
           ,@prioridade	
           ,@concluida	
           ,@observacoes)