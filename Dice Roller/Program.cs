
bool runProgram = true;

while (runProgram)
{
    Console.Clear();
    Console.WriteLine("Welcome to the Dice Roller");

    int diceSides = getDiceSides();

    Console.WriteLine("\nPress any key to roll your dice!");
    Console.ReadKey();
    Console.Clear();

    int diceRoll = diceRoller(diceSides);
    int diceRoll2 = diceRoller(diceSides);
    int total = diceRoll + diceRoll2;

    Console.WriteLine($"You rolled {diceRoll} and {diceRoll2}");
    Console.WriteLine($"\nYour total was {diceRoll + diceRoll2}");


    if (diceSides == 6)
    {
        Console.WriteLine(diceCombosSix(diceRoll, diceRoll2));

        diceTotalsSix(total);
    }
    else if (diceSides == 20) 
    {
        diceCombosTwenty(diceRoll, diceRoll2);
    }

    runProgram = contProgram();
}


static int diceRoller(int diceSides)
{
    Random random = new Random();

    return random.Next(1, diceSides + 1);
}





static int getDiceSides()
{
    int diceSides;
    while (true)
    {
        Console.Write("\nEnter the side number for the pair of dice you'll be using: ");

        try
        {
            diceSides = int.Parse(Console.ReadLine());
            if (diceSides < 1 || diceSides > 20) 
            {
                throw new ArgumentOutOfRangeException();
            }
            break;
        }
        catch(OverflowException e)
        {
            Console.WriteLine("\nNumber too big! Try again!");
        }
        catch(FormatException e)
        {
            Console.WriteLine("\nNot a valid input! Try again!");
        }
        catch(ArgumentOutOfRangeException e)
        {
            Console.WriteLine("\nSorry, we don't carry dice that big! Try again!");
        }
    }
    return diceSides;
}





static string diceCombosSix(int dice1, int dice2)
{
    if (dice1 == 1 && dice2 == 1)
    {
        return "\nYou got snake eyes!";
    }
    else if ((dice1 == 1 || dice2 == 1) && (dice1 == 2 || dice2 == 2))
    {
        return "\nYou got an Ace Deuce!";
    }
    else if (dice1 == 6 && dice2 == 6)
    {
        return "\nYou got box cars!";
    }
    else
    {
        return "";
    }
}





static string diceTotalsSix(int total)
{
    if (total == 7 || total == 11)
    {
        return $"\nYour total {total} was a win!";
    }
    else if (total == 2 || total == 3 || total == 12)
    {
        return $"\nYour total {total} was a Craps!";
    }
    else
    {
        return "";
    }
}





static bool contProgram()
{
    Console.WriteLine("\nWould you like to roll again?(Y/N): ");
    string answer = Console.ReadLine().ToLower().Trim();
    while (answer != "y" && answer != "n")
    {
        Console.WriteLine("\nPlease enter a valid answer.(Y/N): ");
        answer = Console.ReadLine().ToLower().Trim();
    }

    if (answer == "y")
    {
        return true;
    }
    else
    {
        return false;
    }
}





static void diceCombosTwenty(int dice1, int dice2)
{
    if (dice1 == 20 && dice2 == 20)
    {
        Console.WriteLine("\nHoly crap, two crits!? Are you cheating?");
    }
    else if (dice1 == 1 && dice2 == 1)
    {
        Console.WriteLine("\nDarn, two critical fails? Throw those dice out!");
    }
    else if ((dice1 == 20 || dice2 == 20) && (dice1 == 1 || dice2 == 1))
    {
        Console.WriteLine("\nA critical success and fail, I don't know what to make of this....");
    }
    else if (dice1 == 1 || dice2 == 1)
    {
        Console.WriteLine("\nYou got a critical failure! Sorry!");
    }
    else if (dice1 == 20 || dice2 == 20)
    {
        Console.WriteLine("\nYou got a critical success! Way to go!");
    }
}