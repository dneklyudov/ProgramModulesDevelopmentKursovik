using ProgramModulesDevelopmentKursovik.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    /// Interaction logic for AddEditSpravochnikPage.xaml
    /// </summary>
    public partial class AddEditSpravochnikPage : Page
    {

        private DoneStates _objDoneStates = new DoneStates();
        private EdIzm _objEdIzm = new EdIzm();
        private Countries _objCountries = new Countries();
        private Producers _objProducers = new Producers();
        private Suppliers _objSuppliers = new Suppliers();
        private Roles _objRoles = new Roles();
        private PaymentState _objPaymentState = new PaymentState();

        private object _obj = new object();
        private string _type = "";

        public AddEditSpravochnikPage(DoneStates selectedItem, string type, string header)
        {
            InitializeComponent();
            _type = type;
            if (selectedItem != null) _objDoneStates = selectedItem;
            DataContext = _objDoneStates;
            this.txbHeader.Text = header;
        }

        public AddEditSpravochnikPage(EdIzm selectedItem, string type, string header)
        {
            InitializeComponent();
            _type = type;
            if (selectedItem != null) _objEdIzm = selectedItem;
            DataContext = _objEdIzm;
            this.txbHeader.Text = header;
        }

        public AddEditSpravochnikPage(Countries selectedItem, string type, string header)
        {
            InitializeComponent();
            _type = type;
            if (selectedItem != null) _objCountries = selectedItem;
            DataContext = _objCountries;
            this.txbHeader.Text = header;
        }

        public AddEditSpravochnikPage(Producers selectedItem, string type, string header)
        {
            InitializeComponent();
            _type = type;
            if (selectedItem != null) _objProducers = selectedItem;
            DataContext = _objProducers;
            this.txbHeader.Text = header;
        }

        public AddEditSpravochnikPage(Suppliers selectedItem, string type, string header)
        {
            InitializeComponent();
            _type = type;
            if (selectedItem != null) _objSuppliers = selectedItem;
            DataContext = _objSuppliers;
            this.txbHeader.Text = header;
        }

        public AddEditSpravochnikPage(Roles selectedItem, string type, string header)
        {
            InitializeComponent();
            _type = type;
            if (selectedItem != null) _objRoles = selectedItem;
            DataContext = _objRoles;
            this.txbHeader.Text = header;
        }

        public AddEditSpravochnikPage(PaymentState selectedItem, string type, string header)
        {
            InitializeComponent();
            _type = type;
            if (selectedItem != null) _objPaymentState = selectedItem;
            DataContext = _objPaymentState;
            this.txbHeader.Text = header;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Content.Spravochnik(_type));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            string title = "";

            if (_type == "DoneStates")
            {
                title = _objDoneStates.title;
            }
            else if (_type == "EdIzm")
            {
                title = _objEdIzm.title;
            }
            else if (_type == "Countries")
            {
                title = _objCountries.title;
            }
            else if (_type == "Producers")
            {
                title = _objProducers.title;
            }
            else if (_type == "Suppliers")
            {
                title = _objSuppliers.title;
            }
            else if (_type == "Roles")
            {
                title = _objRoles.title;
            }
            else if (_type == "PaymentState")
            {
                title = _objPaymentState.title;
            }

            if (String.IsNullOrEmpty(title) || String.IsNullOrWhiteSpace(title))
            {
                errors.AppendLine("Заполните название");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Не заполнены обязательные поля", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_type == "DoneStates")
            {
                if (_objDoneStates.id == 0)
                {
                    AppConnect.model01.DoneStates.Add(_objDoneStates);
                }
            }
            else if (_type == "EdIzm")
            {
                if (_objEdIzm.id == 0)
                {
                    AppConnect.model01.EdIzm.Add(_objEdIzm);
                }
            }
            else if (_type == "Countries")
            {
                if (_objCountries.id == 0)
                {
                    AppConnect.model01.Countries.Add(_objCountries);
                }
            }
            else if (_type == "Producers")
            {
                if (_objProducers.id == 0)
                {
                    AppConnect.model01.Producers.Add(_objProducers);
                }
            }
            else if (_type == "Suppliers")
            {
                if (_objSuppliers.id == 0)
                {
                    AppConnect.model01.Suppliers.Add(_objSuppliers);
                }
            }
            else if (_type == "Roles")
            {
                if (_objRoles.id == 0)
                {
                    AppConnect.model01.Roles.Add(_objRoles);
                }
            }
            else if (_type == "PaymentState")
            {
                if (_objPaymentState.id == 0)
                {
                    AppConnect.model01.PaymentState.Add(_objPaymentState);
                }
            }

            try
            {
                AppConnect.model01.SaveChanges();
                BtnCancel_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "При сохранении произошла ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}