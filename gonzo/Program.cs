using System;

namespace Gonzo
{
    using Gonzo.Lib;

    class Program
    {
        static void Main(string[] args)
        {
            var again = true;
            while (again)
            {
                Console.Clear();
                Console.WriteLine("Please, input a sequence of 0 and 1 splitted by commas");
                var rawSequence = Console.ReadLine();
                try
                {
                    var sequence = new SequenceOfZeroesOnes(rawSequence);
                    var result = sequence.CalculateMaxOnesAfterRemoveItem();
                    Console.WriteLine($"Max Ones After Remove Any Item: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.WriteLine("Again? (y/n): ");
                again = Console.ReadLine() == "y";
            }            
        }
    }
}
