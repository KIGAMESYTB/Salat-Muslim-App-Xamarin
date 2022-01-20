using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SalatMuslim.View;
using SalatMuslim.Models;
using SalatMuslim.ModelsDatabase;
using SalatMuslim.Services;
using Plugin.LocalNotification;
using Xamarin.Essentials;
using System.IO;
using SalatMuslim.RepositoryDatabase;

namespace SalatMuslim
{
    /// <summary>
    /// Class App
    /// </summary>
    public partial class App : Application
    {
        #region Variables

        private string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");
        public static UserRepository userRepository { get; set; }
        public static Execute executeApi { get; set; }
        public static string AffichageCity { get; set; } = "Start";
        public static bool firstOpen { get; set; } = false;
        public static string dateMonth { get; set; } = "0";
        private static List<User> user { get; set; }
        #endregion

        /// <summary>
        /// App builder
        /// </summary>
        public App()
        {
            InitializeComponent();
            userRepository = new UserRepository(dbPath);
            executeApi = new Execute();
            MainPage = new NavigationPage(new HomePage())
            {
                BarBackgroundColor = Color.PapayaWhip,
                BarTextColor = Color.Maroon
            };
        }

        /// <summary>
        /// Connection Database
        /// </summary>
        private async void Database()
        {
            user = await userRepository.GetListTableAsync();
            if (user.Count == 0)
                await userRepository.AddNewUserAsync();
            else
            {
                if (user[0].city != "" && user[0].country != "" && user[0].firstOpen)
                {
                    executeApi.informationApi(user[0].city, user[0].country);
                    AffichageCity = user[0].city;
                    dateMonth = user[0].dateMonth;
                    firstOpen = user[0].firstOpen;
                    await executeApi.callApiAsync();
                }
            }
        }

        /// <summary>
        /// function as soon as the application starts
        /// </summary>
        protected override void OnStart()
        {
            Database();
        }

        /// <summary>
        /// function as soon as the application sleeps
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// function as soon as the app comes back
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
