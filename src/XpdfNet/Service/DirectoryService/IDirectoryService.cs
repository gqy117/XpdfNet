namespace XpdfNet
{
    public interface IDirectoryService
    {
        string WorkingDirectory { get; }

        string Filename { get; }

        string PDFToPSFilename { get; }

        string PDFToTextFilename { get; }

        XpdfParameter GetParameter(string pdfFilePath);

        XpdfParameter GetParameterToPs(string pdfFilePath);

        string GetArguments(XpdfParameter parameter);

        string GetArgumentsToText(XpdfParameter parameter);

        string GetArgumentsToPS(XpdfParameter parameter);
    }
}