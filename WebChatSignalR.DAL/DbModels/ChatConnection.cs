namespace WebChatSignalR.DAL.DbModels;

public class ChatConnection
{
    public Guid UserId { get; set; }
    public string ConnectionId { get; set; } = null!;
}