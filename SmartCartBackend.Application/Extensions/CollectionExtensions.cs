using Pgvector;

namespace SmartCardBackend.Application.Extensions;

public static class CollectionExtensions
{
    public static Vector ToVector(this float[][] embedding)
    {
        var totalLength = embedding.Sum(array => array.Length);

        var flatArray = new float[totalLength];
        var index = 0;
    
        foreach (var array in embedding)
        {
            Array.Copy(array, 0, flatArray, index, array.Length);
            index += array.Length;
        }
    
        return new Vector(flatArray);
    }
}