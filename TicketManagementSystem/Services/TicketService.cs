using System;
using System.Text.Json;
using TicketManagementSystem.Helpers;
using TicketManagementSystem.Interfaces;
using TicketManagementSystem.Models;
using TicketManagementSystem.Repositories;

namespace TicketManagementSystem.Services
{
    public class TicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserService _userService;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _userService = new UserService(new UserRepository());
        }

        public int CreateTicket(string title, Priority priority, string assignedTo, string description, DateTime createDate, bool isPayingCustomer)
        {
            TicketHelper.ValidateTitleAndDescription(title, description);

            if (TicketHelper.IsTicketOverdue(createDate) || TicketHelper.ContainsExpediteKeyword(title))
            {
                TicketPriorityHelper.RaisePriority(ref priority);
            }

            var ticket = new Ticket()
            {
                Title = title,
                AssignedUser = _userService.GetUserByName(assignedTo),
                Priority = priority,
                Description = description,
                Created = createDate,
                PriceDollars = isPayingCustomer ? PriceHelper.SetPrice(priority) : 0,
                AccountManager = isPayingCustomer ? _userService.GetAccountManager() : null
            };

            return _ticketRepository.CreateTicket(ticket);
        }

        public void AssignTicket(int id, string username)
        {
            Ticket ticket = GetTicketById(id);
            ticket.AssignedUser = _userService.GetUserByName(username);
            _ticketRepository.UpdateTicket(ticket);
        }

        private Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetTicket(id) ?? throw new ApplicationException($"No ticket found for id {id}");
        }
    }
}
