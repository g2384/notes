# Nuget

List direct and transitive packages referenced by a dotnet project/solution.

`dotnet list package --include-transitive`

Output:

```
Project 'Tests' has the following package references
   [netcoreapp3.1]:
   Top-level Package                               Requested   Resolved
   > coverlet.collector                            3.1.0       3.1.0
   > FluentAssertions                              6.2.0       6.2.0

   Transitive Package                                                                   Resolved
   > Microsoft.CodeAnalysis.Analyzers                                                   3.3.2
   > Microsoft.CodeAnalysis.Common                                                      3.11.0
   > Microsoft.CodeAnalysis.CSharp.Workspaces                                           3.11.0
```
