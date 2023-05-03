using System.Globalization;
using Api.Repository;
using CsvHelper;

namespace Api.Data;

public class LocationFileImporter
{
    private readonly ILocationsRepository _repository;

    public LocationFileImporter(ILocationsRepository repository) {
        _repository = repository;
    }

    public async Task Import(StreamReader reader, CancellationToken cancellationToken) {
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<LocationMap>();

        var records = csv.GetRecords<Location>();
        await _repository.BatchSaveAsync(records, cancellationToken);
    }
}