using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResourceParser
{
    public class Parser
    {
        private const string EXTENSION = ".resx";
        private StringBuilder builder;
        private string sourceFileName;
        private bool allowEmpty;

        private string outputFileName;
        private string[] outputFiles;
        private List<XmlWriter> writers;

        public Parser()
        {
            this.builder = new StringBuilder();
            this.sourceFileName = string.Empty;
            this.outputFileName = string.Empty;
            this.outputFiles = new string[] { };
            this.writers = new List<XmlWriter>();
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
            this.writers = new List<XmlWriter>();
        }
        public Parser(string sourceFileName, string outputFileName, bool allowEmpty)
        {
            this.builder = new StringBuilder();
            this.sourceFileName = sourceFileName;
            this.outputFileName = outputFileName;
            this.allowEmpty = allowEmpty;
            this.outputFiles = new string[] { };
            this.writers = new List<XmlWriter>();
        }
        private void GetOutputFiles(string header)
        {
            string[] headers = header.Split(new char[] { '\t' });
            this.outputFiles = new string[headers.Length];
            for (int i = 0; i < outputFiles.Length; i++)
            {
                string fileName = outputFileName + "." + headers[i].Trim(new char[] { '"' }) + EXTENSION;
                this.outputFiles[i] = fileName;
                Console.Write(this.outputFiles[i] + "\t");

                XmlWriter writer = new XmlWriter();
                this.writers.Add(writer);
            }
        }
        private string GetRootWord(string sentence)
        {
            string root = sentence;
            // TODO: Define invalid character in resource identifier
            string[] invalidCharacters = new string[] { " ", ".", ",", "/", "@", "!", "(", ")", ">", "<", "=", "©" };
            foreach (string invalidCharacter in invalidCharacters)
            {
                root = root.Replace(invalidCharacter, "");
            }

            return root;
        }
        private string Pascalize(string sentence)
        {
            string pascal = string.Empty;
            string[] words = sentence.Split(new char[] { ' ' });
            foreach (string word in words)
            {
                int length = word.Length;
                pascal += word.Substring(0, 1).ToUpper();
                pascal += word.Substring(1, length - 1);
            }

            return pascal;
        }
        public void Process()
        {
            int counter = 0;
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(sourceFileName))
            {
                //source = reader.ReadToEnd();
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter == 0)
                    {
                        GetOutputFiles(line);
                    }
                    else
                    {
                        Console.WriteLine("Process " + line);
                        string[] words = line.Split(new char[] { '\t' });
                        for (int i = 0; i < Math.Min(writers.Count, words.Length); i++)
                        {
                            //string key = GetRootWord(Pascalize(words[0].Trim(new char[] { '"' })));
                            string key = GetRootWord(words[0].Trim(new char[] { '"' }));
                            string primary = string.Empty;
                            if (words.Length > 1) primary = words[1].Trim(new char[] { '"' });
                            string translation = words[i].Trim(new char[] { '"' });
                            if (!this.allowEmpty)
                            {
                                if (string.IsNullOrEmpty(translation)) translation = primary;
                            }
                            writers[i].AddNode(key, translation);
                        }
                    }

                    builder.AppendLine(line);
                    counter++;
                }
            }

            // write to output
            for (int i = 0; i < outputFiles.Length; i++)
            {
                writers[i].Write(outputFiles[i]);
            }
            Console.WriteLine("Done");
        }
    }
}