using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Winista.Mime;

namespace extension_detector
{
    class Program
    {
        static void Main(string[] args)
        {

            int i;
            int x = 10;
            string directory, newdirectory;
            //Console.WriteLine("Hello " + Environment.UserName + "!\nPlease put the folder random_files to the same folder this file is in.\nWhen done press Enter.");
            Console.WriteLine("Hello " + Environment.UserName + "!\nPlease type full path to the folder where files are stored (you can name your folder as you wish).\nFor example: C:\\Users\\Mark\\Desktop\\random_files");
            directory = Console.ReadLine();
            Console.WriteLine("\nPlease choose the folder to save new files. (Or just click enter to save in the same place, where this application is.):");
            newdirectory = Console.ReadLine();

            string dir = directory + "/file";
            System.IO.Directory.CreateDirectory(newdirectory + "/detected_files");
            string newdir = newdirectory + "/detected_files/file";
            var fileCount = (from file in Directory.EnumerateFiles(directory + "/", "", SearchOption.AllDirectories)
                             select file).Count();

            Console.WriteLine("\nThe amount of containing no extension: " + fileCount);
            Console.ReadLine();

           

            for (i = 1; i < fileCount; i++)
            {
                  try
                {
                    var mimeTypes = new MimeTypes();
                    var mimeType = mimeTypes.GetMimeTypeFromFile(dir + x); //Probably can think of a way checking files with no matter if they are named "fileXX", but I assume the task does not require it. 
                    var image = "image/jpeg";


                    if (mimeType == null) {
                        Console.WriteLine("File" + x + " has unknown extension.");
                    }

                    else if (mimeType.ToString() == "image/jpeg")
                    {

                        try
                        {
                            File.Copy(dir + x, newdir + x + ".jpeg");
                            Console.WriteLine("File" + x + " is an " + mimeType + ". Converted to .jpeg in detected_files folder.");
                        }
                        catch
                        {
                            Console.WriteLine("File" + x + " is an " + mimeType + ". It looks like the file was already copied to detected_files folder.");
                        }

                    }

                    else
                    {
                        Console.WriteLine("File" + x + " is a/an " + mimeType + ".");

                    }
                   

                }
                catch {
                    Console.WriteLine("Something went wrong, Maybe the file" + x + " does not exist?");
                }
                x++;
            }
            Console.ReadLine();
            string message = "Thank you for trying my app!\nBye!";
            for (int j = 0; j < message.Length; j++)
            {
                Console.Write(message[j]);
                System.Threading.Thread.Sleep(160);
            }
            System.Threading.Thread.Sleep(160);
        }
    }

}