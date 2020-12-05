namespace Xpdf.Wrapper
{
    internal class CommandLineValues
    {
        internal string ExeFilename { get; }

        internal string FinalArguments { get; }

        internal CommandLineValues(string exeFilename, string finalArguments)
        {
            this.ExeFilename = exeFilename;
            this.FinalArguments = finalArguments;
        }
    }
}