# AWS AppRunner & DynamoDB Demo

This code base demonstrates AWS Deploy tool for .NET ([see](https://aws.github.io/aws-dotnet-deploy/))

This .NET is based on DynamoDb Guide example [here](https://www.dynamodbguide.com/hierarchical-data)

# Locations 

Download locations CSV file from [here](https://www.kaggle.com/datasets/starbucks/store-location)


## Deployment project creation

```bash 
dotnet aws deployment-project generate --output ../Api.DeploymentProject --project-display-name "ASP.NET Core app with DynamoDB"
```

# Deploy 

```bash
dotnet aws deploy --project-path ./src/Api/Api.csproj
```
