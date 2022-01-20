using System;
using System.Collections.Generic;
using System.Text;

namespace SalatMuslim.Models
{
    /// <summary>
    /// Class Api
    /// </summary>
    public class Method
    {
        public int id { get; set; }
        public string name { get; set; }
        public Params @params { get; set; }
    }
}
