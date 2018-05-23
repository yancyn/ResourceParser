using System;

namespace ResourceParser
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
            string inputFileName = string.Empty;
            string outputFileName = string.Empty;
            bool allowEmpty = false;

            string parameter = string.Empty;
            foreach (string arg in args)
            {
                if (arg == "-empty") allowEmpty = true;
                switch (parameter)
                {
                    case "-s":
                        inputFileName = arg;
                        break;
                    case "-o":
                        outputFileName = arg;
                        break;
                }

                Console.WriteLine(arg);
                parameter = arg;
            }

            Parser parser = new Parser(inputFileName, outputFileName, allowEmpty);
            parser.Process();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}