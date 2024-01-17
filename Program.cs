using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Dice Throwing Simulator!");

        Console.Write("How many dice rolls would you like to simulate? ");
        int numofrolls;

        while (!int.TryParse(Console.ReadLine(), out numofrolls) || numofrolls <= 0) 
        {
            Console.WriteLine("Please enter a valid whole number: ");
        }

        var diceRoller = new DiceRoller();
        int[] rollResults = diceRoller.RollDice(numofrolls);
        
        Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {numofrolls}.");

        for (int i = 0; i < rollResults.Length; i++) 
        {
            Console.Write($"{i + 2}: ");
            for (int j = 0; j < rollResults[i] * 100 / numofrolls; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");

    }
            
}

internal class DiceRoller
{
    private static readonly Random random = new Random();

    public int[] RollDice(int numberofRolls)
    {
        int[] results = new int[11];

        for (int i = 0; i < numberofRolls; i++) 
        {
            int rollSum = random.Next(1,7) + random.Next(1,7);
            results[rollSum - 2]++;
        }

        return results;
    }
}