﻿namespace XpdfNet
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
                OutputFilename = Path.Combine(WorkingDirectory, Guid.NewGuid() + ".txt")
            };
        }

        public string SetArguments(XpdfParameter parameter)
        {
            string[] argumentsArray =
            {
                parameter.Encoding,
                this.WrapQuotes(parameter.PdfFilename),
                this.WrapQuotes(parameter.OutputFilename),
            };

            string arguments = String.Join(" ", argumentsArray);

            return arguments;
        }


        private string WrapQuotes(string text)
        {
            return this.WrapWith(text, "\"");
        }

        private string WrapWith(string text, string ends)
        {
            return ends + text + ends;
        }
    }
}