using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ConsoleMaster
    {
        public static int Promt(string message) // ввод с консоли
        {
            Console.Write(message);
            string value = (Console.ReadLine());
            int result = Convert.ToInt32(value);
            return result;
        }
    }
}
