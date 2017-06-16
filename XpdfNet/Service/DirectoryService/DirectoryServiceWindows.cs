using System.IO;

namespace XpdfNet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DirectoryServiceWindows : DirectoryServiceBase
    {
        private const string PDFToTextExeWindowNT = "pdftotext.exe";

        public override string Filename
        {
            get
            {
                string filename = Path.Combine(base.WorkingDirectory, PDFToTextExeWindowNT);
                return filename;
            }
        }
    }
}
