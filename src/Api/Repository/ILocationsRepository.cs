namespace Api.Repository;

public interface ILocationsRepository
{
    Task BatchSaveAsync(IEnumerable<Location> locations, CancellationToken cancellationToken);
    Task SaveAsync(Location entity, CancellationToken cancellationToken);
    Task<Location> GetByStoreNumber(string storeNumber, CancellationToken cancellationToken);
    Task<List<Location>> QueryByLocation(LocationQuery query, CancellationToken cancellationToken);
}