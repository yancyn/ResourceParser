using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLocalizeExtensionParser
{
    public class XmlWriter
    {
        private const string TAB = "  ";
        private StringBuilder builder;
        public XmlWriter()
        {
            this.builder = new StringBuilder();
            AddHeader();
        }
        private void AddHeader()
        {

        }
        public void AddNode(string root, string translation)
        {
            this.builder.AppendLine(string.Format(TAB + "<data name=\"{0}\" xml:space=\"preserve\">", root));
            this.builder.AppendLine(string.Format(TAB + TAB + "<value>{0}</value>", translation));
            this.builder.AppendLine(TAB + "</data>");
        }
        private void AddFooter()
        {
            this.builder.AppendLine("<root>");
        }
        public void Write(string outputFileName)
        {
            // AddFooter();
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.WriteLine(builder.ToString());
            }
        }
    }
}