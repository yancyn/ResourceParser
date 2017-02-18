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
        }
        public void Add(string root, string translation)
        {
            this.builder.AppendLine(string.Format(TAB + "<data name=\"{0}\" xml:space=\"preserve\">", root));
            this.builder.AppendLine(string.Format(TAB + TAB + "<value>{0}</value>", translation));
            this.builder.AppendLine(TAB + "</data>");
        }
        public void Write(string outputFileName)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.WriteLine(builder.ToString());
            }
        }
    }
}