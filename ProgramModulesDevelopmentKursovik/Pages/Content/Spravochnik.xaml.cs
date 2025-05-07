using ProgramModulesDevelopmentKursovik.ApplicationData;
using ProgramModulesDevelopmentKursovik.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
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
        private readonly string className;

        public Spravochnik(string className)
        {
            InitializeComponent();
            this.className = className;
            this.DataContext = (Application.Current.MainWindow as MainWindow).DataContext;
            SetItemsSource();
            SetTitle();
        }

        private void SetItemsSource()
        {
            switch (className)
            {
                case "DoneStates": list.ItemsSource = ListItems<DoneStates>(); break;
                case "EdIzm": list.ItemsSource = ListItems<EdIzm>(); break;
                case "Countries": list.ItemsSource = ListItems<Countries>(); break;
                case "Producers": list.ItemsSource = ListItems<Producers>(); break;
                case "Suppliers": list.ItemsSource = ListItems<Suppliers>(); break;
                case "Roles": list.ItemsSource = ListItems<Roles>(); break;
                case "PaymentStates": list.ItemsSource = ListItems<PaymentStates>(); break;
                default: throw new ArgumentException("Unknown item type");
            }
        }

        private void SetTitle()
        {
            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).SpravochnikTitle = GetTitle();
        }

        private string GetTitle()
        {
            switch (className)
            {
                case "DoneStates": return "Справочник статусов заказа";
                case "EdIzm": return  "Справочник единиц измерения";
                case "Countries": return "Справочник стран";
                case "Producers": return "Справочник производителей"; 
                case "Suppliers": return "Справочник поставщиков";
                case "Roles": return "Справочник ролей";
                case "PaymentStates": return "Справочник статусов оплаты";
                default: throw new ArgumentException("Unknown item type");
            }
        }

        T[] ListItems<T>()
        {
            try
            {
                List<T> items = CreateList<T>();
                return items.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }
        }

        private List<T> CreateList<T>()
        {
            switch (className)
            {
                case "DoneStates": return (List<T>) FilterItems(AppConnect.model01.DoneStates.ToList());
                case "EdIzm": return (List<T>) FilterItems(AppConnect.model01.EdIzm.ToList());
                case "Countries": return (List<T>) FilterItems(AppConnect.model01.Countries.ToList());
                case "Producers": return (List<T>) FilterItems(AppConnect.model01.Producers.ToList());
                case "Suppliers": return (List<T>) FilterItems(AppConnect.model01.Suppliers.ToList());
                case "Roles": return (List<T>) FilterItems(AppConnect.model01.Roles.ToList());
                case "PaymentStates": return (List<T>) FilterItems(AppConnect.model01.PaymentStates.ToList());
                default: throw new ArgumentException("Unknown item type");
            }
        }

        private object FilterItems(object items)
        {
            if (TextSearch != null)
            {
                switch (items)
                {
                    case List<DoneStates> ds: return ds.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                    case List<EdIzm> ei: return ei.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                    case List<Countries> c: return c.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                    case List<Producers> p: return p.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                    case List<Suppliers> s: return s.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                    case List<Roles> r: return r.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                    case List<PaymentStates> ps: return ps.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                    default: throw new ArgumentException("Unknown item type");
                }
            }
            return null;
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetItemsSource();
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string header = GetTitle() + ". Добавление элемента";
            NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage(null, className, header));
        }


        private void BtnChangeInTable_Click(object sender, RoutedEventArgs e)
        {
            object datacontext = GetDataContext(sender);
            int id = GetId(datacontext);
            string header = GetTitle() + ". Изменение элемента [id=" + id + "]";
            NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage(datacontext, className, header));
        }

        private object GetDataContext(object sender) 
        {
            switch (className)
            {
                case "DoneStates": return (sender as Button).DataContext as DoneStates;
                case "EdIzm": return (sender as Button).DataContext as EdIzm;
                case "Countries": return (sender as Button).DataContext as Countries;
                case "Producers": return (sender as Button).DataContext as Producers;
                case "Suppliers": return (sender as Button).DataContext as Suppliers;
                case "Roles": return (sender as Button).DataContext as Roles;
                case "PaymentStates": return (sender as Button).DataContext as PaymentStates;
                default: throw new ArgumentException("Unknown item type");
            }
        }

        private int GetId(object datacontext)
        {
            switch (datacontext)
            {
                case DoneStates ds: return ds.id;
                case EdIzm ei: return ei.id;
                case Countries c: return c.id;
                case Producers p: return p.id;
                case Suppliers s: return s.id;
                case Roles r: return r.id;
                case PaymentStates ps: return ps.id;
                default: throw new ArgumentException("Unknown item type");
            }
        }


        private bool IsRecordRemoveable(object datacontext)
        {
            switch (datacontext)
            {
                case DoneStates ds: 
                    if (AppConnect.model01.Requests.FirstOrDefault(x => x.donestate_id == ds.id) == null) return true; 
                    return false;
                case EdIzm ei: return true;
                case Countries c: return true;
                case Producers p: return true;
                case Suppliers s: return true;
                case Roles r: return true;
                case PaymentStates ps:
                    if (AppConnect.model01.Requests.FirstOrDefault(x => x.paymentstate_id == ps.id) == null) return true;
                    return false;
                default: throw new ArgumentException("Unknown item type");
            }

        }


        private void BtnRemoveInTable_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить элемент?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    object datacontext = GetDataContext(sender);

                    if (!IsRecordRemoveable(datacontext))
                    {
                        MessageBox.Show($"Невозможно удалить запись, потому что она используется в списке заявок", "Внимание", MessageBoxButton.OK);
                        return;
                    }

                    switch (datacontext)
                    {
                        case DoneStates ds: AppConnect.model01.DoneStates.Remove(ds); break;
                        case EdIzm ei: AppConnect.model01.EdIzm.Remove(ei); break;
                        case Countries c: AppConnect.model01.Countries.Remove(c); break;
                        case Producers p: AppConnect.model01.Producers.Remove(p); break;
                        case Suppliers s: AppConnect.model01.Suppliers.Remove(s); break;
                        case Roles r: AppConnect.model01.Roles.Remove(r); break;
                        case PaymentStates ps: AppConnect.model01.PaymentStates.Remove(ps); break;
                        default: throw new ArgumentException("Unknown item type");
                    }
                    AppConnect.model01.SaveChanges();
                    SetItemsSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}