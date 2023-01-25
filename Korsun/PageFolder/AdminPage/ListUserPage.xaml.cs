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
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            InitializeComponent();
            ListUser.ItemsSource = DBEntities.GetContext().User.ToList();
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = ListUser.SelectedItem as User;
                if (MBClass.QuestionMB($"Вы действительно хотите" +
                    $"удалить пользователя" +
                    $"{user.Login}"))
                {
                    DBEntities.GetContext().User.Remove(ListUser.SelectedItem as User);

                    DBEntities.GetContext().SaveChanges();

                    ListUser.ItemsSource = DBEntities.GetContext().User.ToList();
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListUser.SelectedValue == null)
                {
                    MBClass.InfoMB("Выберите пользователя");
                }
                else
                {
                    User user = ListUser.SelectedItem as User;
                    VariableClass.IdUser = user.IdUser;
                    NavigationService.Navigate(new EditUserPage(ListUser.SelectedItem as User));
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListUser.ItemsSource = DBEntities.GetContext().User.Where(
                u => u.Login.StartsWith(SearchTb.Text) ||
                u.Password.StartsWith(SearchTb.Text)).ToList();  
            }
            catch(Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
  
        }
    }
}
