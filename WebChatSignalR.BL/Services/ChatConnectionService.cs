using WebChatSignalR.BL.Services.Interfaces;
using WebChatSignalR.DAL.DbModels;

namespace WebChatSignalR.BL.Services;

public class ChatConnectionService : IChatConnectionService
{
    public Task AddConnection(ChatConnection model)
    {
        //
        throw new NotImplementedException();
    }

    public Task RemoveConnection(ChatConnection model)
    {
        throw new NotImplementedException();
    }

    public Task<List<ChatConnection>> GetAllConnectionByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }
}