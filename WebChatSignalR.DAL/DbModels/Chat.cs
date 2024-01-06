namespace WebChatSignalR.DAL.DbModels;

public class Chat
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public int NewMessage { get; set; }

    public ICollection<ChatUser> ChatUsers { get; set; } = new List<ChatUser>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}