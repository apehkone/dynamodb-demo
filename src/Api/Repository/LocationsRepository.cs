using System.Text;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace Api.Repository;

public class LocationsRepository : ILocationsRepository
{
    private readonly IDynamoDBContext _context;

    public LocationsRepository(IDynamoDBContext context) {
        _context = context;
    }

    
    public async Task BatchSaveAsync(IEnumerable<Location> locations, CancellationToken cancellationToken) {

        var batches = locations.Chunk(100);

        foreach (var locationBatch in batches) {
            var batch = _context.CreateBatchWrite<Location>();
        
            foreach (var location in locationBatch) {
                location.StateCityPostcode = $"{location.State}#{location.City}#{location.Postcode}";    
                batch.AddPutItem(location);
            }
            await batch.ExecuteAsync(cancellationToken);
        }
    }
    
    public async Task SaveAsync(Location entity, CancellationToken cancellationToken) {
        entity.StateCityPostcode = $"{entity.State}#{entity.City}#{entity.Postcode}";
        await _context.SaveAsync(entity, cancellationToken);
    }

    public async Task<Location> GetByStoreNumber(string storeNumber, CancellationToken cancellationToken) {
        return await _context.LoadAsync<Location>(storeNumber, cancellationToken);
    }

    public Task<List<Location>> QueryByLocation(LocationQuery query, CancellationToken cancellationToken) {
        var criteria = new StringBuilder();
        
        if (!string.IsNullOrEmpty(query.state)) {
            criteria.Append($"{query.state}#");
        }

        if (!string.IsNullOrEmpty(query.city) && !string.IsNullOrEmpty(query.city)) {
            criteria.Append($"{query.city}#");
        }

        if (!string.IsNullOrEmpty(query.city) && !string.IsNullOrEmpty(query.city) && !string.IsNullOrEmpty(query.postcode)) {
            criteria.Append($"{query.postcode}");
        }

        var config = new DynamoDBOperationConfig {
            IndexName = "StoreLocationIndex"
        };

        var result = string.IsNullOrEmpty(criteria.ToString()) ? 
            _context.QueryAsync<Location>(query.country, config) :
            _context.QueryAsync<Location>(query.country, QueryOperator.BeginsWith, new[] { criteria.ToString() },config);
       
        return result.GetRemainingAsync(cancellationToken);
    }
}