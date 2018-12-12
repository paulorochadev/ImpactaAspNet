Create procedure TarefaSelecionar
	@id int = null
AS

SELECT [Id]
      ,[Nome]
      ,[Prioridade]
      ,[Concluida]
      ,[Observacoes]
FROM   [dbo].[Tarefa]
WHERE	Id = ISNULL(@id, Id)

ORDER BY Concluida, Prioridade