using ProgramModulesDevelopmentKursovik.ApplicationData;
using ProgramModulesDevelopmentKursovik.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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

namespace ProgramModulesDevelopmentKursovik.Pages.Content
{
    /// <summary>
    /// Interaction logic for Spravochnik.xaml
    /// </summary>
    public partial class Spravochnik : Page
    {
        private string className;

        public Spravochnik(string className)
        {
            InitializeComponent();

            this.className = className;

            this.DataContext = (Application.Current.MainWindow as MainWindow).DataContext;

            if (this.className == "DoneStates")
            {
                list.ItemsSource = ListDoneStates();
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).SpravochnikTitle = "Справочник статусов заказа";
            }
            else if (this.className == "EdIzm")
            {
                list.ItemsSource = ListEdIzm();
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).SpravochnikTitle = "Справочник единиц измерения";
            }
            else if (this.className == "Countries")
            {
                list.ItemsSource = ListCountries();
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).SpravochnikTitle = "Справочник стран";
            }
            else if (this.className == "Producers")
            {
                list.ItemsSource = ListProducers();
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).SpravochnikTitle = "Справочник производителей";
            }
            else if (this.className == "Suppliers")
            {
                list.ItemsSource = ListSuppliers();
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).SpravochnikTitle = "Справочник поставщиков";
            }
            else if (this.className == "Roles")
            {
                list.ItemsSource = ListRoles();
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).SpravochnikTitle = "Справочник ролей";
            }
            else if (this.className == "PaymentState")
            {
                list.ItemsSource = ListPaymentState();
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).SpravochnikTitle = "Справочник статусов оплаты";
            }
        }

        PaymentState[] ListPaymentState()
        {
            try
            {
                List<PaymentState> items = AppConnect.model01.PaymentState.ToList();
                if (TextSearch != null)
                {
                    items = items.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }
                return items.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }
        }

        Roles[] ListRoles()
        {
            try
            {
                List<Roles> items = AppConnect.model01.Roles.ToList();
                if (TextSearch != null)
                {
                    items = items.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }
                return items.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }
        }

        Suppliers[] ListSuppliers()
        {
            try
            {
                List<Suppliers> items = AppConnect.model01.Suppliers.ToList();
                if (TextSearch != null)
                {
                    items = items.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }
                return items.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }
        }

        Producers[] ListProducers()
        {
            try
            {
                List<Producers> items = AppConnect.model01.Producers.ToList();
                if (TextSearch != null)
                {
                    items = items.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }
                return items.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }
        }

        Countries[] ListCountries()
        {
            try
            {
                List<Countries> items = AppConnect.model01.Countries.ToList();
                if (TextSearch != null)
                {
                    items = items.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }
                return items.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }
        }


        EdIzm[] ListEdIzm()
        {
            try
            {
                List<EdIzm> items = AppConnect.model01.EdIzm.ToList();
                if (TextSearch != null)
                {
                    items = items.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }
                return items.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }
        }

        DoneStates[] ListDoneStates()
        {
            try
            {
                List<DoneStates> items = AppConnect.model01.DoneStates.ToList();
                if (TextSearch != null)
                {
                    items = items.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }
                return items.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.className == "DoneStates")
            {
                list.ItemsSource = ListDoneStates();
            }
            else if (this.className == "EdIzm")
            {
                list.ItemsSource = ListEdIzm();
            }
            else if (this.className == "Countries")
            {
                list.ItemsSource = ListCountries();
            }
            else if (this.className == "Producers")
            {
                list.ItemsSource = ListProducers();
            }
            else if (this.className == "Suppliers")
            {
                list.ItemsSource = ListSuppliers();
            }
            else if (this.className == "Roles")
            {
                list.ItemsSource = ListRoles();
            }
            else if (this.className == "PaymentState")
            {
                list.ItemsSource = ListPaymentState();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string header = "";

            if (this.className == "DoneStates")
            {
                header = "Справочник статусов заказа. Добавление элемента";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((DoneStates)null, this.className, header));
            }
            else if (this.className == "EdIzm")
            {
                header = "Справочник единиц измерения. Добавление элемента";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((EdIzm)null, this.className, header));
            }
            else if (this.className == "Countries")
            {
                header = "Справочник стран. Добавление элемента";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((Countries)null, this.className, header));
            }
            else if (this.className == "Producers")
            {
                header = "Справочник производителей. Добавление элемента";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((Producers)null, this.className, header));
            }
            else if (this.className == "Suppliers")
            {
                header = "Справочник поставщиков. Добавление элемента";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((Suppliers)null, this.className, header));
            }
            else if (this.className == "Roles")
            {
                header = "Справочник ролей. Добавление элемента";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((Roles)null, this.className, header));
            }
            else if (this.className == "PaymentState")
            {
                header = "Справочник статусов оплаты. Добавление элемента";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((PaymentState)null, this.className, header));
            }
        }

        private void BtnChangeInTable_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            string header = "";

            if (this.className == "DoneStates")
            {
                id = ((sender as Button).DataContext as DoneStates).id;
                header = "Справочник статусов заказа. Изменение элемента [id=" + id + "]";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((sender as Button).DataContext as DoneStates, this.className, header));
            }
            else if (this.className == "EdIzm")
            {
                id = ((sender as Button).DataContext as EdIzm).id;
                header = "Справочник единиц измерения. Изменение элемента [id=" + id + "]";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((sender as Button).DataContext as EdIzm, this.className, header));
            }
            else if (this.className == "Countries")
            {
                id = ((sender as Button).DataContext as Countries).id;
                header = "Справочник стран. Изменение элемента [id=" + id + "]";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((sender as Button).DataContext as Countries, this.className, header));
            }
            else if (this.className == "Producers")
            {
                id = ((sender as Button).DataContext as Producers).id;
                header = "Справочник производителей. Изменение элемента [id=" + id + "]";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((sender as Button).DataContext as Producers, this.className, header));
            }
            else if (this.className == "Suppliers")
            {
                id = ((sender as Button).DataContext as Suppliers).id;
                header = "Справочник поставщиков. Изменение элемента [id=" + id + "]";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((sender as Button).DataContext as Suppliers, this.className, header));
            }
            else if (this.className == "Roles")
            {
                id = ((sender as Button).DataContext as Roles).id;
                header = "Справочник ролей. Изменение элемента [id=" + id + "]";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((sender as Button).DataContext as Roles, this.className, header));
            }
            else if (this.className == "PaymentState")
            {
                id = ((sender as Button).DataContext as PaymentState).id;
                header = "Справочник статусов оплаты. Изменение элемента [id=" + id + "]";
                NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage((sender as Button).DataContext as PaymentState, this.className, header));
            }
        }

        private void BtnRemoveInTable_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить элемент (нужно проверить, что запись не используется в основной таблице и точно ли нужно удалить)?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    if (this.className == "DoneStates")
                    {
                        var itemForRemoving = (sender as Button).DataContext as DoneStates;
                        AppConnect.model01.DoneStates.Remove(itemForRemoving);
                        AppConnect.model01.SaveChanges();
                        list.ItemsSource = ListDoneStates();
                    }
                    else if (this.className == "EdIzm")
                    {
                        var itemForRemoving = (sender as Button).DataContext as EdIzm;
                        AppConnect.model01.EdIzm.Remove(itemForRemoving);
                        AppConnect.model01.SaveChanges();
                        list.ItemsSource = ListEdIzm();
                    }
                    else if (this.className == "Countries")
                    {
                        var itemForRemoving = (sender as Button).DataContext as Countries;
                        AppConnect.model01.Countries.Remove(itemForRemoving);
                        AppConnect.model01.SaveChanges();
                        list.ItemsSource = ListCountries();
                    }
                    else if (this.className == "Producers")
                    {
                        var itemForRemoving = (sender as Button).DataContext as Producers;
                        AppConnect.model01.Producers.Remove(itemForRemoving);
                        AppConnect.model01.SaveChanges();
                        list.ItemsSource = ListProducers();
                    }
                    else if (this.className == "Suppliers")
                    {
                        var itemForRemoving = (sender as Button).DataContext as Suppliers;
                        AppConnect.model01.Suppliers.Remove(itemForRemoving);
                        AppConnect.model01.SaveChanges();
                        list.ItemsSource = ListSuppliers();
                    }
                    else if (this.className == "Roles")
                    {
                        var itemForRemoving = (sender as Button).DataContext as Roles;
                        AppConnect.model01.Roles.Remove(itemForRemoving);
                        AppConnect.model01.SaveChanges();
                        list.ItemsSource = ListRoles();
                    }
                    else if (this.className == "PaymentState")
                    {
                        var itemForRemoving = (sender as Button).DataContext as PaymentState;
                        AppConnect.model01.PaymentState.Remove(itemForRemoving);
                        AppConnect.model01.SaveChanges();
                        list.ItemsSource = ListPaymentState();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}