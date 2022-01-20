using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SalatMuslim.Services;
using SalatMuslim.ModelsDatabase;

namespace SalatMuslim.View
{
    /// <summary>
    /// Class Home Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        /// <summary>
        /// home page builder
        /// </summary>
        public HomePage()
        {
            InitializeComponent();
            btnStart.Text = App.AffichageCity;
        }

        /// <summary>
        /// Page d'actualisation
        /// </summary>
        protected override void OnAppearing()
        {
            btnStart.Text = App.AffichageCity;
            base.OnAppearing();
        }

        #region Click

        /// <summary>
        /// Button click to start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStart_Clicked(object sender, EventArgs e)
        {
            if (App.firstOpen)
            {
                indicatorPageSalat.IsVisible = true;
                indicatorPageSalat.IsRunning = true;
                await Navigation.PushAsync(new SalatPage());
                indicatorPageSalat.IsVisible = false;
                indicatorPageSalat.IsRunning = false;
            }
            else
                await DisplayAlert("Welcome to you", "Please go to settings to save your city", "It's understood"); 
        }

        /// <summary>
        /// Button click to settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSettings(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
        #endregion
    }
}