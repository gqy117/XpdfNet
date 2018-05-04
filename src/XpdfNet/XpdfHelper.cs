namespace XpdfNet
{
    using System;
    using System.IO;

    public class XpdfHelper
    {
        private string filename;
        private XpdfParameter parameter;
        private string workingDirectory;
        private IRuntimeInformation runtimeInformation = new MyRuntimeInformation();
        private IDirectoryService directoryService;
        private string arguments;

        public XpdfHelper()
        {
            this.runtimeInformation = new MyRuntimeInformation();
            this.directoryService = DirectoryServiceFactory.GetDirectoryService(this.runtimeInformation);
        }

        public string ToText(string pdfFilePath)
        {
            this.PrepareParameters(pdfFilePath);

            ProcessService processService = new ProcessService(this.filename, this.arguments, this.workingDirectory);
            processService.StartAndWaitForExit();

            var textResult = this.GetTextResult(this.parameter);

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
            this.filename = this.directoryService.Filename;
            this.workingDirectory = this.directoryService.WorkingDirectory;

            this.parameter = this.directoryService.GetParameter(pdfFilePath);

            this.arguments = this.directoryService.GetArguments(this.parameter);
        }
    }
}
