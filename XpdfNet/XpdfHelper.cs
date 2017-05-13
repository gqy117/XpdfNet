namespace XpdfNet
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    public class XpdfHelper
    {
        private const string PDFToTextExe = "pdftotext.exe";
        public XpdfParameter Parameter;
        private readonly string WorkingDirectory;
        private readonly string PdfToTextExePath;

        public XpdfHelper()
        {
            this.WorkingDirectory = Directory.GetCurrentDirectory();
            this.PdfToTextExePath = Path.Combine(this.WorkingDirectory, PDFToTextExe);
        }

        public string ToText(string pdfFilePath)
        {
            this.Parameter = this.GetParameter(pdfFilePath);

            var arguments = this.SetArguments(Parameter);

            ProcessService processService = new ProcessService(this.PdfToTextExePath, arguments, this.WorkingDirectory);
            processService.StartAndWaitForExit();

            var textResult = this.GetTextResult(Parameter);

            return textResult;
        }



        /// <summary>
        /// Reading that file and ignoring from the "Date Printed" text
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private string GetTextResult(XpdfParameter parameter)
        {
            string textResult = File.ReadAllText(parameter.OutputFilename);
            File.Delete(parameter.OutputFilename);

            return textResult;
        }

        /// <summary>
        /// Paramter to get pdftotxt.exe 
        /// </summary>
        /// <param name="pdfFilePath"></param>
        /// <returns></returns>
        private XpdfParameter GetParameter(string pdfFilePath)
        {
            return new XpdfParameter
            {
                Encoding = "-enc UTF-8",
                PdfFilename = pdfFilePath,
                OutputFilename = Path.Combine(WorkingDirectory, Guid.NewGuid() + ".txt")
            };
        }

        /// <summary>
        /// Convert the XpdfParameter class to string
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private string SetArguments(XpdfParameter parameter)
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
