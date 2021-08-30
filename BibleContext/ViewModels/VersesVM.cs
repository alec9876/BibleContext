using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BibleContext.ViewModels;
using BibleContext.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BibleContext.ViewModels
{
    public class VersesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Root> Scripture { get; set; }
        public ObservableCollection<string> Passage { get; set; }

        public VersesVM()
        {
            Scripture = new ObservableCollection<Root>();
            Passage = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string scripture)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(scripture));
        }

        public async void LoadPassage(string bookName, string verses)
        {
            try
            {
                var section = await Root.GetScripture(bookName, verses);

                Passage.Clear();
                foreach (var pas in section.passages)
                {
                    var newPas = Superscript(pas);
                    Passage.Add(newPas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string Superscript(string pas)
        {
            // For the record, I'm emarrassed by this

            var newPas = pas.Replace("[1]", "\u00B9").Replace("[2]", "\u00B2").Replace("[3]", "\u00B3")
                .Replace("[4]", "\u2074").Replace("[5]", "\u2075").Replace("[6]", "\u2076")
                .Replace("[7]", "\u2077").Replace("[8]", "\u2078").Replace("[9]", "\u2079")
                .Replace("[10]", "\u00B9\u2070").Replace("[11]", "\u00B9\u00B9").Replace("[12]", "\u00B9\u00B2")
                .Replace("[13]", "\u00B9\u00B3").Replace("[14]", "\u00B9\u2074").Replace("[15]", "\u00B9\u2075")
                .Replace("[16]", "\u00B9\u2076").Replace("[17]", "\u00B9\u2077").Replace("[18]", "\u00B9\u2078")
                .Replace("[19]", "\u00B9\u2079").Replace("[20]", "\u00B2\u00B9").Replace("[21]", "\u00B2\u00B9")
                .Replace("[22]", "\u00B2\u00B2").Replace("[23]", "\u00B2\u00B3").Replace("[24]", "\u00B2\u2074")
                .Replace("[25]", "\u00B2\u2075").Replace("[26]", "\u00B2\u2076").Replace("[27]", "\u00B2\u2077")
                .Replace("[28]", "\u00B2\u2078").Replace("[29]", "\u00B2\u2079").Replace("[30]", "\u00B3\u2070")
                .Replace("[31]", "\u00B3\u00B9").Replace("[32]", "\u00B3\u00B2").Replace("[33]", "\u00B3\u00B3")
                .Replace("[34]", "\u00B3\u2074").Replace("[35]", "\u00B3\u2075").Replace("[36]", "\u00B3\u2076")
                .Replace("[37]", "\u00B3\u2077").Replace("[38]", "\u00B3\u2078").Replace("[39]", "\u00B3\u2079")
                .Replace("[40]", "\u2074\u2070").Replace("[41]", "\u2074\u00B9").Replace("[42]", "\u2074\u00B2")
                .Replace("[43]", "\u2074\u00B3").Replace("[44]", "\u2074\u2074").Replace("[45]", "\u2074\u2075")
                .Replace("[46]", "\u2074\u2076").Replace("[47]", "\u2074\u2077").Replace("[48]", "\u2074\u2078")
                .Replace("[49]", "\u2074\u2079").Replace("[50]", "\u2075\u2070").Replace("[51]", "\u2075\u00B9")
                .Replace("[52]", "\u2075\u00B2").Replace("[53]", "\u2075\u00B3").Replace("[54]", "\u2075\u2074")
                .Replace("[55]", "\u2075\u2075").Replace("[56]", "\u2075\u2076").Replace("[57]", "\u2075\u2077")
                .Replace("[58]", "\u2075\u2078").Replace("[59]", "\u2075\u2079").Replace("[60]", "\u2076\u2070")
                .Replace("[61]", "\u2076\u00B9").Replace("[62]", "\u2076\u00B2").Replace("[63]", "\u2076\u00B3")
                .Replace("[64]", "\u2076\u2074").Replace("[65]", "\u2076\u2075").Replace("[66]", "\u2076\u2076")
                .Replace("[67]", "\u2076\u2077").Replace("[68]", "\u2076\u2078").Replace("[69]", "\u2076\u2079")
                .Replace("[70]", "\u2077\u2070").Replace("[71]", "\u2077\u00B9").Replace("[72]", "\u2077\u00B2")
                .Replace("[73]", "\u2077\u00B3").Replace("[74]", "\u2077\u2074").Replace("[75]", "\u2077\u2075")
                .Replace("[76]", "\u2077\u2076").Replace("[77]", "\u2077\u2077").Replace("[78]", "\u2077\u2078")
                .Replace("[79]", "\u2077\u2079").Replace("[80]", "\u2078\u2070").Replace("[81]", "\u2078\u00B9")
                .Replace("[82]", "\u2078\u00B2").Replace("[83]", "\u2078\u00B3").Replace("[84]", "\u2078\u2074")
                .Replace("[85]", "\u2078\u2075").Replace("[86]", "\u2078\u2076").Replace("[87]", "\u2078\u2077")
                .Replace("[88]", "\u2078\u2078").Replace("[89]", "\u2078\u2079").Replace("[90]", "\u2079\u2070")
                .Replace("[91]", "\u2079\u00B9").Replace("[92]", "\u2079\u00B2").Replace("[93]", "\u2079\u00B3")
                .Replace("[94]", "\u2079\u2074").Replace("[95]", "\u2079\u2075").Replace("[96]", "\u2079\u2076")
                .Replace("[97]", "\u2079\u2077").Replace("[98]", "\u2079\u2078").Replace("[99]", "\u2079\u2079")
                .Replace("[100]", "\u00B9\u2070\u2070").Replace("[101]", "\u00B9\u2070\u00B9").Replace("[102]", "\u00B9\u2070\u00B2")
                .Replace("[103]", "\u00B9\u2070\u00B3").Replace("[104]", "\u00B9\u2070\u2074").Replace("[105]", "\u00B9\u2070\u2075")
                .Replace("[106]", "\u00B9\u2070\u2076").Replace("[107]", "\u00B9\u2070\u2077").Replace("[108]", "\u00B9\u2070\u2078")
                .Replace("[109]", "\u00B9\u2070\u2079").Replace("[110]", "\u00B9\u00B9\u2070").Replace("[111]", "\u00B9\u00B9\u00B9")
                .Replace("[112]", "\u00B9\u00B9\u00B2").Replace("[113]", "\u00B9\u00B9\u00B3").Replace("[114]", "\u00B9\u00B9\u2074")
                .Replace("[115]", "\u00B9\u00B9\u2075").Replace("[116]", "\u00B9\u00B9\u2076").Replace("[117]", "\u00B9\u00B9\u2077")
                .Replace("[118]", "\u00B9\u00B9\u2078").Replace("[119]", "\u00B9\u00B9\u2079")
                .Replace("[120]", "\u00B9\u00B2\u2070").Replace("[121]", "\u00B9\u00B2\u00B9").Replace("[122]", "\u00B9\u00B2\u00B2")
                .Replace("[123]", "\u00B9\u00B2\u00B3").Replace("[124]", "\u00B9\u00B2\u2074").Replace("[125]", "\u00B9\u00B2\u2075")
                .Replace("[126]", "\u00B9\u00B2\u2076").Replace("[127]", "\u00B9\u00B2\u2077").Replace("[128]", "\u00B9\u00B2\u2078")
                .Replace("[129]", "\u00B9\u00B2\u2079").Replace("[130]", "\u00B9\u00B3\u2070").Replace("[131]", "\u00B9\u00B3\u00B9")
                .Replace("[132]", "\u00B9\u00B3\u00B2").Replace("[133]", "\u00B9\u00B3\u00B3").Replace("[134]", "\u00B9\u00B3\u2074")
                .Replace("[135]", "\u00B9\u00B3\u2075").Replace("[136]", "\u00B9\u00B3\u2076").Replace("[137]", "\u00B9\u00B3\u2077")
                .Replace("[138]", "\u00B9\u00B3\u2078").Replace("[139]", "\u00B9\u00B3\u2079")
                .Replace("[140]", "\u00B9\u2074\u2070").Replace("[141]", "\u00B9\u2074\u00B9").Replace("[142]", "\u00B9\u2074\u00B2")
                .Replace("[143]", "\u00B9\u2074\u00B3").Replace("[144]", "\u00B9\u2074\u2074").Replace("[145]", "\u00B9\u2074\u2075")
                .Replace("[146]", "\u00B9\u2074\u2076").Replace("[147]", "\u00B9\u2074\u2077").Replace("[148]", "\u00B9\u2074\u2078")
                .Replace("[149]", "\u00B9\u2074\u2079").Replace("[150]", "\u00B9\u2075\u2070").Replace("[151]", "\u00B9\u2075\u00B9")
                .Replace("[152]", "\u00B9\u2075\u00B2").Replace("[153]", "\u00B9\u2075\u00B3").Replace("[154]", "\u00B9\u2075\u2074")
                .Replace("[155]", "\u00B9\u2075\u2075").Replace("[156]", "\u00B9\u2075\u2076").Replace("[157]", "\u00B9\u2075\u2077")
                .Replace("[158]", "\u00B9\u2075\u2078").Replace("[159]", "\u00B9\u2075\u2079")
                .Replace("[160]", "\u00B9\u2076\u2070").Replace("[161]", "\u00B9\u2076\u00B9").Replace("[162]", "\u00B9\u2076\u00B2")
                .Replace("[163]", "\u00B9\u2076\u00B3").Replace("[164]", "\u00B9\u2076\u2074").Replace("[165]", "\u00B9\u2076\u2075")
                .Replace("[166]", "\u00B9\u2076\u2076").Replace("[167]", "\u00B9\u2076\u2077")
                .Replace("[168]", "\u00B9\u2076\u2078").Replace("[169]", "\u00B9\u2076\u2079")
                .Replace("[170]", "\u00B9\u2077\u2070").Replace("[171]", "\u00B9\u2077\u00B9").Replace("[172]", "\u00B9\u2077\u00B2")
                .Replace("[173]", "\u00B9\u2077\u00B3").Replace("[174]", "\u00B9\u2077\u2074").Replace("[175]", "\u00B9\u2077\u2075")
                .Replace("[176]", "\u00B9\u2077\u2076");

            return newPas;
        }
    }
}
