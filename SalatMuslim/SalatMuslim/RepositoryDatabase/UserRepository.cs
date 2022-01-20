using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SalatMuslim.ModelsDatabase;
using System.Threading.Tasks;

namespace SalatMuslim.RepositoryDatabase
{
    /// <summary>
    /// Class UserRepository Database
    /// </summary>
    public class UserRepository
    {
        #region Variables

        SQLiteAsyncConnection connection;
        #endregion

        /// <summary>
        /// CLass UserRepository builder
        /// </summary>
        /// <param name="dbPath">database path</param>
        public UserRepository(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<User>();
        }

        #region Methods / Functions

        /// <summary>
        /// Add New User in Database
        /// </summary>
        /// <returns></returns>
        public async Task AddNewUserAsync()
        {
            int result = 0;
            try
            {
                result = await connection.InsertAsync(new User { city = "Tours", country = "France", dateMonth = DateTime.Now.Month.ToString(), firstOpen = false });

            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
        }

        /// <summary>
        /// Get List User in database
        /// </summary>
        /// <returns>List User</returns>
        public async Task<List<User>> GetListTableAsync()
        {
            try
            {
                return await connection.Table<User>().ToListAsync();
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", e.Message, "OK");
            }

            return new List<User>();
        }

        /// <summary>
        /// Update city and country in database
        /// </summary>
        /// <param name="city">string city</param>
        /// <param name="country">string country</param>
        public async void UpdateCityCountryAsync(string city, string country)
        {
            await connection.ExecuteAsync("UPDATE User SET city = ?, country = ? Where Id = ?",city,country, 1);
        }

        /// <summary>
        /// Update notificationId
        /// </summary>
        /// <param name="notifId">int IdNotification</param>
        public async void UpdateDateMonthAsync(string dateMonth)
        {
            await connection.ExecuteAsync("UPDATE User SET dateMonth = ? Where Id = ?", dateMonth, 1);
        }

        /// <summary>
        /// Update First Open Database
        /// </summary>
        /// <param name="firstOpen">bool first open</param>
        public async void UpdateFirstOpenAsync(bool firstOpen)
        {
            await connection.ExecuteAsync("UPDATE User SET firstOpen = ? Where Id = ?", firstOpen, 1);
            App.firstOpen = firstOpen;
        }

        /// <summary>
        /// Update Send Notification Database
        /// </summary>
        /// <param name="sendNotification">bool send Notification</param>
        public async void UpdateSendNotificationAsync(bool sendNotification)
        {
            await connection.ExecuteAsync("UPDATE User SET SendNotification = ? Where Id = ?", sendNotification, 1);
        }

        #endregion
    }
}
