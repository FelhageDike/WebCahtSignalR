using System.Text.Json.Serialization;

namespace WebChatSignalR.DAL.DbModels;

public class ChatUser
{
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore] public virtual Chat Chat { get; set; } = null!;
}