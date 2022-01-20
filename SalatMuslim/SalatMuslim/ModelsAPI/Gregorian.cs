using System;
using System.Collections.Generic;
using System.Text;

namespace SalatMuslim.Models
{
    /// <summary>
    /// Class Api
    /// </summary>
    public class Gregorian
    {
        public string date { get; set; }
        public string format { get; set; }
        public string day { get; set; }
        public Weekday weekday { get; set; }
        public Month month { get; set; }
        public string year { get; set; }
        public Designation designation { get; set; }
    }
}
