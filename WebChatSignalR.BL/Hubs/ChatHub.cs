using Microsoft.AspNetCore.SignalR;
namespace WebChatSignalR.BL.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessageAsync(string message, Guid chatId)
    {
        //todo достать чат по id
        //todo достать получателей
        
        //todo осхранить сообщение в базу 
        //todo найти все подключения получателей по юзер id через iChatConnectionService
        //todo отправить клиентам
        await Clients.Clients(List<string>).SendAsync("Receive", message);
        
    }

    public override Task OnConnectedAsync()
    {       
        //todo достать токен из контекста
        //todo добавить юзера с помощью iChatConnectionService
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        //todo достать токен из контекста
        //todo удалить юзера с помощью iChatConnectionService
        return base.OnDisconnectedAsync(exception);
    }
}