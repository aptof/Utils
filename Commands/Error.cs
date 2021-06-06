namespace Utils.Commands
{
    internal class Error : Command
    {
        private string _error = "";

        public Error(IOutput output, string error) : base(output)
        {
            _error = error;
        }

        public override void Execute(string[] args)
        {
            _output.WriteLine(_error);
        }
    }
}
