using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAgreements
{
    public partial class MainPage : ContentPage
    {
        private const string api = "https://localhost:44328/Agreements";
        private readonly HttpClient http = new HttpClient();
        private ObservableCollection<AgreementsModel> _agreements;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            string query = await http.GetStringAsync(api);
            List<AgreementsModel> agreementsResult = JsonConvert.DeserializeObject<List<AgreementsModel>>(query);
            _agreements = new ObservableCollection<AgreementsModel>(agreementsResult);
            Agreements_List.ItemsSource = _agreements;
            base.OnAppearing();
        }
    }
}
