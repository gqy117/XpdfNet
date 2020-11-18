namespace Xpdf.Wrapper
{
    public interface IXpdfParameters
    {
        /// <summary>
        /// Builds command line arguments based on property values.
        /// </summary>
        /// <returns>The command line arguments properly formatted.</returns>
        string BuildArguments();

        /// <summary>
        /// Validates the command line arguments and throws exception if validation fails.  This is not guaranteed to catch all argument issues.
        /// </summary>
        void Validate();
    }
}