using WebChatSignalR.BL.Services.Interfaces;
using WebChatSignalR.DAL.DbModels;

namespace WebChatSignalR.BL.Services;

public class MessageService : IMessageService
{
    public Task AddMessage(Message model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMessage(Guid messageId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMessage(Message model)
    {
        throw new NotImplementedException();
    }

    public Task GetMessageById(Guid messageId)
    {
        throw new NotImplementedException();
    }

    public Task GetAllMessageByChatId(Guid chatId)
    {
        throw new NotImplementedException();
    }
}