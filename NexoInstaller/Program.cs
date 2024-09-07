using McCreate.App;
using McCreate.App.Extensions;
using McCreate.App.Implementations.OS;
using McCreate.App.Implementations.Software;
using McCreate.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace McCreate;

class Program
{
    static void Main(string[] args)
    {
        ApplicationBuilder<EntryPoint> applicationBuilder = new();

        // Add Services here
        // applicationBuilder.Services.AddSingleton<YourService>();
        // just use singletons, because other service types wouldn't really make sense in this project

        applicationBuilder.Services.AddSingleton<HttpClient>();

        // Add Plugins here
        // applicationBuilder.Implementations.RegisterImplementation<IInterface, Implementation>();

        applicationBuilder.Implementations.RegisterImplementation<IProgramAction, MCCreate>();
        applicationBuilder.Implementations.RegisterImplementation<IOSAction, MCCreateLinux>();
        applicationBuilder.Implementations.RegisterImplementation<IOSAction, MCCreateWin>();
        


        // Build the application
        Application<EntryPoint> application = applicationBuilder.Build();

        // Start the application
        application.Start();
    }
}