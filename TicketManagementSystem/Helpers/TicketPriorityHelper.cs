using System;
using System.Linq;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Helpers
{
    public static class TicketPriorityHelper
    {
        private static readonly int MaxPriorityValue = (int)Enum.GetValues(typeof(Priority)).Cast<Priority>().Max();

        public static void RaisePriority(ref Priority currentPriority)
        {
            int currentPriorityValue = (int)currentPriority;

            if (currentPriorityValue < MaxPriorityValue)
            {
                currentPriority += 1;
            }
        }


    }
}
