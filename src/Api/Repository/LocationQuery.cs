namespace Api.Repository;

public record LocationQuery(string? state, string? city, string? postcode, string country = "US");