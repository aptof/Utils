namespace Utils.Commands

{
    internal class Help : Command
    {
        public Help(IOutput output) : base(output) { }

        public override void Execute(string[] args)
        {
            _output.WriteLine("Utils help");
            _output.WriteLine("Commands");
            _output.WriteLine("help:\t Shows the help documents");
            _output.WriteLine("filejoin:\t Joins text files to a single file in \"text\" folder.");
            _output.WriteLine("fixlinebreak:\t Fix line breaks of files in \"text\" folder.");
            _output.WriteLine("rename:\t Rename as per convention all files in \"text\" folder.");
        }
    }
}
