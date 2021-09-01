using BibleContext.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BibleContext.Models
{
    
    public class Root
    {
        public IList<string> passages { get; set; }
        public static async Task<Root> GetScripture(string bookName, string verses)
        {
            Root scripture = new Root();

            string url = VerseRoot.GenerateUrl(bookName, verses);
            string header = BibleApiService.API_KEY;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Token", header);
                 
                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

                //await Task.Delay(5000);
                if (response.IsSuccessStatusCode)
                {
                var json = await response.Content.ReadAsStringAsync();
                    var verseRoot = JsonConvert.DeserializeObject<Root>(json);
                    Console.WriteLine(verseRoot);
                    scripture = verseRoot;
                }
            }

            return scripture;
        }

        public class VerseRoot
        {
            public static string GenerateUrl(string bookName, string verse)
            {
                return string.Format(BibleApiService.SCRIPTURE, bookName, verse);
            }
        }
    }
}
