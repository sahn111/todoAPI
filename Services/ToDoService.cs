using ToDoApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ToDoApi.Services;

public class TodoService
{
    private readonly IMongoCollection<Todo> _todoCollection;

    public TodoService(
        IOptions<ToDoListDatabaseSettings> todoListDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            todoListDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            todoListDatabaseSettings.Value.DatabaseName);

        _todoCollection = mongoDatabase.GetCollection<Todo>(
            todoListDatabaseSettings.Value.ToDoListCollectionName);
    }

    public async Task<List<Todo>> GetAsync() =>
        await _todoCollection.Find(_ => true).ToListAsync();

    public async Task<Todo?> GetAsync(string id) =>
        await _todoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Todo newTodo) =>
        await _todoCollection.InsertOneAsync(newTodo);

    public async Task UpdateAsync(string id, Todo updatedTodo) =>
        await _todoCollection.ReplaceOneAsync(x => x.Id == id, updatedTodo);

    public async Task RemoveAsync(string id) =>
        await _todoCollection.DeleteOneAsync(x => x.Id == id);
}