namespace Calculator
{
    class AnswerLogger
    {
        public void answerLog(string text)
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

        public void clearLog()
        {
            if (File.Exists(@"/Users/Coding/Documents/c_sharp/calculator/log.txt"))
            {
                File.Delete(@"/Users/Coding/Documents/c_sharp/calculator/log.txt");
            }
        }
    }
}
