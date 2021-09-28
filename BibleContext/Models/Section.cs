using System;
using System.Collections.Generic;
using System.Text;

namespace BibleContext.Models
{
    public class Section
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Verses { get; set; }
        public string BackgroundColor { get; set; }
        public int Order { get; set; }
        public string BookName { get; set; }
        public string Summary { get; set; }
        public bool HasSubsections { get; set; }
        public int SubSectionCount { get; set; }
        public List<SubCount> Count { get; set; }

        public ICollection<SubSection> Subsection { get; set; }

    }

    public class SubCount
    {
        public string SectionId { get; set; }
        public string SubColor { get; set; }
    }
}
