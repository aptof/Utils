using System;

namespace Utils
{
    public interface IOutput
    {
        public void Write(string text);

        public void WriteLine(string text);
    }

    internal class Output : IOutput
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
