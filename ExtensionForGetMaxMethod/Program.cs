
using ExtensionForGetMaxMethod.Files;

namespace ExtensionForGetMaxMethod;
internal class Program
{
    static void Main(string[] args)
    {
        var fileLister = new FileSearcher();
        var files = new List<string>();
        fileLister.FileFound += (sender, e) =>
        {
            Console.WriteLine($"File found: {e.FoundFile}");
            files.Add(e.FoundFile);
            e.CancelRequested = false;
        };

        if(fileLister.CancelRequested)
        {
            Console.WriteLine("The file search was cancelled.");
        }

        fileLister.Search("path", "*.Format");
        var largestFile = files.GetMax(filePath => new FileInfo(filePath).Length);

        Console.WriteLine($"The largest file is {largestFile} with size {new FileInfo(largestFile).Length} byte ");
        Console.WriteLine($"Type of largestFile: {largestFile.GetType()}");
    }
}

