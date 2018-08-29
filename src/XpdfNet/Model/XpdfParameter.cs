namespace XpdfNet
{
    using System.Collections.Generic;

    public class XpdfParameter
    {
        public string OutputFilename { get; set; }

        public string Encoding { get; set; }

        public string PdfFilename { get; set; }

        public string PDFLevel { get; set; }

        public List<string> ExtraArguments { get; set; }
    }
}
