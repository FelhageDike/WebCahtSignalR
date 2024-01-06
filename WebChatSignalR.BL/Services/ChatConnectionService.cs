using Pepegov.UnitOfWork;
using Pepegov.UnitOfWork.EntityFramework;
using WebChatSignalR.BL.Services.Interfaces;
using WebChatSignalR.DAL.DbModels;

namespace WebChatSignalR.BL.Services;

public class ChatConnectionService : IChatConnectionService
{
    private readonly IUnitOfWorkEntityFrameworkInstance _unitOfWork;
    private readonly IChatConnectionService _chatConnectionService;
    
    public ChatConnectionService(IUnitOfWorkManager unitOfWorkManager, IChatConnectionService chatConnectionService)
    {
        _unitOfWork = unitOfWorkManager.GetInstance<IUnitOfWorkEntityFrameworkInstance>();
        _chatConnectionService = chatConnectionService;
    }
    public async Task AddConnection(ChatConnection model)
    {
        var connectionRepository = _unitOfWork.GetRepository<ChatConnection>();
        await connectionRepository.InsertAsync(model);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveConnection(string connectionId)
    {
        var connectionRepository = _unitOfWork.GetRepository<ChatConnection>();
        var connection = await connectionRepository.GetFirstOrDefaultAsync(
            predicate:
            x => x.ConnectionId == connectionId);
        if (connection is null)
        {
            //todo Add normal exception
            throw new Exception("Sosi");
        }
        connectionRepository.Delete(connection);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<string>> GetAllConnectionByUserId(List<ChatUser> chatUsers)
    {
        var targetIds = chatUsers.Select(x => x.UserId);
        var connectionRepository = _unitOfWork.GetRepository<ChatConnection>();
        var result = await connectionRepository.GetAllAsync(
            predicate: 
                x => targetIds.Contains(x.UserId),
            selector:
                x=> x.ConnectionId
            );
        return result.ToList();
    }
    
}