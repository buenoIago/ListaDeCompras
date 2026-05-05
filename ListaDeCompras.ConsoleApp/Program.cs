using System.Collections;
using System.Collections.Generic;
using ListaDeCompras.ConsoleApp;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ListaCompras;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

// List<Categoria> registros = new List<Categoria>();
// registros.Add(new Categoria("teste", "branco"));

// foreach (Categoria c in registros)
// {
//     System.Console.WriteLine(c.Id);
// }

// return;

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

            if (telaCrud is TelaListaCompras telaListaCompras)
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