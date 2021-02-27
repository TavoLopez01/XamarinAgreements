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
        private ObservableCollection<AgreementsModel> _agreements;
        private readonly AgreementsService agreementsService = new AgreementsService();
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            _agreements = await agreementsService.GetAgreements();
            Agreements_List.ItemsSource = _agreements;
            base.OnAppearing();
        }
    }
}
