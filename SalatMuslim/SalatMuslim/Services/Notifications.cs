using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using SalatMuslim.ModelsDatabase;

namespace SalatMuslim.Services
{
    /// <summary>
    /// Class Notification [Unrealized]
    /// </summary>
    public class Notifications
    {
        #region Variables
        public int notificationId { get; set; } = 0;

        #endregion

        /// <summary>
        /// Class Notifictions Builder
        /// </summary>
        public Notifications()
        {
        }

        /// <summary>
        /// Create Notification
        /// </summary>
        /// <param name="title">string title</param>
        /// <param name="description">string description</param>
        /// <param name="time">string DateTime</param>
        private async void CreateNotification(string title, string description, DateTime time)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 2,
                Title = title,
                Description = description,
                NotificationId = notificationId,
                Schedule =
                {
                    NotifyTime = time
                }
            };
            await NotificationCenter.Current.Show(notification);
        }

        /// <summary>
        /// Call Notification
        /// </summary>
        public void CallNotification()
        {

            for (int i = DateTime.Now.Day - 1; i < App.executeApi.classRootInformation.data.Count; i++)
            {
                string month;
                var b = App.executeApi.classRootInformation.data[i].timings;
                List<string> salat = new List<string>() { b.Midnight, b.Imsak, b.Fajr, b.Sunrise, b.Dhuhr, b.Asr, b.Sunset, b.Maghrib, b.Isha };
                for (int j = 0; j < salat.Count; j++)
                {
                    var root = App.executeApi.classRootInformation.data[i].date.gregorian;
                    if (root.month.number < 10)
                        month = "0" + root.month.number.ToString();
                    else
                        month = root.month.number.ToString();
                    string heurePriere = $"{root.day}/{month}/{root.year} {salat[j].Split(' ')[0]}:00";
                    CreateNotification($"{salat[j]}", $"It's time for salat : {b.NameSalat[j]}", DateTime.Parse(heurePriere));
                    notificationId++;
                }
            }
            App.userRepository.UpdateDateMonthAsync(DateTime.Now.Month.ToString());
            App.dateMonth = DateTime.Now.Month.ToString();
        }

    }
}
