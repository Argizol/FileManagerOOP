using FileManager.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands
{
    internal class MoveCommand : FileManagerCommand
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;
        public override string Description => throw new NotImplementedException();

        public MoveCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }
        static void MoveDir(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.EnumerateFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Move(s1, s2);
            }
            foreach (string s in Directory.EnumerateDirectories(FromDir))
            {
                MoveDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }

        public override void Execute(string[] args)
        {

            if (args.Length > 1 && File.Exists(args[1]))
            {
                FileInfo file = new FileInfo(args[1]);
                file.MoveTo(args[2]);
            }
            else if (args.Length > 1 && Directory.Exists(args[1]) && Directory.Exists(args[2]))
            {
                MoveDir(args[1], args[2]);
            }

        }
    }
}

