namespace XpdfNet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DirectoryServiceUnix : DirectoryServiceBase
    {
        private const string PDFToTextExeUnix = "pdftotext";

        public override string Filename
        {
            get
            {
                return PDFToTextExeUnix;
            }
        }
    }
}
