string greetingMessage = "Boas vindas ao Screen Sound";
Dictionary<string, List<int>> registeredBands = new Dictionary<string, List<int>>();
registeredBands.Add("Linkin Park", new List<int> { 10, 8, 6 });
registeredBands.Add("The Beatles", new List<int>());

void showLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(greetingMessage);
}
void showMenu()
{
    showLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string rawChosenOption = Console.ReadLine()!;
    int parsedChosenOption = int.Parse(rawChosenOption);

    switch (parsedChosenOption)
    {
        case 1:
            registerBand();
            break;
        case 2:
            showRegisteredBands();
            break;
        case 3:
            rateBand();
            break;
        case 4:
            showAverageScore();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void registerBand()
{
    Console.Clear();
    showOptionTitle("Registrar banda");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string bandName = Console.ReadLine()!;
    registeredBands.Add(bandName, new List<int>());
    Console.WriteLine($"A banda {bandName} foi registrada com sucesso!");
    Thread.Sleep(4000);
    Console.Clear();
    showMenu();
}

void showRegisteredBands()
{
    Console.Clear();
    showOptionTitle("Bandas cadastradas");


    foreach (string band in registeredBands.Keys)
    {
        Console.WriteLine($"Banda: {band}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    showMenu();

}

void showOptionTitle(string title)
{
    int titleLength = title.Length;
    string asteriscs = string.Empty.PadLeft(titleLength, '*');
    Console.WriteLine(asteriscs);
    Console.WriteLine(title);
    Console.WriteLine(asteriscs + "\n");
}

void rateBand()
{
    Console.Clear();
    showOptionTitle("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string bandName = Console.ReadLine()!;
    if (registeredBands.ContainsKey(bandName))
    {
        Console.Write($"Qual a nota que a banda {bandName} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        registeredBands[bandName].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {bandName}");
        Thread.Sleep(2000);
        Console.Clear();
        showMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandName} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        showMenu();
    }

}

void showAverageScore()
{
    Console.Clear();
    showOptionTitle("Exibir média da banda");
    Console.Write("Digite o nome da banda que deseja exibir a média: ");
    string bandName = Console.ReadLine()!;
    if (registeredBands.ContainsKey(bandName))
    {
        List<int> bandScores = registeredBands[bandName];
        Console.WriteLine($"\nA média da banda {bandName} é {bandScores.Average()}.");
        Console.WriteLine("Digite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        showMenu();

    }
    else
    {
        Console.WriteLine($"\nA banda {bandName} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        showMenu();
    }
}

showMenu();