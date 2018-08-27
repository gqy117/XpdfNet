namespace XpdfNet
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public abstract class DirectoryServiceBase : IDirectoryService
    {
        public abstract string Filename { get; }

        public abstract string PDFToPSFilename { get; }

        public abstract string PDFToTextFilename { get; }

        public string WorkingDirectory
        {
            get
            {
                string workingDirectory;

#if NET45
                workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#else
                workingDirectory = AppContext.BaseDirectory;
#endif

                return workingDirectory;
            }
        }

        public XpdfParameter GetParameter(string pdfFilePath)
        {
            return new XpdfParameter
            {
                Encoding = "-enc UTF-8",
                PdfFilename = pdfFilePath,
                OutputFilename = Path.Combine(this.WorkingDirectory, Guid.NewGuid() + ".txt")
            };
        }

        public XpdfParameter GetParameterToPs(string pdfFilePath)
        {
            return new XpdfParameter
            {
                PDFLevel = "-level3",
                PdfFilename = pdfFilePath,
                OutputFilename = Path.Combine(this.WorkingDirectory, Guid.NewGuid() + ".ps")
            };
        }

        [Obsolete("GetArguments is deprecated, please use GetArgumentsToText instead.")]
        public abstract string GetArguments(XpdfParameter parameter);

        public abstract string GetArgumentsToText(XpdfParameter parameter);

        public abstract string GetArgumentsToPS(XpdfParameter parameter);

        protected static string WrapWith(string text, string ends)
        {
            return ends + text + ends;
        }

        protected static string WrapQuotes(string text)
        {
            return WrapWith(text, "\"");
        }

        protected string JoinXpdfParameters(XpdfParameter parameter)
        {
            string[] argumentsArray =
            {
                parameter.Encoding,
                parameter.PDFLevel,
                WrapQuotes(parameter.PdfFilename),
                WrapQuotes(parameter.OutputFilename),
            };

            string arguments = string.Join(" ", argumentsArray);
            return arguments;
        }
    }
}
