using Api.Setup.Aws;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

// ReSharper disable once ClassNeverInstantiated.Global
public class AwsTestFixture : IDisposable
{
    public ServiceProvider ServiceProvider { get; }

    public AwsTestFixture() {
        var config = new Dictionary<string, string?>
        {
            { "aws:localstack", "true" }
        };

        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(config).Build();
        services.AddAws(configuration);
        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) {
        if (!disposing) return;
        if (ServiceProvider != null) {
            ServiceProvider.Dispose();
        }
    }
}