using WebChatSignalR.DAL.DbModels;

namespace WebChatSignalR.BL.Services.Interfaces;

public interface IChatService
{
    public Task<Chat> CreateChat(Chat chat);
    public Task<Chat> UpdateChat(Chat chat);
    public Task DeleteChat(Chat chat);
    public Task JoinChat(Guid userId, Guid chatId);
    public Task LeaveChat(Guid userId, Guid chatId);
}