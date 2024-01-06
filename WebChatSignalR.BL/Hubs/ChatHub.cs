using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Pepegov.UnitOfWork;
using Pepegov.UnitOfWork.EntityFramework;
using WebChatSignalR.BL.Services.Interfaces;
using WebChatSignalR.DAL.DbModels;

namespace WebChatSignalR.BL.Hubs;

public class ChatHub : Hub
{
    private readonly IUnitOfWorkEntityFrameworkInstance _unitOfWork;
    private readonly IChatConnectionService _chatConnectionService;

    public ChatHub(IUnitOfWorkManager unitOfWorkManager, IChatConnectionService chatConnectionService)
    {
        _unitOfWork = unitOfWorkManager.GetInstance<IUnitOfWorkEntityFrameworkInstance>();
        _chatConnectionService = chatConnectionService;
    }

    public async Task SendMessageAsync(string message, Guid chatId, Guid userId)
    {
        var chatRepository = _unitOfWork.GetRepository<Chat>();

        //todo достать чат по id

        var chat = await chatRepository.GetFirstOrDefaultAsync(
            include:
            x =>
                x.Include(chat => chat.ChatUsers),
            predicate:
            x =>
                x.Id == chatId);

        if (chat is null)
        {
            throw new Exception("Chat is not found.");
        }

        //todo достать получателей

        var recipient = chat.ChatUsers.Where(x=> x.UserId != userId);


        //todo сохранить сообщение в базу

        var messageRepository = _unitOfWork.GetRepository<Message>();
        var newMessage = new Message()
        {
            Id = Guid.NewGuid(),
            Content = message,
            ChatId = chatId,
            CreationTime = DateTime.UtcNow,
            UserId = userId,
        };

        await messageRepository.InsertAsync(newMessage);


        //todo найти все подключения получателей по юзер id через iChatConnectionService
        var connections = await _chatConnectionService.GetAllConnectionByUserId(recipient.ToList());
        //todo отправить клиентам

        await Clients.Clients(connections).SendAsync("Receive", message);
    }

    public override async Task OnConnectedAsync()
    {
        //todo достать токен из контекста
        var userName = "1";
        var userId = Guid.NewGuid();

        var userData = new ChatConnection(userId, userName, Context.ConnectionId);

        //todo добавить юзера с помощью iChatConnectionService

        await _chatConnectionService.AddConnection(userData);

        await base.OnConnectedAsync();
    }


    public override async Task OnDisconnectedAsync(Exception exception)
    {
        //todo достать токен из контекста
        var targetConnectionId = Context.ConnectionId;
        //todo удалить юзера с помощью iChatConnectionService
        await _chatConnectionService.RemoveConnection(targetConnectionId);


        await base.OnDisconnectedAsync(exception);
    }
}