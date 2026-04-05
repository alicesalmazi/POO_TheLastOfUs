namespace TLOU___ATV;

// Classe Item:
public class Item
{

    // Atributos privados: string nome, int quantidade, int pesoUnitario.
    private string nome = string.Empty;
    //Propriedade do atributo nome
    public string Nome 
    {
        get {return nome;} 
        set
        {
        // Propriedades públicas (get/set) com validação: Nome não pode ser vazio
            if (value == null)
            {
                throw new Exception("Nome não pode ser vazio!");
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
        // Propriedades públicas (get/set) com validação: Quantidade não pode ser negativa
            if (value < 0)
            {
                throw new Exception("Quantidade não pode ser negativa!");
            }
            quantidade = value;
        }
    }

    private double pesoUnitario;
    public double PesoUnitario 
    {
        // Propriedades públicas (get/set) com validação: PesoUnitario não pode ser zero ou negativo.
        get {return pesoUnitario;} 
        set
        {
            if (value <= 0)
            {
                throw new Exception("Peso não pode ser 0 ou negativo!");
            }
            pesoUnitario = value;   
        }
    }    
    // Método double PesoTotal() que calcula quantidade * pesoUnitario.
    public double PesoTotal()
    {
        return quantidade * pesoUnitario;
    }

}