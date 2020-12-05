namespace Xpdf.Wrapper
{
    /// <summary>
    /// Parameters uses when converting a PDF to text.
    /// </summary>
    public class PdfToTextParameters : IXpdfParameters
    {
        public PdfToTextParameters(string pdfFilename)
        {
            PdfFilename = pdfFilename;
        }

        /// <summary>
        /// Optional output filename.  If omitted, text will be returned as a string.
        /// </summary>
        public string OutputFilename { get; set; } = "-"; // "-" outputs to stdout

        /// <summary>
        /// The encoding the outputted text will be encoded in.  Defaults to UTF-8.
        /// </summary>
        public string Encoding { get; set; } = Encodings.UTF_8;

        /// <summary>
        /// Required. PDF filename to convert to text.
        /// </summary>
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
                $" \"{this.PdfFilename}\"" +
                $" \"{this.OutputFilename}\"";
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

        public void Validate()
        {
        }
    }
}