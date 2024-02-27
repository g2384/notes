## Versions

source: https://stackoverflow.com/a/1605873

There are three versions: **assembly**, **file**, and **product** (aka Assembly Informational Version). They are used by different features and take on different default values if you don't explicit specify them.

```cs
string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
assemblyVersion = Assembly.LoadFile("your assembly file").GetName().Version.ToString(); 
string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion; 
string productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
```

To specify these in the `AssemblyInfo.cs` file
  - for `assemblyVersion` use `[assembly: AssemblyVersion("2.0.*")]`;
  - for `fileVersion` `[assembly: AssemblyFileVersion("2.0.*")]`
  - for `productVersion` use `[assembly: AssemblyInformationalVersion("2.0.*")]`, it may take string suffix for `SemVer` compatibility:`[assembly: AssemblyInformationalVersion("2.0.0-alpha")]`
