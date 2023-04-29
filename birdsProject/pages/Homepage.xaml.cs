using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using MaterialDesignThemes.Wpf;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WPF_login;

namespace birdsProject.pages
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : System.Windows.Controls.Page
    {
        public Homepage()
        {
            InitializeComponent();
        }
        public bool IsDarkTheme { get; set; }

        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        //===================================>

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void GoToAnotherPage(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Uri("SignUp.xaml", UriKind.Relative));
        }
        private void addCager(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Uri("pages/addCage.xaml", UriKind.Relative));
        }
        private void addBirdr(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Uri("pages/addBird.xaml", UriKind.Relative));
        }
        private void searchBirdr(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Uri("pages/searchBird.xaml", UriKind.Relative));
        }
        private void searchCager(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Uri("pages/searchCage.xaml", UriKind.Relative));
        }
        private void Logoutr(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/pages/Page1.xaml", UriKind.Relative));
        }
    }
}
