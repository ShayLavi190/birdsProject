using MaterialDesignThemes.Wpf;
using SpreadsheetLight;
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

namespace birdsProject.pages
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
        }
        public bool IsDarkTheme { get; set; }
        public object NavigationService { get; private set; }

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
            _NavigationFrame.Navigate(new Uri("/pages/SignUp.xaml", UriKind.Relative));
        }
        private void logInRequest(object sender, RoutedEventArgs e)
        {


        }
    }
}
