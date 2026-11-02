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
using UserAut.Data;
using UserAut.Models;

namespace UserAut
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly User _currentUser;

        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            try
            {
                UserInfoText.Text = $"Вы вошли как: {_currentUser.full_name} " +
                                    $"({(_currentUser.is_admin ? "администратор" : "пользователь")})";

                LoadUsers();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке главного окна:\n" + ex.Message);
            }
        }

        private void LoadUsers()
        {
            using (var db = new AppDbContext())
            {
                List<User> users;

                if (_currentUser.is_admin)
                {
                    users = db.Users.OrderBy(u => u.id).ToList();
                }
                else
                {
                    users = db.Users
                              .Where(u => u.id == _currentUser.id)
                              .ToList();
                }

                UsersGrid.ItemsSource = users;
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            Close();
        }
    }
}
