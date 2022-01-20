using System;
using System.Collections.Generic;
using System.Text;

namespace SalatMuslim.Models
{
    /// <summary>
    /// Class Api
    /// </summary>
    public class Offset
    {
        public int Imsak { get; set; }
        public int Fajr { get; set; }
        public int Sunrise { get; set; }
        public int Dhuhr { get; set; }
        public int Asr { get; set; }
        public int Maghrib { get; set; }
        public int Sunset { get; set; }
        public int Isha { get; set; }
        public int Midnight { get; set; }
    }
}
