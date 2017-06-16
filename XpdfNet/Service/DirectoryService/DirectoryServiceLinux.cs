namespace XpdfNet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DirectoryServiceLinux : DirectoryServiceBase
    {
        private const string PDFToTextExeUnix = "pdftotext";
        private const string SUDO = "sudo";

        public override string Filename
        {
            get
            {
                return SUDO;
            }
        }

        public override string GetArguments(XpdfParameter parameter)
        {
            string arguments = base.GetArguments(parameter);

            var newArguments = InsertPDFToTextIntoArguments(arguments);

            return newArguments;
        }

        private string InsertPDFToTextIntoArguments(string arguments)
        {
            string newArguments = $"{PDFToTextExeUnix} {arguments}";

            return newArguments;
        }
    }
}
