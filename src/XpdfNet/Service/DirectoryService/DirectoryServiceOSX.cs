namespace XpdfNet
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class DirectoryServiceOSX : DirectoryServiceBase
    {
        private const string PDFToText = "pdftotext";
        private const string Bash = "/bin/bash";
        private const string Sudo = "sudo";

        public override string Filename
        {
            get
            {
                return Bash;
            }
        }

        public override string GetArguments(XpdfParameter parameter)
        {
            string arguments = this.JoinXpdfParameters(parameter);

            string newArguments = $"-c \"chmod +x ./{PDFToText}; ./{PDFToText} {arguments}\"";

            return newArguments;
        }
    }
}
