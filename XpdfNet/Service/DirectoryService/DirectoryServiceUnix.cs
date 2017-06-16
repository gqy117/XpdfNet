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
                return "sudo";
            }
        }

        public override string GetArguments(XpdfParameter parameter)
        {
            string arguments = base.GetArguments(parameter);

            string newArguments = $"{PDFToTextExeUnix} {arguments}";

            return newArguments;
        }
    }
}
