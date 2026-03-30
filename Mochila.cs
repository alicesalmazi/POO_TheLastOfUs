namespace TLOU___ATV;


// Classe Mochila:

public class Mochila
{
    public 

    // Atributo
    private double pesoMaximo;

    // Atributo
    private int numeroSlots;

    // Atributo privado: List<Item> itens.
    private List<Item> itens;

    // Propriedade do atributo itens
    public List Itens
    {
        get {itens;}
        set {
            itens.Add(value);
        }
    }

    // Atributo
    private double pesoAtual;

    // Propriedade double PesoAtual(get) que soma o peso total de todos os itens.
    public double PesoAtual
    {
        get {return pesoAtual;}
        set
        {
            pesoAtual ;
        }
    }

    private int slotsOcupados{get;}

    // (desafio: respeitar limite de peso ou slots? Crie um limite fictício).
    public Mochila()
    {
        pesoMaximo = 25;
        numeroSlots = 10;
    }

    // Método bool AdicionarItem(Item novoItem): Se o item já existe (mesmo nome), aumenta a quantidade 
    public bool adicionarItem(Item novoItem)
    {
        if (itens.Contains(novoItem))
        {
            Item += 1;
        }
        if (itens.Count() = numeroSlots)
        {
            
        }
    }
    
    // Método bool UsarItem(string nomeItem): Diminui a quantidade em 1. Se chegar a zero, remove da lista.
    public bool UsarItem(string nomeItem)
    {
        if (itens = 1)
        {
            itens.Remove(nomeItem);
        }
        itens -= 1;
    }

    // Desafio: Implementar um evento que alerta quando a mochila está quase cheia (acima de 90% da capacidade).
    private event System.EventHandler capacidadeBaixa;
    
    public void Capacidade(double quantidade)
    {
        if (quantidade >= pesoMaximo * 0.9)
        {
            
        }
    }
}
