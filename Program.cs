/* A calculator that allows the user to choose between number calculation mode and date calculation mode. With
number calculation mode the program asks for the operator, the number of values to operate on, and the values.
The program then calculates the answer and prints this to the console. The date calculation mode asks for a date
and the number of days to be added, then calculates and prints the result. The program asks the user if they wish
to do another calculation. */


namespace calculator
{
    class Program
    {
        private const int numberCalculatorMode = 1;
        private const int dateCalculatorMode = 2;

        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            new LogClearer().ClearLog();
            bool carryOn = true;
            while (carryOn)
            {
                int calculationMode = AskForCalculationMode();
                if (calculationMode == numberCalculatorMode)
                {
                    int answer = new NumberCalculator().PerformOneCalculation();
                    Console.WriteLine($"The answer is: {answer}");
                    new AnswerLogger().LogAnswer(answer.ToString());
                }
                else if (calculationMode == dateCalculatorMode)
                {
                    string answer = new DateCalculator().PerformDateCalculation();
                    Console.WriteLine($"The answer is: {answer}");
                    new AnswerLogger().LogAnswer(answer);
                }
                Console.WriteLine("Do you wish to do another calculation? y/n: ");
                string? carryOnInput = Console.ReadLine();
                carryOn = carryOnInput == "y" ? true : false;
            }
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator!");
        }

        private static int AskForCalculationMode()
        {
            Console.Write("Which calculator do you want?\n1) Numbers\n2) Dates\n> ");
            string answer = Console.ReadLine()!;
            int answerInt = int.Parse(answer);
            return answerInt;
        }
    }

    class NumberCalculator
    {
        public int PerformOneCalculation()
        {
            string chosenOperator = ChooseOperator("Please enter the operator: ");

            int numNums = AcceptNumInput($"How many numbers do you want to {chosenOperator}? ");

            int[] chosenNums = CreateArr(numNums);

            int finalAnswer = CalculateResult(chosenOperator, numNums, chosenNums);

            return finalAnswer;
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

        private static int[] CreateArr(int numCount)
        {
            int[] inputNumArr = new int[numCount];

            for (int i = 0; i < numCount; i++)
            {
                int inputNum = AcceptNumInput($"Please enter number {i+1}: ");
                inputNumArr[i] = inputNum;
            }
            return inputNumArr;
        }

        private static int CalculateResult(string opChoice, int count, int[] numbersChoice)
        {
            int answer = numbersChoice[0];
            for (int i = 1; i < count; i++)
            {
                switch (opChoice)
                {
                    case "+":
                        answer += numbersChoice[i];
                        break;
                    case "-":
                        answer -= numbersChoice[i];
                        break;
                    case "*":
                        answer *= numbersChoice[i];
                        break;
                    case "/":
                        answer /= numbersChoice[i];
                        break;
                }
            }
            return answer;
        }

        private static int AcceptNumInput(string message)
        {
            int chosenNumber;
            while(true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out chosenNumber))
                {
                    break;
                }
                Console.WriteLine("The number you have entered is not valid, please re-enter a valid number.");
            }
            return chosenNumber;
        } 
    }

    class DateCalculator
    {
        public string PerformDateCalculation()
        {
            DateTime dateInput = AcceptDateInput("Please enter a date: ");

            int daysAdded = AcceptNumInput("Please enter the number of days to add: ");

            return dateInput.AddDays(daysAdded).ToShortDateString();
        }

        private static DateTime AcceptDateInput(string message)
        {
            DateTime dateInput;
            do
            {
                Console.Write(message);
            } while (!DateTime.TryParse(Console.ReadLine(), out dateInput));
            return dateInput;
        }
        private static int AcceptNumInput(string message)
        {
            int operandNumbers;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out operandNumbers));

            return operandNumbers;
        }
    }

    class AnswerLogger
    {
        public void LogAnswer(string text)
        {
            string path = @"/Users/Coding/Documents/c_sharp/calculator/log.txt";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, text);
            }
            else
            {
                File.AppendAllText(path, $"\n{text}");
            }
        }
    }

    class LogClearer
    {
        public void ClearLog()
        {
            if (File.Exists(@"/Users/Coding/Documents/c_sharp/calculator/log.txt"))
            {
                File.Delete(@"/Users/Coding/Documents/c_sharp/calculator/log.txt");
            }
        }   
    }
}
