using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TaxiApp.Command;
using TaxiApp.Data;
using TaxiApp.Views;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace TaxiApp.ViewModels
{
    public class ForgotPasswordViewModel
    {
        public UserContext UserContext { get; set; } = new UserContext();

        public ForgotPasswordPage ForgotPasswordPage { get; set; }

        public RelayCommandMain SendCodeForgotPassCommand { get; set; }
        public RelayCommandMain UpdatePasswordCommand { get; set; }
        public RelayCommandMain CancelCommand { get; set; }

        private Random _randomCode { get; set; }

        public ForgotPasswordViewModel(ForgotPasswordPage forgotPasswordPage)
        {
            ForgotPasswordPage = forgotPasswordPage;

            _randomCode = new Random();
            int correctCode = _randomCode.Next(10000, 99999);

            SendCodeForgotPassCommand = new RelayCommandMain(
                action =>
                {
                    if (ForgotPasswordPage.btnSendCode.Content.ToString() == "Send Code")
                    {
                        if (ForgotPasswordPage.tbEmail.Text == "")
                            notifier.ShowInformation("Please fill in the blank.");
                        else if (ErrorService.IsError == true)
                            notifier.ShowInformation("Please enter a valid email address.");
                        else if (!UserContext.Users.Any(u => u.Email == ForgotPasswordPage.tbEmail.Text))
                            notifier.ShowWarning("This is not registered with gmail.");
                        else
                        {
                            //MessageBox.Show(correctCode.ToString());
                            Network.Network.SendNotification(ForgotPasswordPage.tbEmail.Text, "Verification code", "Welcome!\nUse the verification code this to login: " + correctCode + "\nThank you.");
                            ForgotPasswordPage.btnSendCode.Content = "Check Code";
                            ForgotPasswordPage.tbVertfCode.IsEnabled = true; ;
                        }
                    }
                    else
                    {
                        if (ForgotPasswordPage.tbVertfCode.Text == "")
                            notifier.ShowInformation("Please fill in the blank.");
                        else if (ForgotPasswordPage.tbVertfCode.Text != correctCode.ToString())
                            notifier.ShowWarning("Please write the code sent to the email correctly.");
                        else
                        {
                            notifier.ShowSuccess("The verification code is correct. You can now enter a new password.");
                            forgotPasswordPage.tbEmail.IsReadOnly = true;
                            forgotPasswordPage.tbVertfCode.IsReadOnly = true;
                            forgotPasswordPage.pbPassword.IsEnabled = true;
                            forgotPasswordPage.pbConfirmPass.IsEnabled = true;
                            forgotPasswordPage.btnUpdatePass.IsEnabled = true;
                            forgotPasswordPage.btnSendCode.IsEnabled = false;
                        }
                    }
                },
                pre => true);

            UpdatePasswordCommand = new RelayCommandMain(
                action =>
                {
                    if (ForgotPasswordPage.pbPassword.Password == ""
                    || ForgotPasswordPage.pbConfirmPass.Password == "")
                    {
                        notifier.ShowInformation("Please fill in the blanks.");
                    }
                    else if (ForgotPasswordPage.pbPassword.Password.Length < 8)
                    {
                        notifier.ShowWarning("Password must be at least 8 characters.");
                    }
                    else if (ForgotPasswordPage.pbPassword.Password != ForgotPasswordPage.pbConfirmPass.Password)
                    {
                        notifier.ShowWarning("Passwords are not the same.Try again.");
                        ForgotPasswordPage.pbPassword.Password = string.Empty;
                        ForgotPasswordPage.pbConfirmPass.Password = string.Empty;
                    }
                    else
                    {
                        var user = UserContext.Users.FirstOrDefault(u => u.Email == ForgotPasswordPage.tbEmail.Text);
                        user.Password = forgotPasswordPage.pbPassword.Password;
                        UserContext.SaveChanges();
                        notifier.ShowSuccess("Password changed successfully.");
                        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };
                        timer.Start();
                        timer.Tick += (sender, args) =>
                        {
                            timer.Stop();
                            ForgotPasswordPage.Visibility = Visibility.Hidden;
                        };
                        ForgotPasswordPage.btnUpdatePass.IsEnabled = false;
                    }
                },
                pre => true);

            CancelCommand = new RelayCommandMain(
                action => ForgotPasswordPage.Visibility = Visibility.Hidden,
                pre => true);
        }

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 415,
                offsetY: 5);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(2),
                maximumNotificationCount: MaximumNotificationCount.FromCount(2));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
    }
}
