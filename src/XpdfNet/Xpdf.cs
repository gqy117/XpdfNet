namespace Xpdf.Wrapper
{
    using global::Xpdf.Wrapper.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Contains method wrappers around XPDF library.
    /// </summary>
    public static class Xpdf
    {
        //private readonly IDirectoryService directoryService;
        //private string filename;

        private const string PDF_TO_TEXT = "PdfToText";

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

        public static string PdfImages(PdfImagesParameters pdfImagesParameters)
        {
            return ExecuteXpdf(new XpdfExecutable("pdfimages", null, "PdfImages.exe"), pdfImagesParameters);
        }

        private static string ExecuteXpdf(XpdfExecutable xpdfExecutable, IXpdfParameters iXPdfParameters)
        {
            // Validate Params, perhaps have a validation routine in each
            // Determine OS
            // Get Exename from Executable
            // Get arguments from Parameters
            // Build Params from Executable and arguments
            // Get working dir 
            ProcessService processService = new ProcessService(this.filename, this.arguments, thisorkingDirectory);
            processService.StartAndWaitForExit();

            var textResult = processService.StandardOutout;

            return textResult;
        }

        private (string, string) PrepareParameters(string pdfFilePath)
        {
            this.filename = this.directoryService.Filename;
            this.workingDirectory = this.directoryService.WorkingDirectory;

            this.parameter = this.directoryService.GetParameter(pdfFilePath);

            this.arguments = this.directoryService.GetArguments(this.parameter);
        }
    }
}
