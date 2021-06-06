using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Utils.Commands
{
    internal class FixLineBreak : Command
    {
        string inputfolder = "text";
        string outputFolder = "dist";
        public FixLineBreak(IOutput output) : base(output)
        {
            if (Directory.Exists(outputFolder))
            {
                Directory.Delete(outputFolder, true);
            }

            Directory.CreateDirectory(outputFolder);
        }

        public override void Execute(string[] args)
        {
            string[] files = Directory.GetFiles(inputfolder, "*.txt", SearchOption.TopDirectoryOnly);
            _output.WriteLine("Fixing " + files.Length + " file(s)...");
            foreach (var file in files)
            {
                FixFile(file);
            }
            _output.WriteLine("Task completed successfully.");
        }

        private void FixFile(string file)
        {
            List<string> lines = File.ReadAllLines(file).ToList();
            lines = lines.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            List<string> fixedLines = new List<string>();
            fixedLines.Add(lines[0]);
            for (int i = 1; i < lines.Count; i++)
            {
                fixedLines.Add(FixLine(lines[i]));
            }

            string outputFile = Path.Combine(outputFolder, Path.GetFileName(file));
            File.WriteAllLines(outputFile, fixedLines);
        }

        private string FixLine(string line)
        {
            line = line.Trim();
            if (!HasLinecode(line))
            {
                line = Default() + line;
            }
            return line;
        }

        private string Default()
        {
            return "খ ";
        }

        private bool HasLinecode(string line)
        {
            if (line.Length >= 2)
            {
                string code = line.Substring(0, 2);
                return code.Trim().Length == 1;
            }
            return false;
        }
    }
}
