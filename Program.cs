
namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!");

            Console.Write("Please enter the operator: ");
            string? chosenOperator = Console.ReadLine();

            Console.Write($"How many numbers do you want to {chosenOperator}? ");
            string? numArgs = Console.ReadLine();
            int numNums = int.Parse(numArgs);


            int[] chosenNums = new int[numNums];

            for (int i = 0; i < numNums; i++)
            {
                Console.Write($"Please enter number {i+1}: ");
                string? chosenArg = Console.ReadLine();
                int chosenNum = int.Parse(chosenArg);
                chosenNums[i] = chosenNum;
            }

            int answer = chosenNums[0];
            for (int i = 1; i < numNums; i++)
            {
                if (chosenOperator == "+")
                {
                    answer += chosenNums[i];
                }
                else if (chosenOperator == "-")
                {
                    answer -= chosenNums[i];;

                }
                else if (chosenOperator == "*")
                {
                    answer *= chosenNums[i];;
                }
                else if (chosenOperator == "/")
                {
                    answer /= chosenNums[i];;
                }    
            }

            Console.WriteLine($"The answer is {answer}.");

            Console.ReadLine();
        }
    }
}
