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

        public static void Print(string st, ConsoleColor color = ConsoleColor.Green)
        {

            
            foreach (var elem in st)
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
