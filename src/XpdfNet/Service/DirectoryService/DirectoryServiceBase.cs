namespace XpdfNet
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public abstract class DirectoryServiceBase : IDirectoryService
    {
        public abstract string Filename { get; }

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

        public abstract string GetArguments(XpdfParameter parameter);

        protected static string WrapWith(string text, string ends)
        {
            return ends + text + ends;
        }

        protected string JoinXpdfParameters(XpdfParameter parameter)
        {
            string[] argumentsArray =
            {
                parameter.Encoding,
                this.WrapQuotes(parameter.PdfFilename),
                this.WrapQuotes(parameter.OutputFilename),
            };

            string arguments = string.Join(" ", argumentsArray);
            return arguments;
        }

        protected string WrapQuotes(string text)
        {
            return WrapWith(text, "\"");
        }
    }
}
