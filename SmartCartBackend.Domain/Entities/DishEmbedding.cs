using System.Text.Json.Serialization;
using Pgvector;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class DishEmbedding : Entity<Guid>
{
    #region Constructors
    
    [JsonConstructor]
    protected DishEmbedding(
        Guid id,
        int dishId,
        string model,
        int textVersion,
        string contentHash, 
        DateTimeOffset updatedAt, 
        Vector embedding) : base(id)
    {
        DishId = dishId;
        Model = model;
        TextVersion = textVersion;
        ContentHash = contentHash;
        UpdatedAt = updatedAt;
        Embedding =  embedding;
    }

    public static DishEmbedding Create(
        Guid id,
        int dishId,
        string model,
        int textVersion,
        string contentHash,
        DateTimeOffset updatedAt,
        Vector embedding)
    {
        var dishEmbedding = new DishEmbedding(
            id, 
            dishId, 
            model, 
            textVersion,
            contentHash,
            updatedAt,
            embedding);
        
        return dishEmbedding;
    }
    
    #endregion Constructors
    
    public int DishId { get; private set; }

    public string Model { get; private set; }
    
    public int TextVersion { get; private set; }
    
    public string ContentHash { get; private set; }
    
    public DateTimeOffset UpdatedAt { get; private set; }
    
    public Vector Embedding { get; private set; }
}