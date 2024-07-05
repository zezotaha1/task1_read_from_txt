using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using task1_read_from_txt;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    //Don't Forget change connection string in ApplicationDbContext
    private static void Main(string[] args)
    {
        var _Context = new ApplicationDbContext();

        string zezoArt = @"
         _______  _______  _______  _______ 
        / ___   )(  ____ \/ ___   )(  ___  )
        \/   )  || (    \/\/   )  || (   ) |
            /   )| (__        /   )| |   | |
           /   / |  __)      /   / | |   | |
          /   /  | (        /   /  | |   | |
         /   (_/\| (____/\ /   (_/\| (___) |
        (_______/(_______/(_______/(_______)
                           
        ******** Welcom in main menu ********
        ";

        bool b = true;
        while (b)
        {
            Console.WriteLine(zezoArt);
            Console.WriteLine("1.Select from old files");
            Console.WriteLine("2.Add new file");
            Console.Write("Enter the number :");
            int flag = int.Parse(Console.ReadLine());

            switch (flag)
            {
                case 1:
                    SelectFromOldFiles(_Context);
                    break;
                case 2:
                    AddNewFile(_Context);
                    break;
                default:
                    b= false;
                    break;
            }
        
            Console.WriteLine("Do You want to continue ?(Y/N)");

            char x = Console.ReadLine()[0];

            if (x == 'N')
            {
                b= false;
            }
            else
            {
                Console.Clear();
            }
        }
    }
    public static void AddNewFile(ApplicationDbContext _Context)
    {
        Console.Clear();

        Console.Write("Enter File Path :");
        var filePath = Console.ReadLine();

        string FileData = "";
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                FileData += sr.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        List<FileComponent> output = new List<FileComponent>();

        for (int i = 0; i < FileData.Length;)
        {
            string id, len, data;
        
            string tempStr = "";
            for (int j = i; j < FileData.Length && j < i + 3; j++)
            {
                tempStr += FileData[j];
            }

            i += 3;
            id = tempStr;
            
            tempStr = "";
            for (int j = i; j < FileData.Length && j < i + 3; j++)
            {
                tempStr += FileData[j];
            }

            i += 3;
            len = tempStr;
            
            tempStr = "";
            for (int j = i; j < FileData.Length && j < i + int.Parse(len); j++)
            {
                tempStr += FileData[j];
            }
            
            data = tempStr;
            i += int.Parse(len);

            var _FileComponent = new FileComponent()
            {
                Category = int.Parse(id),
                LengthOfData = int.Parse(len),
                Data = data
            };
            output.Add(_FileComponent);
        }
        
        var file = new FileData()
        {
            Path = filePath,
            Components=output
        };
        
        _Context.Files.Add(file);
        _Context.SaveChanges();
        
        Console.WriteLine("Add successfully");
        Console.WriteLine("Do You want to print ?(Y/N)");

        char flag=Console.ReadLine()[0];

        if (flag == 'Y')
        {
            foreach (var x in output)
            {
                Console.WriteLine(x.Category+" "+x.LengthOfData+" "+x.Data);
            }
        }
    }

    public static void SelectFromOldFiles(ApplicationDbContext _Context)
    {
        Console.Clear();

        var allFiles = _Context.Files.ToList();
        foreach (var file in allFiles)
        {
            Console.WriteLine(file.FileDataId+"."+Path.GetFileName(file.Path));
        }
        
        Console.WriteLine("Enter the numder of file:");
        int id = int.Parse(Console.ReadLine());

        Console.Clear();
        var output=_Context.Components.Where(c => c.FileDataId == id).ToList();

        foreach (var x in output)
        {
            Console.WriteLine(x.Category + " " + x.LengthOfData + " " + x.Data);
        }
    }
}