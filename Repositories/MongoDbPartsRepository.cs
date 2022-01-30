
using MongoDB.Bson;
using MongoDB.Driver;
using otokocWebApi.Models;

namespace otokocWebApi.Repositories;


public class MongoDbPartsRepository : IPartsRepository
{
    private const string DATABASENAME = "catalog";
    private const string COLLECTIONNAME = "SpareParts";
    private readonly IMongoCollection<SparePart> PartsColection;

    private readonly FilterDefinitionBuilder<SparePart> filterBuilder=
        Builders<SparePart>.Filter;

    public MongoDbPartsRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(DATABASENAME);
        PartsColection = database.GetCollection<SparePart>(COLLECTIONNAME);
    }

    public async Task CreatePartAsync(SparePart part)
    {
        await PartsColection.InsertOneAsync(part);
    }

    public async Task DeletePartAsync(Guid id)
    {
        var Filter = filterBuilder.Eq( part => part.Id, id);

        await PartsColection.DeleteOneAsync(Filter);
    }

    public async Task<SparePart> GetPartAsync(Guid id)
    {
        var Filter = filterBuilder.Eq( part => part.Id, id);
        return await PartsColection.Find(Filter).SingleOrDefaultAsync();
    }

    // Get all parts
    public async Task<IEnumerable<SparePart>> GetPartsAsync()
    {
        return await PartsColection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdatePartAsync(SparePart part)
    {
        var Filter = filterBuilder.Eq(existingPart => existingPart.Id, part.Id);

        await PartsColection.ReplaceOneAsync(Filter, part);
    }
}


