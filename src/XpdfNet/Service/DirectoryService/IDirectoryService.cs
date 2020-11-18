namespace XpdfNet
{
    public interface IDirectoryService
    {
        string WorkingDirectory { get; }

        string Filename { get; }

        PdfToTextParameter GetParameter(string pdfFilePath);

        string GetArguments(PdfToTextParameter parameter);
    }
}