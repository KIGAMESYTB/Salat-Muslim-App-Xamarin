using System;
using System.Collections.Generic;
using System.Text;

namespace SalatMuslim.Models
{
    /// <summary>
    /// Class Api
    /// </summary>
    public class Meta
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public Method method { get; set; }
        public string latitudeAdjustmentMethod { get; set; }
        public string midnightMode { get; set; }
        public string school { get; set; }
        public Offset offset { get; set; }
    }
}
