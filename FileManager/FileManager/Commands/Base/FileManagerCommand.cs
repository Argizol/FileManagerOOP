namespace FileManager.Commands.Base;

public abstract class FileManagerCommand
{
        private readonly IUserInterface _UserInterface;
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;
        private readonly FileManagerLogic _FileManager;
    public abstract string Description { get; }
        public override string Description => "Для создания файла введите cr path\\filename.extension\n" +
                                              "Для создания каталога введите cr path\\directoryname";
        public override string Description => "Для создания файла введите cr path\\filename.extension\n" +
                                              "Для создания каталога введите cr path\\directoryname";

    public abstract void Execute(string[] args);

        public override void Execute(string[] args)
        {
            if (args.Length > 1 && !File.Exists(args[1]))
            {
                File.Create(args[1]);
            }
            else if (args.Length > 1 && !Directory.Exists(args[1]))
            {
                Directory.CreateDirectory(args[1]);
            }
        }

        public override void Execute(string[] args)
        {
            if (args.Length > 1 && !File.Exists(args[1]))
            {
                File.Create(args[1]);
            }
            else if (args.Length > 1 && !Directory.Exists(args[1]))
            {
                Directory.CreateDirectory(args[1]);
            }
        }
}
