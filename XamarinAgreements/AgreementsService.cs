using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAgreements
{
    class AgreementsService
    {
        private const string api = "https://localhost:44328/Agreements";
        private readonly HttpClient http = new HttpClient();

        public async Task<ObservableCollection<AgreementsModel>> GetAgreements()
        {
            string query = await http.GetStringAsync(api);
            List<AgreementsModel> agreementsResult = JsonConvert.DeserializeObject<List<AgreementsModel>>(query);
            return new ObservableCollection<AgreementsModel>(agreementsResult);
        }
    }
}
