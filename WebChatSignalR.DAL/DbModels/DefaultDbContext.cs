
using Microsoft.EntityFrameworkCore;

namespace WebChatSignalR.DAL.DbModels;

public class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {

    }


    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatConnection> ChatConnections { get; set; }
    public DbSet<ChatUser> ChatUsers { get; set; }
    public DbSet<Message> Messages { get; set; }
}