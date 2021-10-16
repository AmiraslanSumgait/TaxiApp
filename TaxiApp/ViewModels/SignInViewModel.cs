using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using TaxiApp.Command;
using TaxiApp.Data;
using TaxiApp.Models;
using TaxiApp.Views;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace TaxiApp.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public RelayCommandMain ExitCommand { get; set; }
        public RelayCommandMain SignUpPagePassCommand { get; set; }
        public RelayCommandMain SignInCommand { get; set; }
        public RelayCommandMain ForgotPasswordCommand { get; set; }
        public SignInPage SignInPage { get; set; }
        public UserContext UserContext { get; set; } = new UserContext();
        public User CurrentUser { get; set; }
        public SignInViewModel(SignInPage signInPage)
        {
            SignInPage = signInPage;
            ExitCommand = new RelayCommandMain(
               action =>
               {
                   Application.Current.Shutdown();
               },
               pre => true
               );

            SignUpPagePassCommand = new RelayCommandMain(
                action =>
                {
                    SignUpPage signUpPage = new SignUpPage();
                    SignInPage.signUpFrame.Navigate(signUpPage);
                },
                pre => true);

            SignInCommand = new RelayCommandMain(
                action =>
                {
                    if (SignInPage.tbEmail.Text == string.Empty || SignInPage.pbPassword.Password == string.Empty)
                        notifier.ShowInformation("Please fill in the information completely.");
                    else if (!Regex.IsMatch(SignInPage.tbEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                        notifier.ShowInformation("Please enter a valid email address.");
                    else if (UserContext.Users.Any(u => u.Email == SignInPage.tbEmail.Text && u.Password == SignInPage.pbPassword.Password))
                    {
                        notifier.ShowSuccess("The entry was successful. We'll take you to the main page in a few seconds.");
                        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };
                        timer.Start();
                        timer.Tick += (sender, args) =>
                        {
                            timer.Stop();
                            var window = Application.Current.MainWindow as InputScreen;
                            MainView mainView = new MainView();
                            window.Close();
                            mainView.ShowDialog();
                        };
                    }
                    else if (UserContext.Users.Any(u => u.Email == SignInPage.tbEmail.Text && u.Password != SignInPage.pbPassword.Password))
                        notifier.ShowWarning("That's not the right password. Please try again.");
                    else
                        notifier.ShowWarning("Couldn’t find a Taxi app account associated with this email. Please try again.");
                },
                pre => true);

            ForgotPasswordCommand = new RelayCommandMain(
                action =>
                {
                    ForgotPasswordPage forgotPasswordPage = new ForgotPasswordPage();
                    SignInPage.frameForgotPassword.Navigate(forgotPasswordPage);
                },
                pre => true);
        }

        #region Create notifier
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 310,
                offsetY: 5);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(2),
                maximumNotificationCount: MaximumNotificationCount.FromCount(2));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}