
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

    public void CreatePart(SparePart part)
    {
        PartsColection.InsertOne(part);
    }

    public void DeletePart(Guid id)
    {
        var Filter = filterBuilder.Eq( part => part.Id, id);

        PartsColection.DeleteOne(Filter);
    }

    public SparePart GetPart(Guid id)
    {
        var Filter = filterBuilder.Eq( part => part.Id, id);
        return PartsColection.Find(Filter).SingleOrDefault();
    }

    // Get all parts
    public IEnumerable<SparePart> GetParts()
    {
        return PartsColection.Find(new BsonDocument()).ToList();
    }

    public void UpdatePart(SparePart part)
    {
        var Filter = filterBuilder.Eq(existingPart => existingPart.Id, part.Id);

        PartsColection.ReplaceOne(Filter, part);
    }
}


