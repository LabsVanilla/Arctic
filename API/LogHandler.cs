using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arctic.API
{
    internal class LogHandler
    {
        internal static void Log(string Identify, string message, bool value = false)
        {
            //if (!value) return;
            var today = System.DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{today.ToString("HH:mm:ss")}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[Arctic Client] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"[{Identify}] ");
            if (value == true)
            { Console.ForegroundColor = ConsoleColor.Green; }
            Console.Write(message);
            Console.WriteLine();
            
        }

        internal static void Error(string message, string Identify, bool value = true)
        {
            if (!value) return;
            var today = System.DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{today.ToString("HH:mm:ss")}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[Arctic Client] ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[{Identify}]: ");
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.WriteLine();

        }

        internal static void Loader(string Identify, string message, bool value = false)
        {
            //if (!value) return;
            var today = System.DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{today.ToString("HH:mm:ss")}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[Arctic Loader] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"[{Identify}] ");
            if (value == true)
            { Console.ForegroundColor = ConsoleColor.Green; }
            Console.Write(message);
            Console.WriteLine();

        }


    }
}
