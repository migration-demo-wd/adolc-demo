using System.CommandLine;
using System.Runtime.CompilerServices;

namespace AzureDevOpsLicenseChecker;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var helloOption = new Option<string>(
            name: "--hello",
            description: "bli bla blub");

        var rootCommand = new RootCommand("Azure DevOps License Checker");

        var helloWorldCommand = new Command("hello", "says whatever you write after option")
        {
            helloOption
        };

        helloWorldCommand.SetHandler(HelloWorld.Hello, helloOption);

        rootCommand.AddCommand(helloWorldCommand);

        return await rootCommand.InvokeAsync(args);
    }
}