using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoApi.Models;

public class Todo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string TaskName { get; set; } = null!;

    public string TargetDuration { get; set; } = null!;

    public string Report { get; set; } = null!;
}