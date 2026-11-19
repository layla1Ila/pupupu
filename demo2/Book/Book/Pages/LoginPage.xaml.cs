using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VariableLibrary.Services;

namespace Book.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        string currentLogin;
        public LoginPage()
        {
            InitializeComponent();
            currentLogin = LoginService.Instance.GetLogin();
            TBLoginCode.Text = currentLogin;
        }


        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TBCheckLogin.Text != currentLogin)
            {
                MessageBox.Show("Введен неверный код!");
                currentLogin = LoginService.Instance.GetLogin();
                TBLoginCode.Text = currentLogin;
                return;
            }
            NavigationService.Navigate(new MainPage());
        }
    }
}
