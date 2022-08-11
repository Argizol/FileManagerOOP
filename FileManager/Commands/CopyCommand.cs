using FileManager.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands
{
    internal class CopyCommand : FileManagerCommand
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;
        public override string Description => "Перемещение файла или директории в виде cp (откуда копировать\\имя файла) (куда копировать)\n" +
            " Путь указывается в формате: c:/dirname для директории или c:/filename.extension для файла";

        public CopyCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }
        /// <summary>
        /// Метод для копирования каталога рекурсивно
        /// </summary>
        /// <param name="FromDir">Откуда копируем</param>
        /// <param name="ToDir">Куда копируем</param>

        static void CopyDir(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.EnumerateFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.EnumerateDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }



        public override void Execute(string[] args)
        {
           
            if (args.Length > 1 && File.Exists(args[1]))
            {
                FileInfo file = new FileInfo(args[1]);
                file.CopyTo(args[2]);
            }
            else if (args.Length > 1 && Directory.Exists(args[1]) && Directory.Exists(args[2]))
            {
                CopyDir(args[1], args[2]);
            }

        }
    }
}

