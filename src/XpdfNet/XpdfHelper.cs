namespace XpdfNet
{
    using System;
    using System.IO;

    public class XpdfHelper
    {
        private readonly IDirectoryService directoryService;
        private string filename;
        private XpdfParameter parameter;
        private string workingDirectory;
        private string arguments;

        public XpdfHelper()
        {
            IRuntimeInformation runtimeInformation = new MyRuntimeInformation();
            this.directoryService = DirectoryServiceFactory.GetDirectoryService(runtimeInformation);
        }

        public string ToPS(string pdfFilePath)
        {
            this.PrepareParametersToPS(pdfFilePath);

            ProcessService processService = new ProcessService(this.filename, this.arguments, this.workingDirectory);
            processService.StartAndWaitForExit();

            var textResult = GetTextResult(this.parameter);

            return textResult;
        }

        public string ToText(string pdfFilePath)
        {
            this.PrepareParametersToText(pdfFilePath);

            ProcessService processService = new ProcessService(this.filename, this.arguments, this.workingDirectory);
            processService.StartAndWaitForExit();

            var textResult = GetTextResult(this.parameter);

            return textResult;
        }

        private static string GetTextResult(XpdfParameter parameter)
        {
            string textResult = File.ReadAllText(parameter.OutputFilename);

            File.Delete(parameter.OutputFilename);

            return textResult;
        }

        private void PrepareParametersToPS(string pdfFilePath)
        {
            this.filename = this.directoryService.PDFToPSFilename;

            this.workingDirectory = this.directoryService.WorkingDirectory;

            this.parameter = this.directoryService.GetParameterToPs(pdfFilePath);

            this.arguments = this.directoryService.GetArgumentsToPS(this.parameter);
        }

        private void PrepareParametersToText(string pdfFilePath)
        {
            this.filename = this.directoryService.Filename;
            this.workingDirectory = this.directoryService.WorkingDirectory;

            this.parameter = this.directoryService.GetParameter(pdfFilePath);

            this.arguments = this.directoryService.GetArgumentsToText(this.parameter);
        }

        [Obsolete("PrepareParameters is obsolete please use PrepareParametersToText")]
        private void PrepareParameters(string pdfFilePath)
        {
            this.filename = this.directoryService.Filename;
            this.workingDirectory = this.directoryService.WorkingDirectory;

            this.parameter = this.directoryService.GetParameter(pdfFilePath);

            this.arguments = this.directoryService.GetArgumentsToText(this.parameter);
        }
    }
}
