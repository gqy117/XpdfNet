namespace XpdfNet
{
    using System;
    using System.IO;

    public class XpdfHelper
    {
        private string PDFToTextFilename;
        public XpdfParameter Parameter;
        private string WorkingDirectory;
        private IRuntimeInformation RuntimeInformation = new MyRuntimeInformation();
        private IDirectoryService DirectoryService;
        private string Arguments;

        public XpdfHelper()
        {
            this.InitDirectoryService();
        }

        public string ToText(string pdfFilePath)
        {
            this.PrepareParameters(pdfFilePath);

            ProcessService processService = new ProcessService(this.PDFToTextFilename, this.Arguments, this.WorkingDirectory);
            processService.StartAndWaitForExit();

            var textResult = this.GetTextResult(Parameter);

            return textResult;
        }

        private string GetTextResult(XpdfParameter parameter)
        {
            string textResult = File.ReadAllText(parameter.OutputFilename);
            File.Delete(parameter.OutputFilename);

            return textResult;
        }

        private void PrepareParameters(string pdfFilePath)
        {
            this.PDFToTextFilename = this.DirectoryService.Filename;
            this.WorkingDirectory = this.DirectoryService.WorkingDirectory;

            this.Parameter = this.DirectoryService.GetParameter(pdfFilePath);

            this.Arguments = this.DirectoryService.SetArguments(this.Parameter);
        }

        private void InitDirectoryService()
        {
            this.RuntimeInformation = new MyRuntimeInformation();
            this.DirectoryService = new DirectoryServiceFactory().GetDirectoryService(this.RuntimeInformation);
        }
    }
}
