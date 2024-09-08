using McCreate.App.Helper;
using McCreate.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace McCreate.App.Implementations.OS;

public class MCCreateLinux : IOSAction
{
    public string Name { get; set; } = "Linux Installer";

    public string SoftwareID { get; set; } = "mccreate";

    public async Task Execute(IServiceProvider serviceProvider)
    {
        var arch = await BashHelper.ExecuteCommand("uname -m | grep -q 'x86_64' && echo 'x64' || echo 'arm64'");

        var url = $"https://installer.system.nexocrew.space/mccreate/" + arch + "/McCreate";

        var client = serviceProvider.GetRequiredService<HttpClient>();
        var stream = await client.GetStreamAsync(url);
        var fs = new FileStream("/usr/local/bin/mccreate", FileMode.OpenOrCreate);
        await stream.CopyToAsync(fs);
        fs.Close();
        stream.Close();
        await BashHelper.ExecuteCommand("chmod -R 777 /usr/local/bin/mccreate");
    }
}