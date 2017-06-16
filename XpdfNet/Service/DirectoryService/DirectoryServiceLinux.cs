namespace XpdfNet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DirectoryServiceLinux : DirectoryServiceBase
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
            string arguments = base.GetArguments(parameter);

            var newArguments = $"-c \"{Sudo} {PDFToText} {arguments}\"";

            return newArguments;
        }
    }
}
