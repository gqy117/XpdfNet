namespace Xpdf.Wrapper
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains method wrappers around XPDF library.
    /// </summary>
    public static class Xpdf
    {
        //private readonly IDirectoryService directoryService;
        //private string filename;

        //private const string PDF_TO_TEXT = "PdfToText";

        /*
        public Xpdf()
        {
            IRuntimeInformation runtimeInformation = new MyRuntimeInformation();
            this.directoryService = DirectoryServiceFactory.GetDirectoryService(runtimeInformation);
        }
        */

        /// <summary>
        /// Extracts 
        /// </summary>
        /// <param name="pdfToTextParameters"></param>
        /// <returns>Returns extracted text OR location of extracted files (depends on options selected).</returns>
        public static string PdfToText(PdfToTextParameters pdfToTextParameters)
        {
            return ExecuteXpdf(new XpdfExecutable("pdftotext", null, "PdfToText.exe"), pdfToTextParameters);
        }

        /// <summary>
        /// Extracts text from filename using default parameters.
        /// </summary>
        /// <param name="filename">PDF filename to extract text from.</param>
        /// <returns>Returns extracted text OR location of extracted files (depends on options selected).</returns>
        public static string PdfToText(string filename)
        {
            return ExecuteXpdf(new XpdfExecutable("pdftotext", null, "PdfToText.exe"), new PdfToTextParameters(filename));
        }

        public static string PdfImages(PdfImagesParameters pdfImagesParameters)
        {
            return ExecuteXpdf(new XpdfExecutable("pdfimages", null, "PdfImages.exe"), pdfImagesParameters);
        }

        private static string ExecuteXpdf(XpdfExecutable xpdfExecutable, IXpdfParameters iXPdfParameters)
        {
            // Validate Params, perhaps have a validation routine in each
            iXPdfParameters.Validate();

            // Determine OS
            var os = GetOperatingSystem();

            // Get Exe name
            var xpdfFilename = xpdfExecutable.GetXpdfExecutableName(os);

            // Get CL arguments from Parameters
            var initialArguments = iXPdfParameters.BuildArguments();

            var workingDir = GetWorkingDir();

            // Build Params from Executable and arguments
            var commandLineValues = BuildCommandLine(xpdfFilename, initialArguments, os, workingDir);

            // Get working dir
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = commandLineValues.ExeFilename,
                    Arguments = commandLineValues.FinalArguments,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = System.Text.Encoding.UTF8,  // Need to pull from available encodings?
                    WorkingDirectory = workingDir,
                    UseShellExecute = false
                }
            };

            process.Start();
            var textResult = process.StandardOutput;
            process.WaitForExit();

            return textResult.ReadToEnd();
        }

        private static CommandLineValues BuildCommandLine(string xpdfFilename, string initialArguments, OS os, string workingDir)
        {
            switch (os)
            {
                case OS.Windows:
                    return BuildCommandLineWindows(xpdfFilename, initialArguments, workingDir);
                case OS.Linux:
                    return BuildCommandLineLinux(xpdfFilename, initialArguments);
            }

            throw new Exception($"Unsupported operating system: {os}");
        }

        private static CommandLineValues BuildCommandLineWindows(string xpdfFilename, string initialArguments, string workingDir)
        {
            return new CommandLineValues(Path.Combine(workingDir, xpdfFilename), initialArguments);
        }

        private static string GetWorkingDir()
        {
#if NET461
            return AppDomain.CurrentDomain.BaseDirectory;
#else
            return AppContext.BaseDirectory;
#endif
        }

        private static CommandLineValues BuildCommandLineLinux(string xpdfFilename, string initialArguments)
        {
            var bash = "/bin/bash";

            string newArguments = $"-c \"chmod +x ./{xpdfFilename}; ./{xpdfFilename} {initialArguments}\"";

            return new CommandLineValues(bash, newArguments);
        }

        private static OS GetOperatingSystem()
        {
#if NET461
            return OS.Windows;
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OS.Windows;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OS.Linux;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OS.OSX;
            }

            return OS.Unsupported;
#endif
        }
    }
}
