using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        //REGEX EXAMPLE
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
        //    {
        //        MessageBox.Show("Please enter only numbers.");
        //        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        //    }
        //}

        public RelayCommandMain BackCommand { get; set; }
        public RelayCommandMain SignInPagePassCommand { get; set; }
        public RelayCommandMain SignUpCommand { get; set; }
        public RelayCommandMain SendCodeEmailCommand { get; set; }

        public SignUpPage SignUpPage { get; set; }

        public UserContext UserContext { get; set; }

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
                    if (SignUpPage.tbEmail.Text != string.Empty && SignUpPage.pbPassword.Password == SignUpPage.pbConfirmPassword.Password)
                    {

                    }
                    else if (SignUpPage.tbEmail.Text != string.Empty && SignUpPage.pbPassword.Password != SignUpPage.pbConfirmPassword.Password)
                    {
                        MessageBox.Show("Parollar ust uste dusmur!");
                        signUpPage.pbPassword.Password = string.Empty;
                        signUpPage.pbConfirmPassword.Password = string.Empty;
                    }
                    else if (SignUpPage.tbEmail.Text == string.Empty && SignUpPage.pbPassword.Password != SignUpPage.pbConfirmPassword.Password)
                    {
                        MessageBox.Show("Email empty ve parollar ust uste dusmur");
                        signUpPage.pbPassword.Password = string.Empty;
                        signUpPage.pbConfirmPassword.Password = string.Empty;
                    }
                    else if (SignUpPage.tbEmail.Text == string.Empty)
                        MessageBox.Show("Email empty!");
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
                  else if (SignUpPage.pbPassword.Password != SignUpPage.pbConfirmPassword.Password)
                  {
                      notifier.ShowWarning("Passwords are not the same.Try again.");
                      signUpPage.pbPassword.Password = string.Empty;
                      signUpPage.pbConfirmPassword.Password = string.Empty;
                  }
                  else
                  {
                      //Emaile kod geden hisse.
                      MessageBox.Show(correctCode.ToString());
                      MailMessage message = new MailMessage();
                      SmtpClient smtp = new SmtpClient();

                      message.From = new MailAddress("idayatov256@gmail.com");

                      message.To.Add(new MailAddress(SignUpPage.tbEmail.Text));
                      message.Subject = "Təhlükəsizlik kodu";
                      message.Body = "Write this given code on text box\n" + correctCode + "\nThank you!";

                      smtp.Port = 587;
                      smtp.Host = "smtp.gmail.com";
                      smtp.EnableSsl = true;
                      smtp.UseDefaultCredentials = false;
                      smtp.Credentials = new NetworkCredential("idayatov256@gmail.com", "kenan239932");
                      smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                      smtp.Send(message);
                      notifier.ShowInformation("Enter the code sent to your email as \"register code\" ");

                      SignUpPage.btnCheckCode.Visibility = Visibility.Visible;
                      SignUpPage.tbregisterCode.IsEnabled = true;

                      if (SignUpPage.tbregisterCode.Text != correctCode.ToString())
                      {
                          notifier.ShowError("Please write the code sent to the email correctly.");
                      }



                      UserContext = new UserContext();

                      User newUser = new User
                      {
                          Firstname = SignUpPage.tbFirstname.Text,
                          Lastname = SignUpPage.tbLastname.Text,
                          Username = SignUpPage.tbUsername.Text,
                          PhoneNumber = SignUpPage.tbPhoneNumber.Text,
                          Email = SignUpPage.tbEmail.Text,
                          Password = SignUpPage.pbPassword.Password
                      };

                      UserContext.Users.Add(newUser);
                      UserContext.SaveChanges();
                      notifier.ShowSuccess("Successfully register.\nSign in sehfiesine qayidib girsi ede bilersiz :)");
                  }
              },
            pre => true);
        }

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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
