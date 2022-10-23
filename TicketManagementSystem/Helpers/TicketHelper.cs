using System;
using System.IO;
using TicketManagementSystem.Models.Exceptions;

namespace TicketManagementSystem.Helpers
{
    public static class TicketHelper
    {
        private static readonly string[] Keywords = { "Crash", "Important", "Failure" };

        public static bool ContainsExpediteKeyword(string title)
        {
            foreach (var keyword in Keywords)
            {
                return title.Contains(keyword, StringComparison.CurrentCultureIgnoreCase);
            }

            return false;
        }

        public static void ValidateTitleAndDescription(string title, string desc)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(desc))
            {
                throw new InvalidTicketException("Title or description were null");
            }
        }

        public static bool IsTicketOverdue(DateTime createDate)
        {
            return createDate < DateTime.UtcNow - TimeSpan.FromHours(1);
        }

        public static string GetFilePath(int ticketId)
        {
            return Path.Combine(Path.GetTempPath(), $"ticket_{ticketId}.json");
        }
    }
}
