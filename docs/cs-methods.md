# Useful C# methods

## Download Image

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
