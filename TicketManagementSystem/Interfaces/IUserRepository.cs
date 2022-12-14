using TicketManagementSystem.Models;

namespace TicketManagementSystem.Interfaces
{
    internal interface IUserRepository
    {
        User GetUser(string username);
        User GetAccountManager();
    }
}
