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

            string parameter = string.Empty;
            foreach (string arg in args)
            {
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

            Parser parser = new Parser(inputFileName, outputFileName);
            parser.Process();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}