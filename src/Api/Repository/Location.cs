using Amazon.DynamoDBv2.DataModel;

namespace Api.Repository;

[DynamoDBTable("StarbucksLocations")]
public class Location
{
    [DynamoDBHashKey]
    [DynamoDBProperty("StoreNumber")]
    public string? StoreNumber { get; set; }

    [DynamoDBProperty("City")]
    public string? City { get; set; }

    [DynamoDBProperty("Country")]
    [DynamoDBGlobalSecondaryIndexHashKey(new[] { "StoreLocationIndex" })]
    public string? Country { get; set; }

    [DynamoDBProperty("Latitude")]
    public string? Latitude { get; set; }

    [DynamoDBProperty("Longitude")]
    public string? Longitude { get; set; }

    [DynamoDBProperty("PhoneNumber")]
    public string? PhoneNumber { get; set; }

    [DynamoDBProperty("Postcode")]
    public string? Postcode { get; set; }

    [DynamoDBProperty("State")]
    public string? State { get; set; }

    [DynamoDBProperty("StateCityPostcode")]
    [DynamoDBGlobalSecondaryIndexRangeKey(new[] { "StoreLocationIndex" })]
    public string? StateCityPostcode { get; set; }

    [DynamoDBProperty("StoreName")]
    public string? StoreName { get; set; }

    [DynamoDBProperty("StreetAddress")]
    public string? StreetAddress { get; set; }
}