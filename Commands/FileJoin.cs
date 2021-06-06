using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Utils.Commands
{
    internal class FileJoin : Command
    {
        private string folder = "text";
        private string output = "text\\output.txt";

        public FileJoin(IOutput output) : base(output) { }

        public override void Execute(string[] args)
        {
            _output.WriteLine("Joining Files");
            string[] files = Directory.GetFiles(folder, "*.txt", SearchOption.TopDirectoryOnly);

            List<string> lines = new List<string>();
            foreach (var file in files)
            {
                lines.AddRange(File.ReadAllLines(file).ToList());
            }

            File.WriteAllLines(output, lines);
            _output.WriteLine("Task completed successfully");
        }
    }
}
