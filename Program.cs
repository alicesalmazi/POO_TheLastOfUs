using System.Net.ServerSentEvents;
using TLOU___ATV;

Console.WriteLine("============================================");
Console.WriteLine("|              The Last Of Us              |");
Console.WriteLine("============================================\n\n");

Mochila minhaMochila = new Mochila();

minhaMochila.OnCapacidadeQuaseCheia += (sender, e) =>{
    Console.WriteLine("\n[AVISO]: Sua mochila está ficando pesada! (Acima de 90%)");
};
 
Console.WriteLine("-------------- TUTORIAL COLETA --------------");
Console.WriteLine("Aventureiro, neste momento você aprenderá a adicionar itens a mochila.\nEscolha um item para sua jornada:");
Console.WriteLine("(1) Faca (0.3kg)\n(2) Garrafa de Água (0.5kg)\n(3) Tijolo (1.0kg)\n(0) Sair");

bool tutorialColeta = true;

while(tutorialColeta){

    Console.WriteLine("\nEscolha: ");
    string escolha = Console.ReadLine()?.Trim() ?? "";

    if (!int.TryParse(escolha, out int escolhaN))
    {
        Console.WriteLine("Digite um valor válido!");
        continue;
    }

    if (escolhaN == 0)
    {
        Console.WriteLine("\nSaindo do tutorial de coleta. Encaminhando para a segunda parte do tutorial...\n");
        tutorialColeta = false;
        break;
    }

    Item novoItem = new Item();

    if (escolhaN == 1)
    {
        novoItem.Nome = "Faca";
        novoItem.Quantidade = 1;
        novoItem.PesoUnitario = 0.3;
    }
    else if (escolhaN == 2)
    {
        novoItem.Nome = "Garrafa de Água";
        novoItem.Quantidade = 1;
        novoItem.PesoUnitario = 0.5;
    }
    else if (escolhaN == 3)
    {
        novoItem.Nome = "Tijolo";
        novoItem.Quantidade = 1;
        novoItem.PesoUnitario = 1.0;
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
        Console.WriteLine($"Mochila cheia! Não foi possível adicionar {novoItem.Nome}.");
    }
}

Console.WriteLine("-------------- TUTORIAL USO --------------");
Console.WriteLine("\nAventureiro, neste momento você aprenderá a utilizar os itens da mochila.");

bool tutorialUso = true;

while (tutorialUso)
{
    minhaMochila.ExibirItens(); 
    
    Console.WriteLine("Digite o nome do item na qual deseja remover (ou 'sair'): ");
    string itemEscolhido = Console.ReadLine()?.Trim() ?? "";

    if (itemEscolhido.ToLower() == "sair")
    {
        Console.WriteLine("\nSaindo do tutorial de uso...");
        tutorialUso = false;
        continue;
    }

    if (minhaMochila.UsarItem(itemEscolhido))
    {
        Console.WriteLine($"\nVocê usou 1 un. de {itemEscolhido}!");
    }
    else
    {
        Console.WriteLine($"\nVocê não tem {itemEscolhido} na mochila.");
    }     
}

Console.WriteLine("\nFim do tutorial. Boa sorte lá fora!");