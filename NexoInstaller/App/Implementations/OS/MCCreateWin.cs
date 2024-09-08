using McCreate.App.Helper;
using McCreate.App.Interfaces;

namespace McCreate.App.Implementations.OS;

public class MCCreateWin : IOSAction
{
    public string Name { get; set; } = "Windows Installer";
    public string SoftwareID { get; set; } = "mccreate";

    public async Task Execute(IServiceProvider serviceProvider)
    {

        await BashHelper.ExecuteCommand("winget install mccreate");


    }
}