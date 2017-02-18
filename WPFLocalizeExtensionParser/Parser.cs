using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLocalizeExtensionParser
{
    public class Parser
    {
        private const string EXTENSION = ".resx";
        private StringBuilder builder;
        private string sourceFileName;

        private string outputFileName;
        private string[] outputFiles;

        public Parser()
        {
            this.builder = new StringBuilder();
            this.sourceFileName = string.Empty;
            this.outputFileName = string.Empty;
            this.outputFiles = new string[] { };
        }
        /// <summary>
        /// Recommended constructor.
        /// </summary>
        /// <param name="sourceFileName">Input spreadsheet file name in csv format.</param>
        /// <param name="outputFileName">Output file prefix without extension i.e. Strings.</param>
        public Parser(string sourceFileName, string outputFileName)
        {
            this.builder = new StringBuilder();
            this.sourceFileName = sourceFileName;
            this.outputFileName = outputFileName;
            this.outputFiles = new string[] { };
        }
        private void GetOutputFiles(string header)
        {
            string[] headers = header.Split(new char[] { ',' });
            this.outputFiles = new string[headers.Length];
            for (int i = 0; i < outputFiles.Length; i++)
            {
                string fileName = outputFileName + headers[i] + EXTENSION;
                this.outputFiles[i] = fileName;
            }
        }
        public void Process()
        {
            int counter = 0;
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(sourceFileName))
            {
                //source = reader.ReadToEnd();
                while((line = reader.ReadLine()) != null)
                {
                    if (counter == 0) GetOutputFiles(line);
                    builder.AppendLine(line);
                    counter++;
                }
            }
            Write();
        }
        private void Write()
        {

        }
    }
}