
namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!");

            Console.Write("Please enter the operator: ");
            string? chosenOperator = Console.ReadLine();

            Console.Write("Please enter the first number: ");
            string? firstArgument = Console.ReadLine();
            int firstNumber = int.Parse(firstArgument);

            Console.Write("Please enter the second number: ");
            string? secondArgument = Console.ReadLine();
            int secondNumber = int.Parse(secondArgument);

            int answer = 0;
            if (chosenOperator == "+")
            {
                answer = firstNumber + secondNumber;
            }
            else if (chosenOperator == "-")
            {
                answer = firstNumber - secondNumber;

            }
            else if (chosenOperator == "*")
            {
                answer = firstNumber * secondNumber;
            }
            else if (chosenOperator == "/")
            {
                answer = firstNumber / secondNumber;
            }    
            Console.WriteLine($"The answer is {answer}.");
            
        }
    }
}
