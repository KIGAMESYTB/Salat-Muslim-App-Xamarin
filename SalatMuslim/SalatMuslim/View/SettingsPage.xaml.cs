using SalatMuslim.ModelsDatabase;
using SalatMuslim.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalatMuslim.View
{
    /// <summary>
    /// Class Setting Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        #region Variables

        NetworkAccess current = Connectivity.NetworkAccess;
        Notifications notifications = new Notifications();
        #endregion

        /// <summary>
        /// Settings Page Builder
        /// </summary>
        public SettingsPage()
        {
            InitializeComponent();
        }

        #region Click

        /// <summary>
        /// Button click to execute API 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnExecuteApi(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (city.Text != "" && country.Text != "")
            {
                ActivityIndicatorConnection.IsVisible = true;
                ActivityIndicatorConnection.IsRunning = true;
                if (current == NetworkAccess.Internet)
                {
                    App.executeApi.informationApi(city.Text, country.Text);
                    await App.executeApi.callApiAsync();
                    if (App.executeApi.classRootInformation.status == "OK")
                    {
                        App.userRepository.UpdateCityCountryAsync(city.Text, country.Text);
                        if (DateTime.Now.Month.ToString() != App.dateMonth)
                            notifications.CallNotification();
                        App.userRepository.UpdateFirstOpenAsync(true);
                        App.AffichageCity = city.Text;
                        App.firstOpen = true;
                        ActivityIndicatorConnection.IsVisible = false;
                        ActivityIndicatorConnection.IsRunning = false;
                        lblError.Text = "The data has been successfully completed";
                    }
                    else
                    {
                        ActivityIndicatorConnection.IsVisible = false;
                        ActivityIndicatorConnection.IsRunning = false;
                        await DisplayAlert("ERROR", "Please provide correct city and country", "OK");
                        lblError.Text = "";
                    }
                }
                else
                {
                    ActivityIndicatorConnection.IsVisible = false;
                    ActivityIndicatorConnection.IsRunning = false;
                    await DisplayAlert("ERROR", "Cannot connect to network", "ok");
                    lblError.Text = "";
                }
            }
            else
            {
                ActivityIndicatorConnection.IsVisible = false;
                ActivityIndicatorConnection.IsRunning = false;
                await DisplayAlert("ERROR", "Please write in the missing fields", "OK");
                lblError.Text = "";
            }
        }
        #endregion
    }
}