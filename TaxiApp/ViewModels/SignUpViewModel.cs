using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
    public class SignUpViewModel
    {

        public RelayCommandMain BackCommand { get; set; }
        public RelayCommandMain SignInPagePassCommand { get; set; }
        public RelayCommandMain SignUpCommand { get; set; }
        public RelayCommandMain SendCodeEmailCommand { get; set; }

        public SignUpPage SignUpPage { get; set; }

        public UserContext UserContext { get; set; } = new UserContext();

        private Random _randomCode { get; set; }

        public SignUpViewModel(SignUpPage signUpPage)
        {
            SignUpPage = signUpPage;
            SignUpPage.tbregisterCode.PreviewTextInput += NumberValidationTextBox;

            BackCommand = new RelayCommandMain(
                action =>
                {
                    SignInPage signInPage = new SignInPage();
                    SignUpPage.NavigationService.Navigate(signInPage);
                },
                pre => true);

            SignInPagePassCommand = BackCommand;

            _randomCode = new Random();
            int correctCode = _randomCode.Next(10000, 99999);


            SendCodeEmailCommand = new RelayCommandMain(
                action =>
                {
                    if (SignUpPage.tbFirstname.Text == ""
                    || SignUpPage.tbLastname.Text == ""
                    || SignUpPage.tbPhoneNumber.Text == ""
                    || SignUpPage.tbEmail.Text == ""
                    || SignUpPage.pbPassword.Password == ""
                    || SignUpPage.pbConfirmPassword.Password == ""
                    || SignUpPage.tbUsername.Text == "")
                    {
                        notifier.ShowInformation("Please fill in the information completely.");
                    }
                    else if (SignUpPage.pbPassword.Password.Length < 8)
                    {
                        notifier.ShowWarning("Password must be at least 8 characters.");
                    }
                    else if (SignUpPage.pbPassword.Password != SignUpPage.pbConfirmPassword.Password)
                    {
                        notifier.ShowWarning("Passwords are not the same. Try again.");
                        signUpPage.pbPassword.Password = string.Empty;
                        signUpPage.pbConfirmPassword.Password = string.Empty;
                    }
                    else if (ErrorService.IsError == true)
                    {
                        notifier.ShowWarning("Please enter the information correctly.");
                    }
                    else if (UserContext.Users.Any(u => u.Username == SignUpPage.tbUsername.Text))
                    {
                        notifier.ShowWarning("There is already an account with this username. Please check another username.");
                        SignUpPage.tbUsername.Text = "";
                    }
                    else if (UserContext.Users.Any(u => u.Email == SignUpPage.tbEmail.Text))
                    {
                        notifier.ShowWarning("There is already an account with this email. Please check another email.");
                        SignUpPage.tbEmail.Text = "";
                    }
                    else
                    {
                        UserContext = new UserContext();
                        //Email side
                        try
                        {
                            SignUpPage.btnSendCode.Visibility = Visibility.Hidden;
                            Network.Network.SendNotification(SignUpPage.tbEmail.Text, "Verification code", "Welcome!\nUse the verification code this to login: " + correctCode + "\nThank you.");
                            SignUpPage.tbregisterCode.IsEnabled = true;
                            SignUpPage.btnSignUp.IsEnabled = true;
                            notifier.ShowInformation("Enter the code sent to your email as a registration code after sign up.");
                        }
                        catch (Exception ex)
                        {
                            notifier.ShowError(ex.Message);
                        }
                    }
                },
                pre => true);

            SignUpCommand = new RelayCommandMain(action =>
            {
                if (SignUpPage.tbFirstname.Text == ""
                || SignUpPage.tbLastname.Text == ""
                || SignUpPage.tbPhoneNumber.Text == ""
                || SignUpPage.tbEmail.Text == ""
                || SignUpPage.pbPassword.Password == ""
                || SignUpPage.pbConfirmPassword.Password == ""
                || SignUpPage.tbUsername.Text == "")
                {
                    notifier.ShowInformation("Please fill in the information completely.");
                }
                else if (SignUpPage.pbPassword.Password.Length < 8)
                {
                    notifier.ShowWarning("Password must be at least 8 characters.");
                }
                else if (SignUpPage.pbPassword.Password != SignUpPage.pbConfirmPassword.Password)
                {
                    notifier.ShowWarning("Passwords are not the same.Try again.");
                    signUpPage.pbPassword.Password = string.Empty;
                    signUpPage.pbConfirmPassword.Password = string.Empty;
                }
                else if (SignUpPage.tbregisterCode.Text != correctCode.ToString())
                {
                    notifier.ShowWarning("Please write the code sent to the email correctly.");
                }
                else if (ErrorService.IsError == true)
                {
                    notifier.ShowWarning("Please enter the information correctly.");
                }
                else if (UserContext.Users.Any(u => u.Username == SignUpPage.tbUsername.Text))
                {
                    notifier.ShowWarning("There is already an account with this username. Please check another username.");
                    SignUpPage.tbUsername.Text = "";
                }
                else if (UserContext.Users.Any(u => u.Email == SignUpPage.tbEmail.Text))
                {
                    notifier.ShowWarning("There is already an account with this email. Please check another email.");
                    SignUpPage.tbEmail.Text = "";
                }
                else
                {
                    User newUser = new User
                    {
                        Firstname = SignUpPage.tbFirstname.Text,
                        Lastname = SignUpPage.tbLastname.Text,
                        Username = SignUpPage.tbUsername.Text,
                        PhoneNumber = SignUpPage.tbPhoneNumber.Text,
                        Email = SignUpPage.tbEmail.Text,
                        Password = SignUpPage.pbPassword.Password
                    };
                    newUser.Firstname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newUser.Firstname.ToLower());
                    newUser.Lastname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newUser.Firstname.ToLower());
                    UserContext.Users.Add(newUser);
                    UserContext.SaveChanges();
                    notifier.ShowSuccess("Successfully register.\nWe will direct you to the sign in page for a few seconds.");
                    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };
                    timer.Start();
                    timer.Tick += (sender, args) =>
                    {
                        timer.Stop();
                        SignInPage signInPage = new SignInPage();
                        SignUpPage.NavigationService.Navigate(signInPage);
                    };
                }
            },
            pre => true);
        }

        #region Create notifier
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 5,
                offsetY: 5);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(2),
                maximumNotificationCount: MaximumNotificationCount.FromCount(2));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
        #endregion

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
