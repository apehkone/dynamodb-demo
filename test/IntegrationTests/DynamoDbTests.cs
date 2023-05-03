using Api.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

public class DynamoDbTests : IClassFixture<AwsTestFixture>
{
    private readonly AwsTestFixture _fixture;

    public DynamoDbTests(AwsTestFixture fixture) {
        _fixture = fixture;
    }

    [Fact]
    public async Task ShouldInitializeDb() {
        using var scope = _fixture.ServiceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetService<ILocationsRepository>();

        var expected = new Location
        {
            StoreNumber = "3513-125945",
            StoreName = "Safeway-Anchorage #1809",
            PhoneNumber = "907-339-0900",
            StreetAddress = "5600 Debarr Rd Ste 9",
            Postcode = "995042300",
            City = "Anchorage",
            State = "AK",
            Country = "US",
            Latitude = "61.21",
            Longitude = "-149.78",
        };

        await repository!.SaveAsync(expected, CancellationToken.None);
        var result = await repository.GetByStoreNumber(expected.StoreNumber, CancellationToken.None);
        Assert.Equivalent(result, expected);
    }

    [Fact]
    public async Task ShouldQueryByLocation() {
        using var scope = _fixture.ServiceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetService<ILocationsRepository>();

        var results = await repository!.QueryByLocation(new LocationQuery("", "", "", "US"), CancellationToken.None);

        Assert.NotEmpty(results);
    }
}