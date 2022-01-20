using System;
using System.Collections.Generic;
using System.Text;

namespace SalatMuslim.Models
{
    /// <summary>
    /// Class Api
    /// </summary>
    public class Root
    {
        public int code { get; set; }
        public string status { get; set; }
        public List<Datum> data { get; set; }
    }
}
