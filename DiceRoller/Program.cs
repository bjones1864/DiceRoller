Console.WriteLine("Welcome to my dice roller!");

do
{
    int sides;
    
    do
    {
        Console.WriteLine("Please enter the number of sides you would like you dice to have:");

        while (!int.TryParse(Console.ReadLine(), out sides))
        {
            Console.WriteLine("Number of sides must be a number. Please enter a number:");
        }
        if(sides <= 0)
        {
            Console.WriteLine("Number of sides must be a positive number above zero");
        }
        else
        {
            break;
        }
    }while(true);

    int roll1 = DiceRoll(sides);
    int roll2 = DiceRoll(sides);

    Console.WriteLine($"Rolling!\nDice 1: {roll1} Dice 2:{roll2}");

    if(sides == 6)
    {
        Console.WriteLine($"{CheckForCombo(roll1, roll2)} ~ {CheckForWinSix(roll1, roll2)}");
    }
    else
    {
        Console.WriteLine($"{CheckForWin(roll1, roll2, sides)}");
    }

    Console.WriteLine("Would you like to roll again?  Enter y to continue rolling, enter anything else to end");
    if (!Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase)) break;
    
}while(true);

Console.WriteLine("Thanks for playing!");

//I think this method is kinda silly
//it would be better to make one random object and call it in the program
//instead of making a new random object everytime a dice roll is needed
static int DiceRoll(int n)
{
    Random rand = new Random();
    return rand.Next(1, n+1);
}

static string CheckForCombo(int x, int y)
{
    if(x == 1 && y == 1)
    {
        return "Snake Eyes";
    }
    else if(x == 1 && y == 2)
    {
        return "Ace Deuce";
    }
    else if (x == 2 && y == 1)
    {
        return "Ace Deuce";
    }
    else if(x == 6 && y == 6)
    {
        return "Box Cars";
    }
    else
    {
        return "";
    }
}

static string CheckForWinSix(int x, int y)
{
    if(x + y == 7 || x + y == 11)
    {
        return "Win";
    }
    else if((x + y == 2  || x + y == 3) || x + y == 12)
    {
        return "Craps";
    }
    else
    {
        return "";
    }
}

static string CheckForWin(int x, int y, int n)
{
    if(x + y == n + 1 || x + y == 2*n - 1)
    {
        return "Win";
    }
    else if ((x + y == 2 || x + y == 3) || x + y == n*2)
    {
        return "Craps";
    }
    else
    {
        return "";
    }
}