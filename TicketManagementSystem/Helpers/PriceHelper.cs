using TicketManagementSystem.Models;

namespace TicketManagementSystem.Helpers
{
    public static class PriceHelper
    {
        public static double SetPrice(Priority priority)
        {
            return priority == Priority.High ? 100 : 50;
        }
    }
}
