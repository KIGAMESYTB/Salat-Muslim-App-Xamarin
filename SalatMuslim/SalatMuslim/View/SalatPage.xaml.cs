using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SalatMuslim.Models;
using SalatMuslim.Services;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace SalatMuslim.View
{
    /// <summary>
    /// Class Salat Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalatPage : ContentPage
    {
        #region Variables
        List<Gregorian> listSalat;

        #endregion


        /// <summary>
        /// Salat Page Builder
        /// </summary>
        public SalatPage()
        {
            InitializeComponent();
            listSalat = new List<Gregorian>();
            ActualisationPage();
        }

        #region Methods / Function

        /// <summary>
        /// Page initialization methods
        /// </summary>
        private void ActualisationPage()
        {
            Task.Factory.StartNew(() =>
            {
                TimerHours();
            });
            Task.Factory.StartNew(() =>
            {
                NextTimeSalat();
            });
            lblCityCountryInformation.Text = App.executeApi.classRootInformation.data[0].meta.timezone.Replace("/", ",");
            Task.Run(listViewDate);
            list.ItemsSource = listViewDate();
        }
        
        /// <summary>
        /// Date Now each seconds
        /// </summary>
        private void TimerHours()
        {
            List<int> dateTimeNow;
            List<string> dateTimeString = new List<string>() { DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString() };
            
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                dateTimeNow = new List<int>() { DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second };
                for (int i=0; i<dateTimeNow.Count; i++)
                {
                    if (dateTimeNow[i] < 10)
                        dateTimeString[i] = $"0{ dateTimeNow[i]}";
                    else
                        dateTimeString[i] = dateTimeNow[i].ToString();

                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    lblTime.Text = $"{dateTimeString[0]} : {dateTimeString[1]} : {dateTimeString[2]}";
                });
                return true;
            });
        }

        /// <summary>
        /// Add list view method
        /// </summary>
        /// <returns>List View Date</returns>
        private List<Gregorian> listViewDate()
        {
            List<Gregorian> dateListView = new List<Gregorian>();

            for (int i = DateTime.Now.Day - 1; i < App.executeApi.classRootInformation.data.Count; i++)
            {
                Gregorian date = new Gregorian();
                date = App.executeApi.classRootInformation.data[i].date.gregorian;
                dateListView.Add(date);
            }
            return dateListView;
        }
        
        /// <summary>
        /// Calcul Next Time Salat
        /// </summary>
        private void NextTimeSalat()
        {
            var root = App.executeApi.classRootInformation.data[DateTime.Now.Day - 1].timings;
            List<string> salat = new List<string>() { root.Midnight, root.Imsak,  root.Fajr, root.Sunrise, root.Dhuhr, root.Asr, root.Sunset, root.Maghrib, root.Isha};

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                for (int i = 0; i < salat.Count; i++)
                {
                    string dateLimite = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} 23:59:59";
                    string heurePriere = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} {salat[i].Split(' ')[0]}:00";
                    string nameSalat = root.NameSalat[i];
                    var dateConvert = DateTime.Parse(heurePriere);
                    if (DateTime.Now < dateConvert && DateTime.Now <= DateTime.Parse(dateLimite))
                    {
                        TimeSpan dateSoustract = dateConvert - DateTime.Now;
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            lblProchaineSalat.Text = $"{nameSalat} in : {dateSoustract.Hours}:{dateSoustract.Minutes}:{dateSoustract.Seconds}";
                        });
                        i = salat.Count;
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            lblProchaineSalat.Text = $"There is no salat until tomorrow";
                        });
                    }
                }
                return true;
            });
        }

        #endregion

        #region Click
        /// <summary>
        /// Button click navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnListViewNavigation(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(new InformationSalatPage(int.Parse(btn.AutomationId)));
        }

        #endregion

    }
}