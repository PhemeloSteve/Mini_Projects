using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        public static string FilePath;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the File path: ");
            FilePath = Console.ReadLine();

            Console.Write("Please enter the file name: ");
            string FileName = Console.ReadLine();

            // User Menue

            bool isValid = false;
            int Input = 0;

            while (isValid != true)
            {
                Console.WriteLine("----Welcome to File Creation----");
                Console.WriteLine("1\tCheck for File Existance");
                Console.WriteLine("2\tCreate File");
                Console.WriteLine("3\tDelete File");
                Console.WriteLine();
                Console.Write("Enter your selection number: ");

                isValid = int.TryParse(Console.ReadLine(), out Input);
            }

            // Switch case statement to choose option from the menue
            switch (Input)
            {
                case 1:
                    Console.WriteLine("You have slected option 1: (Existance of file) ");
                    Exist(FileName);
                    break;
                case 2:
                    Console.WriteLine("You have selected option 2: (Creation of File)");
                    Create(FileName);
                    break;
                case 3:
                    Console.WriteLine("You have selected option 3: (Delete File) ");
                    Delete(FileName);
                    break;
                default:
                    break;
            }


            // End of code
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();


        }

        // Method to Create a file
        public static void Create(string _FileName)
        {

            using (FileStream FileStream1 = new FileStream(FilePath + _FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter Write = new StreamWriter(FileStream1))
                {
                    Console.WriteLine("Please enter the text you want to save into the file:");
                    string Input = Console.ReadLine();
                    Write.WriteLine(Input);
                }
            }
           
        }

        public static void Exist(string _FileName)
        {
            using (FileStream FileStream1 = new FileStream(FilePath + _FileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader read = new StreamReader(FileStream1))
                {
                    if (File.Exists(FilePath + _FileName))
                    {
                        Console.WriteLine("File Exist!!!");
                        Console.WriteLine();
                        Console.WriteLine("File was created on" + "\t\t" + File.GetCreationTime(FilePath + _FileName));
                        Console.WriteLine("File was last accessed on" + "\t" + File.GetLastAccessTime(FilePath + _FileName));
                        Console.WriteLine("File was last modified on" + "\t" + File.GetLastWriteTime(FilePath + _FileName));
                    }
                    else
                    {
                        Console.WriteLine("File Does not exist!!!");
                    }

                }
            }

        }

        public static void Delete(string _FileName)
        {
            using (FileStream FileStream1 = new FileStream(FilePath + _FileName, FileMode.Open, FileAccess.Read)) // Need to fix this in futere
            {
                using (StreamReader reader = new StreamReader(FileStream1))
                {
                    if (File.Exists(FilePath + _FileName))
                    {
                        Console.WriteLine("File Exist!!!");
                        Console.WriteLine();

                        Console.WriteLine("Content of the file is as follow: ");
                        Console.WriteLine(reader.ReadToEnd());

                    }
                    else
                    {
                        Console.WriteLine("File Does not exist!!!");
                    }

                }

                if (File.Exists(FilePath + _FileName))
                {
                    string Inpute = "";
                    int i = 0;
                    while (Inpute != "Y" && Inpute != "N")
                    {
                        if (i > 0) { Console.WriteLine("Invalid Input, Please try again!"); }
                        Console.WriteLine("Would You Line to delete this file? (Y/S)");
                        Inpute = Console.ReadLine().ToUpper();

                    }
                    if (Inpute == "Y")
                    {
                        File.Delete(FilePath + _FileName);
                        Console.WriteLine("File deleted!!");
                    }
                    else
                    {
                        Console.WriteLine("File not deleted!");
                    }
                }
                    
            }
        }
    }
}
