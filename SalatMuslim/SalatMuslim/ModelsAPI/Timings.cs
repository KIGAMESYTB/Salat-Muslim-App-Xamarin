
using System;
using System.Collections.Generic;
using System.Text;

namespace SalatMuslim.Models
{
    /// <summary>
    /// Class Api
    /// </summary>
    public class Timings
    {
        public string Fajr { get; set; }
        public string Sunrise { get; set; }
        public string Dhuhr { get; set; }
        public string Asr { get; set; }
        public string Sunset { get; set; }
        public string Maghrib { get; set; }
        public string Isha { get; set; }
        public string Imsak { get; set; }
        public string Midnight { get; set; }

        public List<string> NameSalat = new List<string>() { "Midnight", "Imsak", "Fajr", "Sunrise", "Dhuhr", "Asr", "Sunset", "Maghrib", "Isha" };
    }
}
