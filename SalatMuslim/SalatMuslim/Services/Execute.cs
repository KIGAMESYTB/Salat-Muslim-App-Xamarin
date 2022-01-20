using Newtonsoft.Json;
using SalatMuslim.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SalatMuslim.Services
{
    /// <summary>
    /// Classe Execute API
    /// </summary>
    public class Execute
    {
        #region Variables

        private const string API_URL = "https://api.aladhan.com/v1/calendarByCity";
        private string _url { get; set; }

        private HttpClient Client = new HttpClient();
        private string _city { get; set; }
        private string _country { get; set; }
        private string _method { get; set; }
        private string _month { get; set; }
        private string _year { get; set; }
        public Root classRootInformation { get; set; }

        #endregion

        /// <summary>
        /// Class Execute Builder
        /// </summary>
        public Execute()
        {
            _method = "3";
            classRootInformation = new Root();
        }

        /// <summary>
        /// Collect the necessary information
        /// </summary>
        /// <param name="city">String city</param>
        /// <param name="country">String country</param>
        public void informationApi(String city, String country)
        {
            _city = city;
            _country = country;
            _month = DateTime.Now.Month.ToString();
            _year = DateTime.Now.Year.ToString();

            _url = API_URL + "?city=" + _city + "&country=" + _country + "&method=" + _method + "&month=" + _month + "&year=" + _year; 
        }

        /// <summary>
        /// Call asynchronous api
        /// </summary>
        /// <returns></returns>
        public async Task callApiAsync()
        {
            try
            {
                var content = await Client.GetStringAsync(new Uri(_url));
                classRootInformation = JsonConvert.DeserializeObject<Root>(content);
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"Unable to connect with API\n{e.Message}", "OK");
            }
        }
         
    }
}
