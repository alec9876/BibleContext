using System;
using System.Collections.Generic;
using System.Text;

namespace BibleContext.Services
{
    public class BibleApiService
    {
        public const string SCRIPTURE = "https://api.esv.org/v3/passage/text/?q={0}+{1}&include-headings=False&include-footnotes=False";
        public const string API_KEY = "";
    }
}
