using System;
using System.Collections.Generic;
using System.Text;

namespace SalatMuslim.Models
{
    /// <summary>
    /// Class Api
    /// </summary>
    public class Date
    {
        public string readable { get; set; }
        public string timestamp { get; set; }
        public Gregorian gregorian { get; set; }
        public Hijri hijri { get; set; }
    }
}
