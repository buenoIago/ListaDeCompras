using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloProduto;
using ListaDeCompras.ConsoleApp.ModuloListaCompras;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;

public class ContextoJson
{
    public List<Categoria> categorias { get; set; } = new List<Categoria>();
    public List<Produto> Produtos { get; set; } = new List<Produto>();
    public List<ListaCompras> listaCompras { get; set; } = new List<ListaCompras>();
    private readonly string caminhoArquivo;

    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string caminhoDiretorio = Path.Combine(caminhoAppData, "ListaDeCompras");

        Directory.CreateDirectory(caminhoDiretorio);

        caminhoArquivo = Path.Combine(caminhoDiretorio, "dados.json");
    }

    public void Salvar()
    {
        string caminhoDiretorio = "C:\\Users\\Cliente\\Downloads";

        string caminhoArquivo = caminhoDiretorio + "\\dados.Json";

        JsonSerializerOptions opcoesJson =  new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string JsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, JsonString);
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return;

        string JsonString = File.ReadAllText(caminhoArquivo);

        JsonSerializerOptions opcoesJson =  new JsonSerializerOptions();
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoJson? contextoSalvo = JsonSerializer.Deserialize<ContextoJson>(JsonString, opcoesJson);

        if (contextoSalvo == null)
            return;
        
        this.categorias = contextoSalvo.categorias;
        this.Produtos = contextoSalvo.Produtos;
        this.listaCompras = contextoSalvo.listaCompras;

    }
}
