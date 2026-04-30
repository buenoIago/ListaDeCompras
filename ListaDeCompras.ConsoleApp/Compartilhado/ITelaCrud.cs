internal interface ITelaCrud
{
    void Cadastrar();
    void Editar();
    void Excluir();
    void VisualizarTodos(bool deveExibirCabecalho);
}