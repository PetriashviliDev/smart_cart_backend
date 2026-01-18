using System.Text.Json.Serialization;
using Pgvector;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class DishEmbedding : Entity<Guid>
{
    #region Constructors

    private DishEmbedding(Guid id) : base(id) { }

    [JsonConstructor]
    protected DishEmbedding(
        Guid id,
        int dishId,
        string model,
        int dimensions,
        int textVersion,
        string contentHash, 
        DateTimeOffset updatedAt, 
        Vector embedding) : base(id)
    {
        DishId = dishId;
        Model = model;
        Dimensions = dimensions;
        TextVersion = textVersion;
        ContentHash = contentHash;
        UpdatedAt = updatedAt;
        Embedding =  embedding;
    }

    public static DishEmbedding Create(
        Guid id,
        int dishId,
        string model,
        int dimensions,
        string contentHash,
        DateTimeOffset updatedAt,
        Vector embedding)
    {
        var dishEmbedding = new DishEmbedding(
            id, 
            dishId, 
            model, 
            dimensions,
            1,
            contentHash,
            updatedAt,
            embedding);
        
        return dishEmbedding;
    }
    
    public void Update(
        string model,
        int dimensions,
        string contentHash,
        DateTimeOffset updatedAt,
        Vector embedding)
    {
        Model = model;
        Dimensions = dimensions;
        ContentHash = contentHash;
        UpdatedAt = updatedAt;
        Embedding = embedding;
    }
    
    #endregion Constructors
    
    public int DishId { get; private set; }

    public string Model { get; private set; }

    public int Dimensions { get; private set; }
    
    public int TextVersion { get; private set; }
    
    public string ContentHash { get; private set; }
    
    public DateTimeOffset UpdatedAt { get; private set; }
    
    public Vector Embedding { get; private set; }
}