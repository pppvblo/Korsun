using Korsun.ClassFolder;
using Korsun.DataFolder;
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

namespace Korsun.PageFolder.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
            AddRoleCB.ItemsSource = DBEntities.GetContext().Role.ToList();
        }

        private void AddtEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddLoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                AddLoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(AddPasswordTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                AddPasswordTB.Focus();
            }
            else if (AddRoleCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите роль");
                AddRoleCB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().User.Add(new User()
                    {
                        Login = AddLoginTB.Text,
                        Password = AddPasswordTB.Text,
                        IdRole = Int32.Parse(AddRoleCB.SelectedValue.ToString())
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Пользователь успешно добавлен");
                    NavigationService.Navigate(new ListUserPage());
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
