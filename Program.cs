
namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!");
            Console.Write("What is the first number? ");
            string? firstNumber = Console.ReadLine();
            Console.Write("What is the second number? ");
            string? secondNumber = Console.ReadLine();
            int answer = int.Parse(firstNumber) * int.Parse(secondNumber);
            Console.WriteLine($"Multiplying these two numbers gives {answer}.");
        }
    }
}
