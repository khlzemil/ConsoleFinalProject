using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject.Helper
{
    internal class ForEdit
    {

        public static void Print(object obj, ConsoleColor color = ConsoleColor.Green)
        {
            string text = obj as string;
            foreach (var elem in text)
            {
                Console.ForegroundColor = color;
                Console.Write(elem);
                Thread.Sleep(10);
                Console.ResetColor();

            }
            Console.WriteLine("");

        }
    }
}
