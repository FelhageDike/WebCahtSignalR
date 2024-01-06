using WebChatSignalR.DAL.DbModels;

namespace WebChatSignalR.BL.Services.Interfaces;

public interface IChatConnectionService
{
    public Task AddConnection(ChatConnection model);
    public Task RemoveConnection(string connectionId);
    public Task<List<string>> GetAllConnectionByUserId(List<ChatUser> chatUsers);

}