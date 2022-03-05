using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorSwitchToInverter
{
    class ExceptionManager : FileManager
    {
        public static void GoException(Exception _exception)
        {
            Console.WriteLine("Press: 'Tab' to expand. 'Enter' to save. Any key to close.\n\nException: " + _exception.Message + "\n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Tab:
                    Console.WriteLine(_exception + "\n");
                    var tempKey = Console.ReadKey();

                    if(tempKey.Key == ConsoleKey.Enter)
                    {
                        goto case ConsoleKey.Enter;
                    }
                    break;

                case ConsoleKey.Enter:
                    string tempstring = _exception + "\n\n";
                    SaveFile("ExceptionSave", tempstring, false);
                    break;

                default: break;
            }
        }
    }
}
