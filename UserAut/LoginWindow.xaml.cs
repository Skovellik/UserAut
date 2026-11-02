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
using System.Windows.Shapes;
using UserAut.Data;
using UserAut.Models;

namespace UserAut
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public User CurrentUser { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.login == login && u.pass == password);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль.");
                    return;
                }

                CurrentUser = user;
                this.Hide();

                try
                {
                    var main = new MainWindow(CurrentUser);

                    
                    Application.Current.MainWindow = main;

                    main.Show();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии главного окна:\n" + ex.Message);
                    this.Show();
                }
            }
        }
    }
}
