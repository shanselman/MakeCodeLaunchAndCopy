using System;
using System.IO;
using System.Linq;

namespace MakeCodeLaunchAndCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFile = args[0];
            var drive = (from d in DriveInfo.GetDrives()
                         where d.VolumeLabel == "CPLAYBOOT"
                         select d.RootDirectory).FirstOrDefault();
            
            if (drive == null) {
                Console.WriteLine("Press RESET on your Circuit Playground Express and try again!");
                Environment.Exit(1);
            }

            Console.WriteLine($"Found Circuit Playground Express at {drive.FullName}");
            File.Copy(sourceFile, Path.Combine(drive.FullName, Path.GetFileName(sourceFile)));
        }
    }
}
