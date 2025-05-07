using ProgramModulesDevelopmentKursovik.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
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
using static System.Net.Mime.MediaTypeNames;

namespace ProgramModulesDevelopmentKursovik.Pages.Content
{
    /// <summary>
    /// Interaction logic for AddEditSpravochnikPage.xaml
    /// </summary>
    public partial class AddEditSpravochnikPage : Page
    {

        private object _currentItem;
        private string _type;
        private List<Field> _fields;


        public AddEditSpravochnikPage(object selectedItem, string type, string header) 
        {
            InitializeComponent();
            _type = type;
            _currentItem = selectedItem ?? CreateNewItem(type);
            _fields = DatabaseStructureHelper.GetTableFields(_type);
            DataContext = _currentItem;
            this.txbHeader.Text = header;
            CreateControls();
        }


        private object CreateNewItem(string itemType)
        {
            switch (itemType)
            {
                case "Requests":
                    Requests request = new Requests();
                    request.datefrom = DateTime.Now;
                    request.DoneStates = (AppConnect.model01.DoneStates.ToList()).Where(x => x.id == 1).First();
                    request.PaymentStates = (AppConnect.model01.PaymentStates.ToList()).Where(x => x.id == 1).First();
                    return request;
                case "DoneStates": return new DoneStates();
                case "EdIzm": return new EdIzm();
                case "Countries": return new Countries();
                case "Producers": return new Producers();
                case "Suppliers": return new Suppliers();
                case "Roles": return new Roles();
                case "PaymentStates": return new PaymentStates();
                default: throw new ArgumentException("Unknown item type");
            }
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (_type == "Requests")
                // TODO
                NavigationService.Navigate(new Pages.Content.ContentRequests(1));
            else
            {
                NavigationService.Navigate(new Pages.Content.Spravochnik(_type));
            }
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                try
                {
                    SaveItemToDatabase();
                    BtnCancel_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private bool Validate()
        {
            StringBuilder errors = new StringBuilder();
            foreach (Field field in _fields)
            {
                if (field.type == "string" || field.type == "date")
                {
                    object value = GetValueFromItemByReflection(_currentItem, field.name);
                    if (field.require)
                    {
                        if (value == null || String.IsNullOrEmpty(value.ToString()) || String.IsNullOrWhiteSpace(value.ToString()))
                        {
                            errors.AppendLine("Заполните поле «" + field.title + "»");
                        }
                    }
                }
                if (field.type == "foreignkey")
                {
                    object value = GetValueFromItemByReflection(_currentItem, field.itemsource);
                    if (value == null)
                    {
                        errors.AppendLine("Заполните поле «" + field.title + "»");
                    }
                }
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "При сохранении записи произошли ошибки", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }


        private object GetValueFromItemByReflection(object item, string field)
        {
            object value = null;
            switch (item)
            {
                case Requests re: value = re.GetType().GetProperty(field).GetValue(re); break;
                case DoneStates ds: value = ds.GetType().GetProperty(field).GetValue(ds); break;
                case EdIzm ei: value = ei.GetType().GetProperty(field).GetValue(ei); break;
                case Countries c: value = c.GetType().GetProperty(field).GetValue(c); break;
                case Producers p: value = p.GetType().GetProperty(field).GetValue(p); break;
                case Suppliers s: value = s.GetType().GetProperty(field).GetValue(s); break;
                case Roles r: value = r.GetType().GetProperty(field).GetValue(r); break;
                case PaymentStates ps: value = ps.GetType().GetProperty(field).GetValue(ps); break;
                default: throw new ArgumentException("Unknown item type");
            }
            return value;
        }


        private void SaveItemToDatabase()
        {
            var model = AppConnect.model01;
            var id = GetValueFromItemByReflection(_currentItem, "id");
            if ((int)id == 0)
            {
                switch (_currentItem)
                {
                    case Requests re: model.Requests.Add(re); break;
                    case DoneStates ds: model.DoneStates.Add(ds); break;
                    case EdIzm ei: model.EdIzm.Add(ei); break;
                    case Countries c: model.Countries.Add(c); break;
                    case Producers p: model.Producers.Add(p); break;
                    case Suppliers s: model.Suppliers.Add(s); break;
                    case Roles r: model.Roles.Add(r); break;
                    case PaymentStates ps: model.PaymentStates.Add(ps); break;
                }
            }
            model.SaveChanges();
        }



        private void CreateLabel(Field field, int j)
        {
            var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            ContainerGrid.RowDefinitions.Add(rowDefinition);

            rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            ContainerGrid.RowDefinitions.Add(rowDefinition);

            TextBlock tb = new TextBlock();
            tb.Text = field.title + ":";
            tb.Margin = new Thickness(0, 0, 0, 5);
            tb.TextWrapping = System.Windows.TextWrapping.Wrap;

            Grid.SetRow(tb, j);
            ContainerGrid.Children.Add(tb);
        }

        private void CreateControls()
        {
            int id = (int)GetValueFromItemByReflection(_currentItem, "id");

            int j = 2;
            foreach (Field field in _fields)
            {
                //Console.WriteLine("title: " + field.title);
                //Console.WriteLine("name: " + field.name);
                //Console.WriteLine("type: " + field.type);
                //Console.WriteLine("nullable: " + field.nullable);
                //Console.WriteLine("visible: " + field.visible);
                //Console.WriteLine("maxlength: " + field.maxlength);
                //Console.WriteLine();

                if (field.visible)
                {

                    switch (field.type)
                    {
                        case "string":
                        case "int":

                            CreateLabel(field, j++);

                            TextBox tbox = new TextBox();
                            SetControlProperties(tbox);
                            if (field.type == "string" && field.maxlength != null)
                            {
                                tbox.MaxLength = (int)field.maxlength;
                            }

                            Binding binding = new Binding(field.name);
                            tbox.SetBinding(TextBox.TextProperty, binding);

                            Grid.SetRow(tbox, j++);
                            ContainerGrid.Children.Add(tbox);

                            break;

                        case "date":

                            // Если это новая заявка (а дата только в заявках), то выключаем дату окончания работ
                            if (id == 0 && field.name == "dateto") continue;

                            CreateLabel(field, j++);
                            DatePicker dp = new DatePicker();
                            SetControlProperties(dp);

                            binding = new Binding(field.name);
                            dp.SetBinding(DatePicker.SelectedDateProperty, binding);

                            Grid.SetRow(dp, j++);
                            ContainerGrid.Children.Add(dp);

                            break;

                        case "foreignkey":

                            CreateLabel(field, j++);

                            ComboBox cb = new ComboBox();
                            SetControlProperties(cb);

                            if (field.itemsource == "Users")
                            {
                                cb.ItemsSource = AppConnect.model01.Users.ToList();
                                cb.DisplayMemberPath = "userinfo";
                            }
                            else if (field.itemsource == "DoneStates")
                            {
                                cb.ItemsSource = AppConnect.model01.DoneStates.ToList();
                                cb.DisplayMemberPath = "title";
                            }
                            else if (field.itemsource == "PaymentStates")
                            {
                                cb.ItemsSource = AppConnect.model01.PaymentStates.ToList();
                                cb.DisplayMemberPath = "title";
                            }
                            cb.SetBinding(ComboBox.SelectedItemProperty, new Binding(field.itemsource));

                            Grid.SetRow(cb, j++);
                            ContainerGrid.Children.Add(cb);

                            break;
                    }
                }
            }
        }

        private void SetControlProperties(Control c)
        {
            c.Width = 500;
            c.HorizontalAlignment = HorizontalAlignment.Left;
            c.Margin = new Thickness(0, 0, 0, 5);

            if (c is TextBox)
            {
                c.MinHeight = 30;
                c.Padding = new Thickness(0, 5, 0, 5);
                (c as TextBox).TextWrapping = TextWrapping.WrapWithOverflow;
            }
            if (c is DatePicker)
            {
                c.Height = 30;
                c.Padding = new Thickness(2, 5, 0, 0);
            }
            if (c is ComboBox)
            {
                c.Height = 29;
                c.Padding = new Thickness(3, 6, 0, 0);
            }
        }
    }
}