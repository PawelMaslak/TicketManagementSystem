using TicketManagementSystem.Interfaces;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.Exceptions;

namespace TicketManagementSystem.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserByName(string username)
        {
            return _userRepository.GetUser(username) ?? throw new UnknownUserException($"User {username} not found.");
        }

        public User GetAccountManager()
        {
            return _userRepository.GetAccountManager();
        }
    }
}
