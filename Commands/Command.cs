using System;

namespace Utils.Commands
{
    internal abstract class Command : ICommand
    {
        protected IOutput _output;

        public Command(IOutput output)
        {
            _output = output;
        }


        public abstract void Execute(string[] args);
    }
}
