using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace Utils.Commands
{
    internal class Rename : Command
    {

        string inputfolder = "text";
        string outputFolder = "text";

        public Rename(IOutput output) : base(output) { }

        public override void Execute(string[] args)
        {
            string[] files = Directory.GetFiles(inputfolder, "*.txt", SearchOption.TopDirectoryOnly);
            _output.WriteLine("Renaming " + files.Length + " file(s)...");

            var character = GenerateNewStartingCharacter();

            for (int i = 0; i < files.Length; i++)
            {
                List<string> lines = File.ReadAllLines(files[i]).ToList();
                string output = Path.Combine(outputFolder, GenerateFileName(character, i + 1));
                File.WriteAllLines(output, lines);
            }

            _output.WriteLine("Task completed successfully");
        }

        private string GenerateFileName(string character, int i)
        {
            if (i >= 1 && i < 10)
            {
                return character + "000" + i + ".txt";
            }
            if (i >= 10 && i < 100)
            {
                return character + "00" + i + ".txt";
            }
            if (i >= 100 && i < 1000)
            {
                return character + "0" + i + ".txt";
            }
            if (i >= 1000 && i < 10000)
            {
                return character + i + ".txt";
            }
            else return "Invalid.txt";
        }

        private string GenerateNewStartingCharacter()
        {
            return ((char)new Random().Next('A', 'Z')).ToString();
        }
    }
}
