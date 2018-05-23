# Resource Parser
Split csv to several resource files.

## Export Google Spreadhsheet to CSV
1. Open online source document.
2. Remove key, type, description and additional columns as well as extra empty rows.
3. Remain language column only with language code as header i.e. ms, ko, ja.[^1]
4. Download as *.xslx from Google Spreadsheet.
5. Open the file in Excel.
6. File > Save As > Unicode Text (*.txt).
7. Rename NewFile.txt to NewFile.csv.
8. Done.

## How to Use
``cmd> ResourceParser.exe -s translation.csv -o Strings -empty``

translation.csv = source file  
outputs = Strings.en.resx, Strings.es.resx, Strings.de.resx etc  
-empty = optional. If not provided blank translation will be replaced by first language after key column.

## References
- https://github.com/SeriousM/WPFLocalizationExtension

[^1]: https://msdn.microsoft.com/en-us/library/hh441729.aspx