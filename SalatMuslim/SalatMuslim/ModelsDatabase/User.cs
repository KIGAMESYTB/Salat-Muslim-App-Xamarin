using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Essentials;
using SQLite;

namespace SalatMuslim.ModelsDatabase
{
    /// <summary>
    /// Class User in database
    /// </summary>
    [Table ("User")]
    public class User
    {
        #region Variables

        [PrimaryKey,AutoIncrement, NotNull]
        public int ID { get; set; }

        [MaxLength(100)]
        public string city { get; set; }

        [MaxLength(100)]
        public string country { get; set; }

        public string dateMonth { get; set; }

        public bool firstOpen { get; set; }
        #endregion
    }
}
