# XpdfNet
A C# wrapper for Xpdf. Read text from a pdf file.


Usage
------
```csharp
using XpdfNet;

var pdfHelper = new XpdfHelper();

string content = pdfHelper.ToText("./pathToFile.pdf");
```
