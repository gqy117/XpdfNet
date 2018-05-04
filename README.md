# XpdfNet
A C# wrapper for Xpdf. Read text from a pdf file.

Appveyor | TravisCI | Code Coverage| Codacy | Nuget |
-------- | :------------: | :------------: | :------------: | :------------: |
[![Build Status](https://ci.appveyor.com/api/projects/status/50tcsir5rpwmw4w7?svg=true)](https://ci.appveyor.com/project/gqy117/xpdfnet)|[![Build Status](https://travis-ci.org/gqy117/XpdfNet.svg?branch=master)](https://travis-ci.org/gqy117/XpdfNet)|[![codecov](https://codecov.io/gh/gqy117/XpdfNet/branch/master/graph/badge.svg)](https://codecov.io/gh/gqy117/XpdfNet)|[![Codacy Badge](https://api.codacy.com/project/badge/Grade/018a69933f1246fe82c5eb6b78e23ad4)](https://app.codacy.com/app/gqy117/XpdfNet?utm_source=github.com&utm_medium=referral&utm_content=gqy117/XpdfNet&utm_campaign=badger)|[![nuget](https://img.shields.io/nuget/v/XpdfNet.svg)](https://www.nuget.org/packages/XpdfNet)|

Usage
------
```csharp
using XpdfNet;

var pdfHelper = new XpdfHelper();

string content = pdfHelper.ToText("./pathToFile.pdf");
```
