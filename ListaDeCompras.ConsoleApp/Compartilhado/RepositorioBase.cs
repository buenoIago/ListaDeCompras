using System.Collections.Generic;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    // protected EntidadeBase?[] registros = new EntidadeBase[100];
    protected List<EntidadeBase> registros = new List<EntidadeBase>();

    public void Cadastrar(EntidadeBase entidade)
    {
        registros.Add(entidade);
    }

    public bool Editar(string idSelecionado, EntidadeBase entidade)
    {
        EntidadeBase? entidadeSelecionado = SelecionarPorId(idSelecionado);

        if (entidadeSelecionado == null)
            return false;

        entidadeSelecionado.AtualizarDados(entidade);

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        EntidadeBase? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registros.Remove(registroSelecionado);

        return true;
    }

    public EntidadeBase? SelecionarPorId(string idSelecionado)
    {
        // versão 1: foreach
        foreach(EntidadeBase registro in registros) // para cada item de uma coleção,
        {
            if (registro.Id == idSelecionado)
                return registro;
        }

        return null;

        // versão 2: classica (for)
        // EntidadeBase? entidadeSelecionada = null;

        // for (int i = 0; i < registros.Count; i++)
        // {
        //     EntidadeBase? c = (EntidadeBase?) registros[i];

        //     if (c == null)
        //         continue;

        //     if (c.Id == idSelecionado)
        //     {
        //         entidadeSelecionada = c;
        //         break;
        //     }
        // }

        // return entidadeSelecionada;
    }

    public List<EntidadeBase> SelecionarTodos()
    {
        return registros;
    }
}
