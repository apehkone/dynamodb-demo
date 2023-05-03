# AWS AppRunner & DynamoDB Demo

A simple demo project that demonstrates use of AWS .NET SDKs and AWS Deploy Tool for .NET ([see](https://aws.github.io/aws-dotnet-deploy/))

Functionality is an implementation of the DynamoDb Guide hierarchical data example [here](https://www.dynamodbguide.com/hierarchical-data)

# Locations 

Download locations CSV file from [here](https://www.kaggle.com/datasets/starbucks/store-location)

# Importing file 

The easiest way to import data to your environment is to run the integration test **ShouldImportLocations**

## Deployment project creation

```bash 
dotnet aws deployment-project generate --output ../Api.DeploymentProject --project-display-name "ASP.NET Core app with DynamoDB"
```

# Deploy 

```bash
dotnet aws deploy --project-path ./src/Api/Api.csproj
```


# Local test environment 

Run **docker compose up** in the local-test-env folder


