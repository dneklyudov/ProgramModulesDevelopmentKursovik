using ProgramModulesDevelopmentKursovik.ApplicationData;
using ProgramModulesDevelopmentKursovik.ViewModel;
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
using ProgramModulesDevelopmentKursovik.Pages.Menu;
using ProgramModulesDevelopmentKursovik.Pages.Content;

namespace ProgramModulesDevelopmentKursovik.Pages
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void SetLoggedUserValues(String fio, String role, object menu, object main)
        {
            
            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Fio = fio;
            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Role = role;
            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Menu = (Page)menu;
            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = (Page)main;
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbEmail.Text == "a") tbEmail.Text = "admin@mail.ru";
                if (tbEmail.Text == "m") tbEmail.Text = "manager@mail.ru";
                if (tbEmail.Text == "c") tbEmail.Text = "client@mail.ru";

                var userObj = AppConnect.model01.Users.FirstOrDefault(x => x.email == tbEmail.Text && x.password == pbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь не найден", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch(userObj.role_id)
                    {
                        case 1:
                            // MessageBox.Show("Здравствуйте, " + userObj.name + " " + userObj.patronymic + "! Вы успешно авторизовались как администратор.", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Id = userObj.id;
                            SetLoggedUserValues(
                                userObj.name + " " + userObj.patronymic + " " + userObj.surname, 
                                "Администратор", 
                                new Pages.Menu.MenuAdmin(),
                                new Pages.Content.ContentRequests(userObj.Roles.id)
                            );                                
                            break;
                        case 2:
                            // MessageBox.Show("Здравствуйте, " + userObj.name + " " + userObj.patronymic + "! Вы успешно авторизовались как менеджер.", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Id = userObj.id;
                            SetLoggedUserValues(
                                userObj.name + " " + userObj.patronymic + " " + userObj.surname,
                                "Менеджер",
                                new Pages.Menu.MenuManager(),
                                new Pages.Content.ContentRequests(userObj.Roles.id)
                            );
                            break;
                        case 3:
                            // MessageBox.Show("Здравствуйте, " + userObj.name + " " + userObj.patronymic + "! Вы успешно авторизовались как заказчик.", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Id = userObj.id;
                            SetLoggedUserValues(
                                userObj.name + " " + userObj.patronymic + " " + userObj.surname,
                                "Заказчик",
                                new Pages.Menu.MenuClient(),
                                new Pages.Content.ContentRequests(userObj.Roles.id)
                            );
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                    Console.WriteLine(((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Id);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString(), "Критическая ошибка приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Reg());
        }
    }
}
