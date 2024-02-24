namespace File.Service.Entities;

/// <summary>
/// Some item.
/// </summary>
/// <param name="description"></param>
public class Item(string description)
{
    /// <summary>
    /// Describes <see cref="Item"/>.
    /// </summary>
    public string Description { get; } = description;
}
