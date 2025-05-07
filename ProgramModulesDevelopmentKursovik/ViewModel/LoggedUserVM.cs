using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProgramModulesDevelopmentKursovik.Pages;

namespace ProgramModulesDevelopmentKursovik.ViewModel
{
    internal class LoggedUserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private String _fio;
        public String Fio
        {
            get { return _fio; }
            set
            {
                _fio = value;
                OnPropertyChanged("Fio");
                if (_fio != "")
                {
                    Visibility = Visibility.Visible;
                }
                else
                {
                    Visibility = Visibility.Hidden;
                }
            }
        }

        private String _role;
        public String Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged("Role");
            }
        }

        private Visibility _visibility = Visibility.Hidden;
        public Visibility Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        private Page _menu;
        public Page Menu
        {
            get { return _menu; }
            set
            {
                _menu = value;
                OnPropertyChanged("Menu");
                ApplicationData.AppFrame.frameMenu.NavigationService.Navigate(_menu);
            }
        }

        private Page _main;
        public Page Main
        {
            get { return _main; }
            set
            {
                _main = value;
                OnPropertyChanged("Main");
                ApplicationData.AppFrame.frameMain.NavigationService.Navigate(_main);
            }
        }

        private String _spravochnikTitle;
        public String SpravochnikTitle
        {
            get { return _spravochnikTitle; }
            set
            {
                _spravochnikTitle = value;
                OnPropertyChanged("SpravochnikTitle");
            }
        }
    }
}
