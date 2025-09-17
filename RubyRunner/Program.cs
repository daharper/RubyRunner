using System;
using System.IO;

namespace RubyRunner;

/// <summary>
/// Simple C# program to execute Ruby scripts, compatible with Ruby 1.9.2, using IronRuby.
/// </summary>
public class Program
{
    /// <summary>
    /// Loads and executes a Ruby script specified by the first command-line argument.
    /// If no argument is provided, it defaults to executing the script "Hello.rb".
    /// </summary>
    internal static void Main(string[] args)
    { 
        var path = args.Length > 0 ? args[0] : "Hello.rb";
        var text = File.Exists(path) ? File.ReadAllText(path) : "";
        var code = text.Trim();
        
        try
        {
            var runtime = IronRuby.Ruby.CreateRuntime();
            var engine = runtime.GetEngine("ruby");
            var scope = engine.CreateScope();

            engine.Execute(code, scope);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}

