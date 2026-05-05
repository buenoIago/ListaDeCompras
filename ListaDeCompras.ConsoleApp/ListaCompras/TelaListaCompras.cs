using System;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ListaCompras;

public class TelaListaCompras : TelaBase<ListaCompras>, ITelaOpcoes, ITelaCrud
{
    public TelaListaCompras(
        RepositorioListaCompras repositorioListaCompras
    ) : base("Lista de Compras", repositorioListaCompras)
    {
    }

    public override string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"1 - Cadastrar lista de compras");
        Console.WriteLine($"2 - Editar  lista de compras");
        Console.WriteLine($"3 - Excluir lista de compras");
        Console.WriteLine($"4 - Visualizar listas de compras");
        Console.WriteLine($"5 - Adicionar item à lista de compras");
        Console.WriteLine($"6 - Remover item da lista de compras");
        Console.WriteLine($"7 - Visualizar itens de listas de compras");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void AdicionarItem()
    {

    }

    public void RemoverItem()
    {

    }

    public void VisualizarItens()
    {

    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        
    }

    protected override ListaCompras ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da lista: ");
        string nome = Console.ReadLine() ?? string.Empty;

        return new ListaCompras(nome);
    }
}