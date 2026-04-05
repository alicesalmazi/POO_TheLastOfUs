namespace TLOU___ATV;

// Classe Mochila:

public class Mochila
{
    // Atributo
    private double pesoMaximo;

    // Atributo
    private int numeroSlots;

    // Atributo privado: List<Item> itens.
    private List<Item> itens = new List<Item>();

    // Atributo
    private double pesoAtual
    {
        get
        {
            double varSoma = 0;
            foreach (var item in itens)
            {
                varSoma += item.PesoTotal();
            }
            return varSoma;
        }
    }

    // (desafio: respeitar limite de peso ou slots? Crie um limite fictício).
    public Mochila()
    {
        pesoMaximo = 25;
        numeroSlots = 10;
    }

    // Método bool AdicionarItem(Item novoItem): Se o item já existe (mesmo nome), aumenta a quantidade 
    public bool AdicionarItem(Item novoItem)
    {
        double pesoNovoItem = novoItem.PesoTotal();

        if (this.pesoAtual + pesoNovoItem > pesoMaximo)
        {
            return false;
        }

        var itemNaMochila = itens.Find(i => i.Nome == novoItem.Nome);

        // Desafio: Implementar um evento que alerta quando a mochila está quase cheia (acima de 90% da capacidade).
        if (itemNaMochila != null)
        {
            itemNaMochila.Quantidade += novoItem.Quantidade;
        }
        else
        {
            if (itens.Count >= numeroSlots)
            {
                return false;  
            } 
            itens.Add(novoItem);
        }

        if (this.pesoAtual >= this.pesoMaximo * 0.9)
        {
            OnCapacidadeQuaseCheiaHandler(EventArgs.Empty);
        }
        return true;
    }
    
    // Método bool UsarItem(string nomeItem): Diminui a quantidade em 1. Se chegar a zero, remove da lista.
    public bool UsarItem(string nomeItem)
    {
        var itemDaMochila = itens.Find(i => i.Nome.Equals (nomeItem, StringComparison.OrdinalIgnoreCase));

        if (itemDaMochila != null)
        {
            itemDaMochila.Quantidade -= 1;

            if (itemDaMochila.Quantidade <= 0)
            {
                itens.Remove(itemDaMochila);
            }
            return true;
        }
        return false;
    }

    // Método de exibir itens (por conta de lista ser privado)
    public void ExibirItens()
    {
        Console.WriteLine("\n--- MOCHILA ---");
        if (itens.Count == 0)
        {
            Console.WriteLine("Mochila vazia!");
        }
        else
        {
            foreach (var item in itens)
            {
                Console.WriteLine($"- {item.Nome}: {item.quantidade} un. (Peso total: {item.PesoTotal()}kg.)");
            }
            Console.Write($"Peso atual da mochila: {this.pesoAtual} kg. / {this.pesoMaximo} kg.")
        }
        Console.WriteLine("-----------------------\n");
    }

    // Desafio: Implementar um evento que alerta quando a mochila está quase cheia (acima de 90% da capacidade).
    public event EventHandler? OnCapacidadeQuaseCheia;
    // Se herdarem essa classe 'Mochila', o 'virtual' autoriza a modificarem esse método
    public virtual void OnCapacidadeQuaseCheiaHandler(EventArgs e)
    {
        OnCapacidadeQuaseCheia?.Invoke(this, e);
    }
}

