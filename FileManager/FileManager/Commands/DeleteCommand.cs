using FileManager.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands
{

    internal class DeleteCommand : FileManagerCommand
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;
        public override string Description => " Для удаления файла введите rm path\\file.name.extension\n" +
                                              " для удаления каталога введите rm path";

        public DeleteCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length > 1)
            {
                if (File.Exists(args[1]))
                {
                    File.Delete(args[1]);
                }
                else if (Directory.Exists(args[1]))
                {                    
                    try
                    {
                        Directory.Delete(args[1], true);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                }
            }
        }
    }
}
