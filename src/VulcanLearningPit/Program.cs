namespace VulcanLearningPit;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Vulcan Learning Pit!");
        Console.WriteLine($"Version: {GetVersion()}");
        
        if (args.Length > 0 && args[0] == "--version")
        {
            Console.WriteLine(GetVersion());
            return;
        }
        
        Console.WriteLine("\nA .NET learning platform for exploring code packaging and distribution.");
        Console.WriteLine("This is a sample application demonstrating proper packaging with SHA checksum validation.");
    }
    
    static string GetVersion()
    {
        return "1.0.0";
    }
}
