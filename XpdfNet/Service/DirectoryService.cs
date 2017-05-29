namespace XpdfNet
{
    using System;
    using System.Runtime.InteropServices;

    public class DirectoryService
    {
        private readonly IRuntimeInformation RuntimeInformation;

        private const string PDFToTextExeWindowNT = "pdftotext.exe";
        private const string PDFToTextExeUnix = "pdftotext";

        public DirectoryService(IRuntimeInformation runtimeInformation)
        {
            this.RuntimeInformation = runtimeInformation;
        }

        public string GetWorkingDirectory()
        {
            string workingDirectory;

#if NET45
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#else
            workingDirectory = AppContext.BaseDirectory;
#endif

            return workingDirectory;
        }

        public string GetPDFToTextExeFilename()
        {
            string result = string.Empty;

            switch (this.RuntimeInformation.GetOSPlatform())
            {
                case OS.Windows:
                    result = PDFToTextExeWindowNT;
                    break;

                case OS.Linux:
                    result = PDFToTextExeUnix;
                    break;

                default:
                case OS.Unsupported:
                case OS.OSX:
                    throw new ArgumentException("XpdfNet currently only supports Unit and Windows OS.");
            }

            return result;
        }
    }
}
