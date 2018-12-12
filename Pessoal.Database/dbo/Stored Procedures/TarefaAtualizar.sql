Create procedure TarefaAtualizar
	@id int,
	@nome nvarchar(200),
	@prioridade tinyint,
	@concluida bit,
	@observacoes nvarchar(1000)
AS
Update [dbo].[Tarefa]
SET			[Nome] = @nome
			,[Prioridade] = @prioridade
			,[Concluida] = @concluida
			,[Observacoes] = @observacoes
WHERE Id = @id