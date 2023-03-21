using System.Text.RegularExpressions;

namespace ConsoleClient.MessageHandler
{
    internal class ConsoleDialogManager
    {
        static Regex regex = new Regex("[0-9]");
        static string CurrentMessage { get; set; }
        static ConsoleColor CurrentColor { get; set; }
        static void SetCurrentConsoleColorWithCurrentMessage(ConsoleColor color, string message)
        {
            CurrentColor = color;
            CurrentMessage = message;
        }
        public static string HandleMessage(string message, ConsoleColor color)
        {
            SetCurrentConsoleColorWithCurrentMessage(color, message);
            ShowCurrentMessage();
            var answer = string.Empty;

            if (CurrentMessage.EndsWith("Age: "))
            {
                answer = EnterNumber();
            }
            else
            {
                answer = EnterText();
            }

            Console.ForegroundColor = ConsoleColor.White;
            return answer;
        }

        private static void ShowCurrentMessage()
        {
            Console.ForegroundColor = CurrentColor;
            Console.Write(CurrentMessage);
        }

        private static string EnterText()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            var answer = Console.ReadLine();
            CheckInput(false, answer == string.Empty);
            return answer;
        }
        private static string EnterNumber()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            var answer = Console.ReadLine();
            CheckInput(
                  !regex.IsMatch(answer),
                  answer == string.Empty);

            return answer;
        }
        private static void CheckInput(bool isNumberValue, bool isEmpty)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (isEmpty)
            {
                PromptUserToContinue("Input cant be empty!");

                if (isNumberValue)
                {
                    ShowCurrentMessage();
                    EnterNumber();
                }
                else
                {
                    ShowCurrentMessage();
                    EnterText();
                }
            }
            if (isNumberValue)
            {
                PromptUserToContinue("Wrong input! Can only contain numbers");
                Console.Write(CurrentMessage);
                EnterNumber();
            }
        }
        private static void PromptUserToContinue(string? customMessage)
        {
            if (customMessage != null)
                Console.WriteLine(customMessage);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
