using Api.Repository;
using CsvHelper.Configuration;

namespace Api.Data;

public class LocationMap : ClassMap<Location>
{
    public LocationMap() {
        Map(m => m.StoreNumber).Name("Store Number");
        Map(m => m.StoreName).Name("Store Name");
        Map(m => m.StreetAddress).Name("Street Address");
        Map(m => m.City).Name("City");
        Map(m => m.State).Name("State/Province");
        Map(m => m.Country).Name("Country");
        Map(m => m.Postcode).Name("Postcode");
        Map(m => m.PhoneNumber).Name("Phone Number");
        Map(m => m.Longitude).Name("Longitude");
        Map(m => m.Latitude).Name("Latitude");
    }
}