using System;

namespace Xpdf.Wrapper
{
    public class PdfImagesParameters : IXpdfParameters
    {
        public bool OnlyListImages { get; set; } = false;

        public bool ExportAllImages { get; set; } = true;

        public bool SaveAsPng { get; set; } = false;

        public string PdfFilename { get; set; }

        /// <summary>
        /// Directory where images will be saved.
        /// </summary>
        public string OutputDir { get; set; }




       
        /// <summary>
        /// Build command line arguments.
        /// </summary>
        /// <returns>Command line arguments.</returns>
        public string BuildArguments()
        {
            return
                this.OutputOnlyListImages() +
                this.OutputExportAllImages() +
                this.OutputSaveAsPng() +
                $" \"{this.PdfFilename}\"" +
                $" \"{this.OutputDir}\"";
        }

        private string OutputOnlyListImages()
        {
                if (this.OnlyListImages)
                {
                    return " -list";
                }

                return string.Empty;
            }

        private string OutputExportAllImages()
        {
            if (this.ExportAllImages)
            {
                return " -all";
            }

            return string.Empty;
        }

        private string OutputSaveAsPng()
        {
            if (this.SaveAsPng)
            {
                return " -png";
            }

            return string.Empty;
        }

        public void Validate()
        {
            // TODO: Come back to later
            throw new NotImplementedException();
        }
    }
}
