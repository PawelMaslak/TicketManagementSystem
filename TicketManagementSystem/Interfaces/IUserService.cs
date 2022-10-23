using TicketManagementSystem.Models;

namespace TicketManagementSystem.Interfaces
{
    internal interface IUserService
    {
        User GetUserByName(string username);
        User GetAccountManager();
    }
}
