using WebChatSignalR.DAL.DbModels;

namespace WebChatSignalR.BL.Services.Interfaces;

public interface IChatConnectionService
{
    public Task AddConnection(ChatConnection model);
    public Task RemoveConnection(ChatConnection model);
    public Task<List<ChatConnection>> GetAllConnectionByUserId(Guid userId);

}