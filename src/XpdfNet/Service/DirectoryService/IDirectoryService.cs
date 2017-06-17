namespace XpdfNet
{
    public interface IDirectoryService
    {
        string WorkingDirectory { get; }

        string Filename { get; }

        XpdfParameter GetParameter(string pdfFilePath);

        string GetArguments(XpdfParameter parameter);
    }
}