using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaxiApp.Command;
using TaxiApp.Data;
using TaxiApp.Models;
using TaxiApp.Views;

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
            MessageBox.Show(correctCode.ToString());

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
                  if (SignUpPage.tbregisterCode.Text == correctCode.ToString())
                  {
                      UserContext = new UserContext();

                      User newUser = new User
                      {
                          Firstname = SignUpPage.tbFirstname.Text,
                          Lastname = SignUpPage.tbLastname.Text,
                          PhoneNumber = SignUpPage.tbPhoneNumber.Text,
                          Email = SignUpPage.tbEmail.Text,
                          Password = SignUpPage.pbPassword.Password
                      };

                      UserContext.Users.Add(newUser);
                      UserContext.SaveChanges();
                      MessageBox.Show("Successfully register!");

                  }
                  else
                  {
                      MessageBox.Show("Register code yanlisdir.Try again!");
                  }
              },
            pre => true);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
