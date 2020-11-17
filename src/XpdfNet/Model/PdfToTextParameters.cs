namespace Xpdf.Wrapper
{
    public class PdfToTextParameters : IXpdfParameters
    {
        public string OutputFilename { get; set; } = "-"; // "-" outputs to stdout

        public string Encoding { get; set; } = "UTF-8";

        public string PdfFilename { get; set; }

        public bool KeepLayout { get; set; } = false;

        public bool PageBreaks { get; set; } = true;

        public bool Raw { get; set; } = false;

        public bool DiscardDiagnalText { get; set; } = false;

        /// <summary>
        /// Build command line arguments.
        /// </summary>
        /// <returns>Command line arguments.</returns>
        public string BuildArguments()
        {
            return
                this.OutputEncoding() +
                this.OutputKeepLayout() +
                this.OutputPageBreaks() +
                this.OutputRaw() +
                this.OutputDiscardDiagnalText() +
                " " + this.PdfFilename +
                " " + this.OutputFilename;
        }

        private string OutputEncoding()
        {
            if (string.IsNullOrWhiteSpace(this.Encoding))
            {
                return string.Empty;
            }

            return " -enc " + this.Encoding;
        }

        private string OutputKeepLayout()
        {
            if (this.KeepLayout)
            {
                return " -layout";
            }

            return string.Empty;
        }

        private string OutputPageBreaks()
        {
            if (this.PageBreaks)
            {
                return string.Empty;
            }

            return " -nopgbrk";
        }

        private string OutputRaw()
        {
            if (this.Raw)
            {
                return " -raw";
            }

            return string.Empty;
        }

        private string OutputDiscardDiagnalText()
        {
            if (this.DiscardDiagnalText)
            {
                return " -nodiag";
            }

            return string.Empty;
        }
    }
}