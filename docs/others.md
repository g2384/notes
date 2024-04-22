## ElasticSearch

---

If you ever need to delete all the indexes, this may come in handy:

```
curl -X DELETE 'http://localhost:9200/_all'
```

Powershell:

```ps1
Invoke-WebRequest -method DELETE http://localhost:9200/_all
```

Note: This will delete all data, including your x-pack access credentials and Kibana dashboard and visualizations

---

## .NET Lifecycle

https://learn.microsoft.com/en-us/dotnet/core/porting/versioning-sdk-msbuild-vs

| SDK Version | MSBuild/Visual Studio version | Ship date | Lifecycle |
| ----------- | ----------------------------- | --------- | --------- |
| 2.1.5xx     | 15.9                          | Nov '18   | Aug '21   |
| 2.1.8xx     | 16.2 (No VS)                  | July '19  | Aug '21   |
| 3.1.1xx     | 16.4                          | Dec '19   | Oct '21   |
| 3.1.4xx     | 16.7                          | Aug '20   | Dec '22   |

---

## RabbitMQ

RabbitMQ service won't start after upgrading:

1. Go back to the previous version and enable all required feature flags: https://www.rabbitmq.com/feature-flags.html#core-feature-flags
   1. check enabled flags: `rabbitmqctl list_feature_flags`
   2. enable flag(s): `rabbitmqctl enable_feature_flag all`, `rabbitmqctl enable_feature_flag <name>`

---

## .NET compatibility

https://nugettools.azurewebsites.net/6.7.0/get-nearest-framework

## How to make sure the code is correct:

- Testing (unit-testing, e2e testing)
- Review session