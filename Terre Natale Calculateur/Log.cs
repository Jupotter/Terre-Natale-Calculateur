using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terre_Natale_Calculateur
{
    static class Log
    {
        static Log()
        {
            Logger = new LogToFile();
        }

        public static LogToFile Logger { get; private set; }
    }
}
