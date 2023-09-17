Dictionary<string, List<int>> registeredBands = new Dictionary<string, List<int>>();
registeredBands.Add("Linkin Park", new List<int> { 10, 8, 6 });
registeredBands.Add("The Beatles", new List<int>());

void showLogoAndGreeting()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Welcome to Screen Sound!");

}

void showMenu()
{
    showLogoAndGreeting();
    Console.WriteLine("1 - Register a band");
    Console.WriteLine("2 - Show all bands");
    Console.WriteLine("3 - Rate a band");
    Console.WriteLine("4 - Show the average score of a band");
    Console.WriteLine("-1 - Exit");

    Console.Write("\nPlease type the number of your option: ");
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
            Console.WriteLine("Goodbye :)");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

void registerBand()
{
    Console.Clear();
    showOptionTitle("Register a band");
    Console.Write("Type the name of the band you want to register: ");
    string bandName = Console.ReadLine()!;
    registeredBands.Add(bandName, new List<int>());
    Console.WriteLine($"Band {bandName} succesfully registered!");
    Thread.Sleep(4000);
    Console.Clear();
    showMenu();
}

void showRegisteredBands()
{
    Console.Clear();
    showOptionTitle("Registered bands");


    foreach (string band in registeredBands.Keys)
    {
        Console.WriteLine(band);
    }

    Console.WriteLine("\nPress any key to go back to main menu");
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
    showOptionTitle("Rate band");
    Console.Write("Type the name of the band you want to rate: ");
    string bandName = Console.ReadLine()!;
    if (registeredBands.ContainsKey(bandName))
    {
        Console.Write($"Type the score you want to give {bandName}: ");
        int score = int.Parse(Console.ReadLine()!);
        registeredBands[bandName].Add(score);
        Console.WriteLine($"\nScore {score} succesfully registered to the band {bandName}");
        Thread.Sleep(2000);
        Console.Clear();
        showMenu();
    }
    else
    {
        Console.WriteLine($"\nBand {bandName} not found!");
        Console.WriteLine("Press any key to go back to main menu");
        Console.ReadKey();
        Console.Clear();
        showMenu();
    }

}

void showAverageScore()
{
    Console.Clear();
    showOptionTitle("Average score");
    Console.Write("Type the name of the band you want to see the average score: ");
    string bandName = Console.ReadLine()!;
    if (registeredBands.ContainsKey(bandName) && registeredBands[bandName].Count() > 0)
    {
        List<int> bandScores = registeredBands[bandName];
        Console.WriteLine($"\nThe avergage score for {bandName} is {bandScores.Average()}.");
        Console.WriteLine("Press any key to go back to main menu");
        Console.ReadKey();
        Console.Clear();
        showMenu();

    }
    else
    {
        Console.WriteLine($"\nBand {bandName} not found or has no rating yet!");
        Console.WriteLine("Press any key to go back to main menu");
        Console.ReadKey();
        Console.Clear();
        showMenu();
    }
}

showMenu();