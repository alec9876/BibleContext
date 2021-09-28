using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleContext.Models
{
    public class NewTestBooks
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string BookName { get; set; }
        public string Abbreviation { get; set; }
        public string BackgroundColor { get; set; }
        public string Genre { get; set; }
        public int Order { get; set; }

        public ICollection<Section> Section { get; set; }
    }
}
