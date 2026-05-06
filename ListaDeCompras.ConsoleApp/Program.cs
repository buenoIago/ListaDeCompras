using System.Text.Json;
using System.Text.Json.Nodes;
using ListaDeCompras.ConsoleApp;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloListaCompras;

// string caminhoDownLoads = "C:\\Users\\Cliente\\Downloads";
// string caminhoArquivo = caminhoDownLoads + "\\categoria.json";

// Categoria categoria = new Categoria("café", CorCategoria.Azul);
// Categoria categoria1 = new Categoria("Mercado", CorCategoria.Vermelha);

// List<Categoria> categorias = [categoria, categoria1];

// JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
// opcoesJson.WriteIndented = true;
// opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

// string jsonString = JsonSerializer.Serialize(categoria, opcoesJson);

// File.WriteAllText(caminhoArquivo, jsonString);


TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }

        if (telaSelecionada is ITelaCrud telaCrud)
        {
            if (opcaoSubMenu == "1")
                telaCrud.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaCrud.Editar();

            else if (opcaoSubMenu == "3")
                telaCrud.Excluir();

            else if (opcaoSubMenu == "4")
                telaCrud.VisualizarTodos(deveExibirCabecalho: true);

            else if (telaCrud is TelaListaCompras telaListaCompras)
            {
                if (opcaoSubMenu == "5")
                    telaListaCompras.AdicionarItem();

                else if (opcaoSubMenu == "6")
                    telaListaCompras.RemoverItem();

                else if (opcaoSubMenu == "7")
                    telaListaCompras.VisualizarItens();
            }
        }
    }
}