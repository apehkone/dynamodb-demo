using Api.Data;
using Api.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

public class LocationImporterTest : IClassFixture<AwsTestFixture>
{
    private readonly AwsTestFixture _fixture;
    
    public LocationImporterTest(AwsTestFixture fixture) {
        _fixture = fixture;
    }

    [Fact]
    public async Task ShouldImportLocations() {
        using var scope = _fixture.ServiceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetService<ILocationsRepository>();
        using var reader = new StreamReader(@"./InitialData/CSV/locations.csv");

        var importer = new LocationFileImporter(repository!);
        await importer.Import(reader, CancellationToken.None);
    }
}