using System;
using System.IO;
using System.Threading.Tasks;

namespace CloudinaryDotnetCoreTest
{
    class Program
    {
        static void  Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string pathSource = @"F:\lady.jpg";
            using (FileStream fsSource = new FileStream(pathSource,
            FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine(CloudinaryManager.UploadAvatar(fsSource).GetAwaiter().GetResult());
            }
            Console.Read();
        }
    }
}
