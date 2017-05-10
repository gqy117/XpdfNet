# XpdfNet
A C# wrapper for Xpdf. Read text from a pdf file.

Branch  | Build Status |
-------- | :------------: |
master | [![Build status](https://ci.appveyor.com/api/projects/status/50tcsir5rpwmw4w7?svg=true)](https://ci.appveyor.com/project/gqy117/xpdfnet) |

Usage
------
```csharp
using XpdfNet;

var pdfHelper = new XpdfHelper();

string content = pdfHelper.ToText("./pathToFile.pdf");
```
