using System.Diagnostics;

namespace McCreate.App.Helper;

public class BashHelper
{
    public static async Task<string> ExecuteCommand(string command, bool ignoreErrors = false, bool captureOutput = true, string? workingDir = default)
    {
        var process = await ExecuteCommandRaw(command, workingDir, captureOutput);

        var output = captureOutput ? await process.StandardOutput.ReadToEndAsync() : "";
        await process.WaitForExitAsync();

        if (process.ExitCode != 0)
        {
            if(!ignoreErrors)
                throw new Exception(output);
        }

        return output.Trim();
    }
    
    public static Task<Process> ExecuteCommandRaw(string command, string? workingDir = default, bool captureOutput = true)
    {
        Process process = new Process();
        
        process.StartInfo.FileName = "/bin/bash";
        process.StartInfo.Arguments = $"-c \"{command.Replace("\"", "\\\"")}\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = captureOutput;
        process.StartInfo.RedirectStandardError = captureOutput;

        if (workingDir != null)
            process.StartInfo.WorkingDirectory = workingDir;

        process.Start();

        return Task.FromResult(process);
    }
    
}