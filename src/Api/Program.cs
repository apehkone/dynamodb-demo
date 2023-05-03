using Api.Repository;
using Api.Setup.Aws;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAws(builder.Configuration);

var app = builder.Build();

app.MapGet("/locations/{storeNumber}",
    async (string storeNumber, ILocationsRepository repository, CancellationToken cancellationToken)
        => await repository.GetByStoreNumber(storeNumber, cancellationToken));

app.MapGet("/locations/",
    async (string? state, string? city, string? postcode, string? country, ILocationsRepository repository, CancellationToken cancellationToken)
        => await repository.QueryByLocation(new LocationQuery(state, city, postcode, country ?? "US"), cancellationToken));

app.MapPost("/locations",
    async (Location location, ILocationsRepository repository, CancellationToken cancellationToken) =>
        await repository.SaveAsync(location, cancellationToken));

app.Run();