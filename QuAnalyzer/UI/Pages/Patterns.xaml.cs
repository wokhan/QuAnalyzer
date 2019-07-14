using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages
{

    /// <summary>
    /// Interaction logic for Patterns.xaml
    /// </summary>
    public partial class Patterns : Page
    {
        public int SimThreshold { get; set; }
        public bool AutoUpdate { get; set; }


        public Patterns()
        {
            InitializeComponent();

        }

        /*Regex patRegChar = new Regex(@"[a-zA-Z]*");
        Regex patRegNum = new Regex(@"\d*");
        Regex patRegOther = new Regex(@"^\w*");

        Regex reg = new Regex(@"^(?:(?:(?<a>[a-zA-Z]*?)|(?<nw>\W*?)|(?<d>\d*?))*?)$", RegexOptions.Multiline);
        */

        private async void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prov = (IDataProvider)lstDataProviders.SelectedItem;
            var repo = (string)lstDataSources.SelectedValue;
            var attr = (string)lstAttributes.SelectedValue;

            if (repo != null && attr == null)
            {
                lstAttributes.ItemsSource = prov.GetColumns(repo).Where(h => h.Type == typeof(string)).Select(h => h.Name);
            }
            else if (AutoUpdate)
            {
                await compute();
            }
        }

        private async Task compute()
        {
            var prov = (IDataProvider)lstDataProviders.SelectedItem;
            var repo = (string)lstDataSources.SelectedValue;
            var attr = (string)lstAttributes.SelectedValue;

            if (repo != null && attr != null)
            {
                prg.IsIndeterminate = true;

                var res = await Task.Run(() =>
                {
                    var data = prov.GetData(repo, new[] { attr })
                                   .AsEnumerable()
                                   .Select((a, i) =>
                                   {
                                       Dispatcher.InvokeAsync(() => txtStatus.Text = "Loaded " + i + " entries...");
                                       return a.ToString();
                                   })
                                   .ToList();

                    Dispatcher.Invoke(() =>
                    {
                        prg.IsIndeterminate = false;
                        prg.Maximum = data.Count;
                    });

                    return data.Select((d, i) => { Dispatcher.InvokeAsync(() => prg.Value = i); return new { val = d, reg = GetRegEx(d) }; })
                               .ToList()
                               .GroupBy(s => s.reg)
                               .Select(g => new { Pattern = g.Key, Count = g.Count(), Sample = g.First().val })
                               .OrderByDescending(g => g.Count);
                });

                gridPatterns.ItemsSource = res;
            }
            else
            {
                gridPatterns.ItemsSource = null;
            }
        }

        private string GetRegEx(string src)
        {
            if (src == null)
            {
                return null;
            }

            var ex = ' ';
            var cpt = 1;

            return src.Select(c => c >= 'A' && c <= 'Z' ? 'w' : c >= 'a' && c <= 'z' ? 'w' : c >= '0' && c <= '9' ? 'd' : SimThreshold == 3 ? 'x' : c)
                  .Select(c =>
                  {
                      if (c == ex)
                      {
                          cpt++;
                          return "";
                      }
                      else if (ex != ' ')
                      {
                          var ret = form(ex, cpt);
                          ex = c;
                          cpt = 1;
                          return ret;
                      }
                      else
                      {
                          ex = c;
                          return "";
                      }
                  })
                  .Aggregate((a, b) => a + b) + form(ex, cpt);
        }

        private string form(char c, int cpt)
        {
            if (SimThreshold == 1)
            {
                return "\\" + c + "{" + cpt + "}";
            }
            else
            {
                return "\\" + c + "*";
            }
        }

        private void slideSim_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            SimThreshold = (int)e.NewValue;
            if (gridPatterns != null)
            {
                lstDataSources_SelectionChanged(null, null);
            }
        }

        private async void btnUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await compute();
        }
    }
}
