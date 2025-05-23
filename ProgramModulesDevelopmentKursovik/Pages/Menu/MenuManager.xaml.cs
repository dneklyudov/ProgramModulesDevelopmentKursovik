﻿using System;
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
using ProgramModulesDevelopmentKursovik.Pages;
using ProgramModulesDevelopmentKursovik.ViewModel;

namespace ProgramModulesDevelopmentKursovik.Pages.Menu
{
    /// <summary>
    /// Interaction logic for MenuManager.xaml
    /// </summary>
    public partial class MenuManager : Page
    {
        public MenuManager()
        {
            InitializeComponent();
            ButtonMenu_Click(btnRequests, null);
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuHelper.SetStyleOfActiveMenuButton(sender);
            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.ContentRequests(2);
        }
    }
}
