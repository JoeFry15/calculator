/* A calculator that allows the user to choose the operator, the number of values to operate on, and the values.
The program then calculates the answer, prints this to the console, and asks the user if they wish to do another
calculation. */

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            bool carryOn = true;
            while (carryOn)
            {
                Console.WriteLine("The answer is: " + PerformOneCalculation());
                Console.WriteLine("Do you wish to do another calculation? y/n: ");
                string? carryOnInput = Console.ReadLine();
                carryOn = carryOnInput == "y" ? true : false;
            }
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator!");
        }

        private static int PerformOneCalculation()
        {
            string chosenOperator = ChooseOperator("Please enter the operator: ");

            int numNums = AcceptInput($"How many numbers do you want to {chosenOperator}? ");

            int[] chosenNums = CreateArr(numNums);

            int finalAnswer = DoCalculation(chosenOperator, numNums, chosenNums);

            return finalAnswer;
        }

        private static int AcceptInput(string message)
        {
            int chosenNum;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out chosenNum));

            return chosenNum;
        } 

        private static string ChooseOperator(string message)
        {
            string chosenOperator;
            do
            {
                Console.Write(message);
                chosenOperator = Console.ReadLine()!;
            } while (!(chosenOperator == "+" || chosenOperator == "-" || chosenOperator == "*" || chosenOperator == "/"));
            return chosenOperator;
        }

        private static int DoCalculation(string opChoice, int count, int[] numsChoice)
        {
            int answer = numsChoice[0];
            for (int i = 1; i < count; i++)
            {
                if (opChoice == "+")
                {
                    answer += numsChoice[i];
                }
                else if (opChoice == "-")
                {
                    answer -= numsChoice[i];;

                }
                else if (opChoice == "*")
                {
                    answer *= numsChoice[i];;
                }
                else if (opChoice == "/")
                {
                    answer /= numsChoice[i];;
                }
            }
            return answer;
        }

        private static int[] CreateArr(int numCount)
        {
            int[] inputNumArr = new int[numCount];

            for (int i = 0; i < numCount; i++)
            {
                int inputNum = AcceptInput($"Please enter number {i+1}: ");
                inputNumArr[i] = inputNum;
            }
            return inputNumArr;
        }
    }
}
