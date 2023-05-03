using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Api.Repository;

namespace Api.Setup.Aws;

public static class AwsConfiguration
{
    public static IServiceCollection AddAws(this IServiceCollection services, IConfiguration configuration) {
        if (configuration.GetValue<bool>("aws:localstack")) {
            var localstack = configuration.GetValue<string>("aws:localstack-url") ?? "http://localhost:4566";
            const string region = "eu-west-1";

            services.AddSingleton<IAmazonDynamoDB>(new AmazonDynamoDBClient(new AmazonDynamoDBConfig
            {
                ServiceURL = localstack,
                UseHttp = true,
                AuthenticationRegion = region
            }));
        }
        else {
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonDynamoDB>();
        }

        services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
        services.AddSingleton<ILocationsRepository, LocationsRepository>();

        return services;
    }
}