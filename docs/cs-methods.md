# Useful C# methods

## Download image

```cs
private static void DownloadImage(string url)
{
    var fileName = url.Split('/').Last();
    if(File.Exists(fileName))
    {
        return;
    }
    Console.WriteLine(url);
    var client = new WebClient();
    client.Headers.Add("user-agent", "Mozilla/5.0 (Linux; Android 10; Redmi Note 7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.98 Safari/537.36");
    client.DownloadFile(url.ToString(), fileName);
}
```

## Get all files

```cs
// GetAllFiles("c:\", "*.exe")
public static IEnumerable<string> GetAllFiles(string path, string mask, Func<FileInfo, bool>? checkFile = null)
{
    if (string.IsNullOrEmpty(mask))
        mask = "*.*";
    var files = Directory.GetFiles(path, mask, SearchOption.AllDirectories);
    foreach (var file in files)
    {
        if (checkFile == null || checkFile(new FileInfo(file)))
            yield return file;
    }
}
```

## Hosted service

```cs
public static class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseWindowsService() // support windows service
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<TestService>();
            }).Build();
        try
        {
            host.Run();
        }
        finally
        {
            host.Dispose();
        }
    }
}

public sealed class TestService : IHostedService
{
    private int _counter;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            while (true)
            {
                Thread.Sleep(500);
                _counter++;
                Console.WriteLine(_counter);
            }
        }).Start();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
```
