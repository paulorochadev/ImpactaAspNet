Create procedure TarefaExcluir
	@id int
AS
DELETE Tarefa WHERE Id = @id