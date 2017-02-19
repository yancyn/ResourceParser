# WPFLocalizeExtensionParser
Split csv to several resource files used in WPFLocalizeExtension.

## How to Export CSV in UTF-8
1. Open the file in Excel.
2. File > Save As > Unicode Text (*.txt).
3. Rename NewFile.txt to NewFile.csv.
4. Done.

## How to Use
1. Start command prompt.
2. cmd> WPFLocalizeExtensionParser.exe -s translation.csv -o Strings
3. Done.

translation.csv = source file  
outputs = Strings.en.resx, Strings.es.resx, Strings.de.resx etc
