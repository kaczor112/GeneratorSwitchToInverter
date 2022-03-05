using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorSwitchToInverter
{
    class ExceptionManager
    {
        public static void GoException(Exception _exception)
        {
            Console.WriteLine(_exception);
            throw new NotImplementedException();
        }
    }
}
