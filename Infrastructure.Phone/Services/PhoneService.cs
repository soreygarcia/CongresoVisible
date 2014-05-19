using Infrastructure.Common.Contracts;
using Microsoft.Devices;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.IO;
using System.Windows;

namespace Infrastructure.Phone.Services
{
    public class PhoneService : IPhoneService
    {
        public PhoneService()
        {

        }

        public void Vibrate(int seconds)
        {
            VibrateController vibrateController = VibrateController.Default;
            vibrateController.Start(TimeSpan.FromSeconds(seconds));
        }

        public void PlaySound(string path)
        {
            Stream stream = TitleContainer.OpenStream(path);
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();
        }

        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK);
        }


        public void ShowToastNotification(string title, string content)
        {
            ShellToast toast = new ShellToast();
            toast.Title = title;
            toast.Content = content;
            toast.Show();
        }
        
        public void NavigateToUri(string url)
        {
            WebBrowserTask launcher = new WebBrowserTask();
            launcher.Uri = new Uri(url);
            launcher.Show();
        }

        public bool ShowConfirmationMessage(string title, string message)
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.OKCancel);

            return result == MessageBoxResult.OK;
        }
    }
}