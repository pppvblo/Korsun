using Korsun.ClassFolder;
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

namespace Korsun.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(RepeatPasswordTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                RepeatPasswordTB.Focus();
            }
            else
            {
                try
                {
                    DataFolder.DBEntities.GetContext()
                        .User.Add(new DataFolder.User()
                        {
                        Login = LoginTB.Text,
                        Password = PasswordTB.Text,
                        IdRole = 1,
                        });
                    DataFolder.DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Вы успешно зарегистрировались!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
