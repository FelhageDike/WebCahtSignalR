using WebChatSignalR.DAL.DbModels;

namespace WebChatSignalR.BL.Services.Interfaces;

public interface IMessageService
{
    public Task AddMessage(Message model);
    public Task DeleteMessage(Guid messageId);
    public Task UpdateMessage(Message model);
    public Task GetMessageById(Guid messageId);
    public Task GetAllMessageByChatId(Guid chatId);

}