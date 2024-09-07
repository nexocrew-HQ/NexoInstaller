using McCreate.App.Helper;
using McCreate.App.Interfaces;

namespace McCreate.App.Implementations.OS;

public class MCCreateWin : IOSAction
{
    public string Name { get; set; } = "Windows Installer";
    public string SoftwareID { get; set; } = "mccreate";

    public async Task Execute(IServiceProvider serviceProvider)
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var url =
            $"https://installer.system.nexocrew.space/mccreate/win/McCreate.exe";


        var client = new HttpClient();

        if (!Directory.Exists(path + "\\mccreate"))
            Directory.CreateDirectory(path + "\\mccreate");

        var stream = await client.GetStreamAsync(url);
        var fs = new FileStream(path + "\\mccreate\\mccreate.exe", FileMode.OpenOrCreate);
        await stream.CopyToAsync(fs);
        fs.Close();
        stream.Close();

        Environment.SetEnvironmentVariable("PATH", path + "\\mccreate", EnvironmentVariableTarget.Machine);
    }
}