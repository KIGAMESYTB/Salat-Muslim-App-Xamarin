using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalatMuslim.Models;
using SalatMuslim.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalatMuslim.View
{
    /// <summary>
    /// Class Information Salat
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationSalatPage : ContentPage
    {
        #region Variables

        int _id { get; set; }
        #endregion

        /// <summary>
        /// Builder Page Information Salat
        /// </summary>
        /// <param name="id"></param>
        public InformationSalatPage(int id)
        {
            InitializeComponent();
            _id = id - 1;
            salatName();
        }

        #region Methods

        /// <summary>
        /// Salat information display
        /// </summary>
        private void salatName()
        {
            Timings salat = App.executeApi.classRootInformation.data[_id].timings;

            lblDate.Text = $"{App.executeApi.classRootInformation.data[_id].date.gregorian.weekday.en} {App.executeApi.classRootInformation.data[_id].date.readable}";
            lblFajr.Text = salat.Fajr;
            lblSunrise.Text = salat.Sunrise;
            lblDhuhr.Text = salat.Dhuhr;
            lblAsr.Text = salat.Asr;
            lblSunset.Text = salat.Sunset;
            lblMaghrib.Text = salat.Maghrib;
            lblIsha.Text = salat.Isha;
            lblImsak.Text = salat.Imsak;
            lblMidnight.Text = salat.Midnight;
        }

        #endregion
    }
}