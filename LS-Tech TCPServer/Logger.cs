using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS_Tech_TCPServer
{
    internal class Logger
    {
        public static void PrintError(string errorMessage, int cursorTopPosition, string prevMessage = "")
        {
            Console.Clear();
            Console.SetCursorPosition(0, cursorTopPosition);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (prevMessage != string.Empty)
                Console.WriteLine(prevMessage);
        }

        public static void PrintError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintNotification(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
