using System;

namespace Blazor.Login.Shared.Models
{
    public class HolidayResponse
    {
        public string Name { get; set; }

        public string LocalName { get; set; }

        public DateTime? Date { get; set; }

        public string CountryCode { get; set; }

        public bool Global { get; set; }
    }
}
