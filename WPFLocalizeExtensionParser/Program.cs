using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLocalizeExtensionParser
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <remarks></remarks>
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
