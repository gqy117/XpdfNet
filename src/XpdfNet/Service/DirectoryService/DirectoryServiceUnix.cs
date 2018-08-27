﻿namespace XpdfNet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DirectoryServiceUnix : DirectoryServiceBase
    {
        private const string PDFToText = "pdftotext";
        private const string PDFToPS = "pdftops";
        private const string Bash = "/bin/bash";

        public override string Filename => Bash;

        public override string PDFToPSFilename => Bash;

        public override string PDFToTextFilename => Bash;

        [Obsolete("GetArguments is deprecated, please use GetArgumentsToText instead.")]
        public override string GetArguments(XpdfParameter parameter)
        {
            string arguments = this.JoinXpdfParameters(parameter);

            string newArguments = $"-c \"chmod +x ./{PDFToText}; ./{PDFToText} {arguments}\"";

            return newArguments;
        }

        public override string GetArgumentsToText(XpdfParameter parameter)
        {
            string arguments = this.JoinXpdfParameters(parameter);

            string newArguments = $"-c \"chmod +x ./{PDFToText}; ./{PDFToText} {arguments}\"";

            return newArguments;
        }

        public override string GetArgumentsToPS(XpdfParameter parameter)
        {
            string arguments = this.JoinXpdfParameters(parameter);

            string newArguments = $"-c \"chmod +x ./{PDFToPS}; ./{PDFToPS} {arguments}\"";

            return newArguments;
        }
    }
}
