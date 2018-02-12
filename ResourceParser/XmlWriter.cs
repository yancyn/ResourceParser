using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResourceParser
{
    public class XmlWriter
    {
        public const string TAB = "  ";
        /// <summary>
        /// A collection of XML reserved character.
        /// </summary>
        /// <seealso cref="https://docs.oracle.com/cd/A97335_02/apps.102/bc4j/developing_bc_projects/obcCustomXml.htm"/>
        private Dictionary<string, string> ReservedCharacters = new Dictionary<string, string> {
            { "&", "&#38;" },
            { "<", "&lt;" },
            { ">", "&gt;" },
            { "'", "&#39;" },
            { "\"", "&#34;" },
        };
        private StringBuilder builder;
        public XmlWriter()
        {
            this.builder = new StringBuilder();
            AddHeader();
        }
        private void AddHeader()
        {
            string header = string.Empty;
            header += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            header += "\n<root>";
            header += "\n  <!-- ";
            header += "\n    Microsoft ResX Schema ";
            header += "\n    ";
            header += "\n    Version 2.0";
            header += "\n    ";
            header += "\n    The primary goals of this format is to allow a simple XML format ";
            header += "\n    that is mostly human readable. The generation and parsing of the ";
            header += "\n    various data types are done through the TypeConverter classes ";
            header += "\n    associated with the data types.";
            header += "\n    ";
            header += "\n    Example:";
            header += "\n    ";
            header += "\n    ... ado.net/XML headers & schema ...";
            header += "\n    <resheader name=\"resmimetype\">text/microsoft-resx</resheader>";
            header += "\n    <resheader name=\"version\">2.0</resheader>";
            header += "\n    <resheader name=\"reader\">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>";
            header += "\n    <resheader name=\"writer\">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>";
            header += "\n    <data name=\"Name1\"><value>this is my long string</value><comment>this is a comment</comment></data>";
            header += "\n    <data name=\"Color1\" type=\"System.Drawing.Color, System.Drawing\">Blue</data>";
            header += "\n    <data name=\"Bitmap1\" mimetype=\"application/x-microsoft.net.object.binary.base64\">";
            header += "\n        <value>[base64 mime encoded serialized .NET Framework object]</value>";
            header += "\n    </data>";
            header += "\n    <data name=\"Icon1\" type=\"System.Drawing.Icon, System.Drawing\" mimetype=\"application/x-microsoft.net.object.bytearray.base64\">";
            header += "\n        <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>";
            header += "\n        <comment>This is a comment</comment>";
            header += "\n    </data>";
            header += "\n                ";
            header += "\n    There are any number of \"resheader\" rows that contain simple ";
            header += "\n    name/value pairs.";
            header += "\n    ";
            header += "\n    Each data row contains a name, and value. The row also contains a ";
            header += "\n    type or mimetype. Type corresponds to a .NET class that support ";
            header += "\n    text/value conversion through the TypeConverter architecture. ";
            header += "\n    Classes that don't support this are serialized and stored with the ";
            header += "\n    mimetype set.";
            header += "\n    ";
            header += "\n    The mimetype is used for serialized objects, and tells the ";
            header += "\n    ResXResourceReader how to depersist the object. This is currently not ";
            header += "\n    extensible. For a given mimetype the value must be set accordingly:";
            header += "\n    ";
            header += "\n    Note - application/x-microsoft.net.object.binary.base64 is the format ";
            header += "\n    that the ResXResourceWriter will generate, however the reader can ";
            header += "\n    read any of the formats listed below.";
            header += "\n    ";
            header += "\n    mimetype: application/x-microsoft.net.object.binary.base64";
            header += "\n    value   : The object must be serialized with ";
            header += "\n            : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter";
            header += "\n            : and then encoded with base64 encoding.";
            header += "\n    ";
            header += "\n    mimetype: application/x-microsoft.net.object.soap.base64";
            header += "\n    value   : The object must be serialized with ";
            header += "\n            : System.Runtime.Serialization.Formatters.Soap.SoapFormatter";
            header += "\n            : and then encoded with base64 encoding.";
            header += "\n";
            header += "\n    mimetype: application/x-microsoft.net.object.bytearray.base64";
            header += "\n    value   : The object must be serialized into a byte array ";
            header += "\n            : using a System.ComponentModel.TypeConverter";
            header += "\n            : and then encoded with base64 encoding.";
            header += "\n    -->";
            header += "\n  <xsd:schema id=\"root\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">";
            header += "\n    <xsd:import namespace=\"http://www.w3.org/XML/1998/namespace\" />";
            header += "\n    <xsd:element name=\"root\" msdata:IsDataSet=\"true\">";
            header += "\n      <xsd:complexType>";
            header += "\n        <xsd:choice maxOccurs=\"unbounded\">";
            header += "\n          <xsd:element name=\"metadata\">";
            header += "\n            <xsd:complexType>";
            header += "\n              <xsd:sequence>";
            header += "\n                <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" />";
            header += "\n              </xsd:sequence>";
            header += "\n              <xsd:attribute name=\"name\" use=\"required\" type=\"xsd:string\" />";
            header += "\n              <xsd:attribute name=\"type\" type=\"xsd:string\" />";
            header += "\n              <xsd:attribute name=\"mimetype\" type=\"xsd:string\" />";
            header += "\n              <xsd:attribute ref=\"xml:space\" />";
            header += "\n            </xsd:complexType>";
            header += "\n          </xsd:element>";
            header += "\n          <xsd:element name=\"assembly\">";
            header += "\n            <xsd:complexType>";
            header += "\n              <xsd:attribute name=\"alias\" type=\"xsd:string\" />";
            header += "\n              <xsd:attribute name=\"name\" type=\"xsd:string\" />";
            header += "\n            </xsd:complexType>";
            header += "\n          </xsd:element>";
            header += "\n          <xsd:element name=\"data\">";
            header += "\n            <xsd:complexType>";
            header += "\n              <xsd:sequence>";
            header += "\n                <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />";
            header += "\n                <xsd:element name=\"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"2\" />";
            header += "\n              </xsd:sequence>";
            header += "\n              <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" msdata:Ordinal=\"1\" />";
            header += "\n              <xsd:attribute name=\"type\" type=\"xsd:string\" msdata:Ordinal=\"3\" />";
            header += "\n              <xsd:attribute name=\"mimetype\" type=\"xsd:string\" msdata:Ordinal=\"4\" />";
            header += "\n              <xsd:attribute ref=\"xml:space\" />";
            header += "\n            </xsd:complexType>";
            header += "\n          </xsd:element>";
            header += "\n          <xsd:element name=\"resheader\">";
            header += "\n            <xsd:complexType>";
            header += "\n              <xsd:sequence>";
            header += "\n                <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />";
            header += "\n              </xsd:sequence>";
            header += "\n              <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" />";
            header += "\n            </xsd:complexType>";
            header += "\n          </xsd:element>";
            header += "\n        </xsd:choice>";
            header += "\n      </xsd:complexType>";
            header += "\n    </xsd:element>";
            header += "\n  </xsd:schema>";
            header += "\n  <resheader name=\"resmimetype\">";
            header += "\n    <value>text/microsoft-resx</value>";
            header += "\n  </resheader>";
            header += "\n  <resheader name=\"version\">";
            header += "\n    <value>2.0</value>";
            header += "\n  </resheader>";
            header += "\n  <resheader name=\"reader\">";
            header += "\n    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>";
            header += "\n  </resheader>";
            header += "\n  <resheader name=\"writer\">";
            header += "\n    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>";
            header += "\n  </resheader>";
            this.builder.AppendLine(header);
        }
        public void AddNode(string root, string translation)
        {
            // handle reserved characters in xml
            foreach (KeyValuePair<string, string> word in ReservedCharacters)
                translation = translation.Replace(word.Key, word.Value);

            this.builder.AppendLine(string.Format(TAB + "<data name=\"{0}\" xml:space=\"preserve\">", root));
            this.builder.AppendLine(string.Format(TAB + TAB + "<value>{0}</value>", translation));
            this.builder.AppendLine(TAB + "</data>");
        }
        private void AddFooter()
        {
            this.builder.AppendLine("</root>");
        }
        public void Write(string outputFileName)
        {
            AddFooter();
            using (StreamWriter writer = new StreamWriter(outputFileName))
                writer.WriteLine(builder.ToString());
        }
    }
}