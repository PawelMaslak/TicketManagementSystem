using TicketManagementSystem.Models;

namespace TicketManagementSystem.Interfaces;

public interface ITicketRepository
{
    int CreateTicket(Ticket ticket);

    void UpdateTicket(Ticket ticket);

    Ticket GetTicket(int id);
}