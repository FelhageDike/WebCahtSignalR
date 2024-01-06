using System.Collections.Concurrent;
using System.Text.Json.Serialization;

namespace WebChatSignalR.DAL.DbModels;

public class Message
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreationTime { get; set; }
    public bool IsModified { get; set; }
    public bool IsRead { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsDeletedForSender { get; set; }
    [JsonIgnore] public virtual Chat Chat { get; set; } = null!;
}