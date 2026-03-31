using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;

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
        var itemDaMochila = itens.Find(i => i.Nome == nomeItem);

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

    // Desafio: Implementar um evento que alerta quando a mochila está quase cheia (acima de 90% da capacidade).
    public event EventHandler OnCapacidadeQuaseCheia;
    // Se herdarem essa classe 'Mochila', o 'virtual' autoriza a modificarem esse método
    public virtual void OnCapacidadeQuaseCheiaHandler(EventArgs e)
    {
        OnCapacidadeQuaseCheia?.Invoke(this, e);
    }
}

