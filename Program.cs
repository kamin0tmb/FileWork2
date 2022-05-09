using System;
using System.IO;



namespace FileWork2
{
    
    class Program
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            
            FileInfo[] fis = d.GetFiles();
            try
            {
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            DirectoryInfo[] dis = d.GetDirectories();
            try
            {
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            return size;
        }
        
        static void Main(string[] args)
        {
            string dirName = @"D:\test";
            if (Directory.Exists(dirName))
            {
                DirectoryInfo directory = new DirectoryInfo(dirName);
                long size = DirSize(directory);
                Console.WriteLine("Размер директории составляет {0} байтов", size);

            }
            else { Console.WriteLine("Директория отсутствует"); }
        }

        
    }
}
