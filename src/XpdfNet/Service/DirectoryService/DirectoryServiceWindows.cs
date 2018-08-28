namespace XpdfNet
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class DirectoryServiceWindows : DirectoryServiceBase
    {
        private const string PDFToText = "pdftotext.exe";
        private const string PDFToPS = "pdftops.exe";

        public override string PDFToPSFilename
        {
            get
            {
                return Path.Combine(this.WorkingDirectory, PDFToPS);
            }
        }

        public override string PDFToTextFilename
        {
            get
            {
                return Path.Combine(this.WorkingDirectory, PDFToText);
            }
        }

        public override string Filename
        {
            get
            {
                return this.PDFToTextFilename;
            }
        }

        [Obsolete("GetArguments is deprecated, please use GetArgumentsToText instead.")]
        public override string GetArguments(XpdfParameter parameter)
        {
            return this.JoinArgumentsInString(parameter);
        }

        public override string GetArgumentsToText(XpdfParameter parameter)
        {
            return this.JoinArgumentsInString(parameter);
        }

        public override string GetArgumentsToPS(XpdfParameter parameter)
        {
            return this.JoinArgumentsInString(parameter);
        }

        private string JoinArgumentsInString(XpdfParameter parameter)
        {
            var arguments = this.JoinXpdfParameters(parameter);

            return arguments;
        }
    }
}
