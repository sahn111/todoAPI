namespace ToDoApi.Models;

public class ToDoListDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ToDoListCollectionName { get; set; } = null!;
}