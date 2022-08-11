using FileManager.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands
{
    internal class FileStatisticCommand : FileManagerCommand
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;
        public override string Description => "Для подсчета количества слов в файле введите команду fs и укажите путь к файлу в виде c:/filename.extension";

        public FileStatisticCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {            
            using StreamReader sr = new StreamReader(args[1]); 
            int numsOfWords = 0;
            int linesCount = 0;
            int paragraphCount = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                linesCount++;
                if (line[0] == '\t')
                {
                    paragraphCount++;
                }
                var count = line.Split(' ').Length;
                numsOfWords += count;
            };
            FileInfo fileInfo = new FileInfo(args[1]);
            _UserInterface.WriteLine($"Слов в документе: {numsOfWords}\n" +
                                $"Размер файла: {fileInfo.Length}\n" +
                                $"Строк в файле: {linesCount}\n" +
                                $"Абзацев в файле: {paragraphCount}");
        }
    }
}
