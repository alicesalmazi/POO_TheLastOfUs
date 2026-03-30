namespace TLOU___ATV;


// Classe Item:
public class Item
{

    // Atributos privados: string nome, int quantidade, int pesoUnitario.
    private string nome;
    //Propriedade do atributo nome
    public string Nome 
    {
        get {return nome;} 
        set
        {
        // Propriedades públicas (get/set) com validação: Nome não pode ser vazio, 
            if (value != null)
            {
                Console.WriteLine("Nome não pode ser vazio!");
            }
            nome = value;

        }
    }

    private int quantidade;
    public int Quantidade 
    {
        get {return quantidade;} 
        set
        {
        // Quantidade não pode ser negativa, 
            if (value < 0)
            {
                Console.WriteLine("Quantidade não pode ser negativa!");
            }
            quantidade = value;
        }
    }

    private int pesoUnitario;
    public int PesoUnitario 
    {
        // PesoUnitario não pode ser zero ou negativo.
        get {return pesoUnitario;} 
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Peso não pode ser 0 ou negativo!");
            }
            pesoUnitario = value;   
        }
    }    
    // Método double PesoTotal() que calcula quantidade * pesoUnitario.
    public double PesoTotal()
    {
        pesoTotal = quantidade * pesoUnitario;
        return pesoTotal;
    }

}