# Azure Pipelines

### Restore nuget packages from a private feed

1. If a nuget needs to be restored from a private feed:
2. Go to `Project settings` -> `Service connections` -> `New service connection` -> select `Nuget` -> fill in all fields -> save;
3. Run the pipeline, the pipeline should reture nuget with `NuGetCommand` step:
4. ```
      - task: NuGetCommand@2
        inputs:
          command: 'restore'
          restoreSolution: $(SolutionFile)
          feedsToUse: 'config'
          nugetConfigPath: '$(Sources)/nuget.config'
          configuration: '$(BuildConfiguration)'
   ```
5. **If it fails:**
6. Add `NuGetAuthenticate` step before `NuGetCommand` step:
7. ```
      - task: NuGetAuthenticate@1
        inputs:
          nuGetServiceConnections: 'MyFeed'
   ```
8. Run the pipeline;
9. **If it fails:**
10. Add `externalFeedCredentials` to the `NugetCommand` step:
11. ```
      - task: NuGetCommand@2
        inputs:
          command: 'restore'
          restoreSolution: $(SolutionFile)
          feedsToUse: 'config'
          nugetConfigPath: '$(Sources)/nuget.config'
          configuration: '$(BuildConfiguration)'
          externalFeedCredentials: 'MyFeed'
    ```
