using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AutoSuggestFeature
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            List<string> _listSuggestion = null;
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                string text = sender.Text;

                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput && text.Length > 1)
                {
                    List<string> _nameList = new List<string>();
                    _nameList.Add("Sunni Jarman");
                    _nameList.Add("Yolanda Lager");
                    _nameList.Add("Ester Sheedy");
                    _nameList.Add("Mike Andrae");
                    _nameList.Add("Michael Sanders");
                    _nameList.Add("Mike Brown");
                    _nameList.Add("Chris Brown");
                    _listSuggestion = _nameList.Where(x => x.StartsWith(sender.Text, StringComparison.InvariantCultureIgnoreCase)).ToList();
                    sender.ItemsSource = _listSuggestion;
                }
                else
                {
                    sender.ItemsSource = new string[] { "No Suggestions.." };
                }
            }
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                txtAutoSuggestBox.Text = args.ChosenSuggestion.ToString();
            }
            else
            {
                txtAutoSuggestBox.Text = sender.Text;
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = args.SelectedItem.ToString();
            sender.Text = selectedItem;

        }
    }
}
