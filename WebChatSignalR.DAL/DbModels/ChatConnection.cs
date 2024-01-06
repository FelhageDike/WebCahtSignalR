namespace WebChatSignalR.DAL.DbModels;

public class ChatConnection
{
    public ChatConnection(Guid userId,string userName, string connectionId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        ConnectionId = connectionId;
        UserName = userName;
    }

    public Guid Id { get; set; }
    public string UserName { get; set; }
    public Guid UserId { get; set; }
    public string ConnectionId { get; set; } = null!;
}