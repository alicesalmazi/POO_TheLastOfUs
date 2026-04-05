using System.Net.ServerSentEvents;
using TLOU___ATV;

Console.WriteLine("==================");
Console.WriteLine("| The Last Of Us |");
Console.WriteLine("==================");

Console.WriteLine("Fase 1 - Tutorial\n");
Console.WriteLine("-----------------");

Mochila minhaMochila = new Mochila();

minhaMochila.OnCapacidadeQuaseCheia += (sender, e) =>{
    Console.WriteLine("\n[AVISO]: Sua mochila está ficando pesada! (Acima de 90%)");
};
 
Console.WriteLine("------------- TUTORIAL COLETA -------------");
Console.WriteLine("Aventureiro, neste momento você aprenderá a adicionar itens a mochila.\nEscolha um item para sua jornada:");
Console.WriteLine("(1) Faca (0.3kg)\n(2) Garrafa de Água (0.5kg)\n(3) Tijolo (1.0kg)\n(0) Sair");

bool tutorialColeta = true;

while(continuar){

    Console.WriteLine("\nEscolha: ");
    int escolha = Console.ReadLine();

    if (!int.TryParse(escolha, out int escolha))
    {
        Console.WriteLine("Digite um valor válido!");
        continue;
    }

    if (escolha == 0)
    {
        Console.WriteLine("Saindo do tutorial de coleta. Encaminhando para a segunda parte do tutorial...");
        continuar = false;
        break;
    }

    Item novoItem = new Item();

    if (escolha == 1)
    {
        novoItem.Nome = "Faca";
        novoItem.quantidade = 1;
        novoItem.pesoUnitario = 0.3;
    }
    else if (escolha == 2)
    {
        novoItem.Nome = "Garrafa de Água";
        novoItem.quantidade = 1;
        novoItem.pesoUnitario = 0.5;
    }
    else if (escolha == 3)
    {
        novoItem.Nome = "Tijolo";
        novoItem.quantidade = 1;
        novoItem.pesoUnitario = 1.0;
    }
    else
    {
        Console.WriteLine("Opção inválida! Escolha 1, 2, 3 ou 0.");
        continue;
    }

    if (minhaMochila.AdicionarItem(novoItem))
    {
        Console.WriteLine($"{novoItem.Nome} adicionado com sucesso!");
    }
    else
    {
        Console.WriteLine($"Não foi possível {novoItem.Nome} a mochila!");
    }
}

Console.WriteLine("------------- TUTORIAL USO -------------");
Console.WriteLine("\nAventureiro, neste momento você aprenderá a utilizar os itens da mochila.");

bool tutorialUso = true;

while (tutorialUso)
{
    minhaMochila.ExibirItens(); 
    
    Console.WriteLine("Digite o nome do item na qual deseja remover (ou 'sair'): ");
    string itemEscolhido = Console.ReadLine();

    if (itemEscolhido.ToLower() == "sair")
    {
        Console.WriteLine("Saindo do tutorial de uso...");
        tutorialUso = false;
        continue;
    }

    if (minhaMochila.UsarItem(escolha))
    {
        Console.WriteLine($"Você usou 1 un. de {itemEscolhido}!");
    }
    else
    {
        Console.WriteLine($"Você não tem {itemEscolhido} na mochila.");
    }     
}

Console.WriteLine("\nFim do tutorial. Boa sorte lá fora!");