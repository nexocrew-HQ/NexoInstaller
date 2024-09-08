using System.Net;
using McCreate.App.Helper;
using McCreate.App.Interfaces;

namespace McCreate.App.Implementations.OS;

public class MCCreateLinux : IOSAction
{
    public string Name { get; set; } = "Linux Installer";

    public string SoftwareID { get; set; } = "mccreate";

    public async Task Execute(IServiceProvider serviceProvider)
    {

        var arch = await BashHelper.ExecuteCommand("uname -m | grep -q 'x86_64' && echo 'x64' || echo 'arm64'");
        
        var url = $"https://installer.system.nexocrew.space/mccreate/${arch}/McCreate";

        var client = new HttpClient();
        using var fs = File.Create("/usr/local/bin/mccreate");
        await BashHelper.ExecuteCommand("chmod -R 777 /usr/local/bin/mccreate");
        using var stream = await client.GetStreamAsync(url);
        await stream.CopyToAsync(fs);
        await fs.FlushAsync();
        fs.Close();
    }
}