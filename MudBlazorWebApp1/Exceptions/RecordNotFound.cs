namespace MudBlazorWebApp1.Exceptions;

public class RecordNotFound(Type entityType, int id)
    : Exception($"Record of type {entityType.Name} with id {id} not found.")
{
    public Type EntityType { get; } = entityType;
    public int Id { get; } = id;
}