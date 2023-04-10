//Theme Code ==================>>
using birdsProject;
using birdsProject.pages;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using MaterialDesignThemes.Wpf;
using SpreadsheetLight;
//=============================>>
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


namespace WPF_login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Theme Code ========================>
        public bool IsDarkTheme { get; set; }
        public object NavigationService { get; private set; }

        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        //===================================>

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            //Theme Code ========================>
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            paletteHelper.SetTheme(theme);
            //===================================>
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
            string Password = txtPassword.Password;
            string Username = txtUsername.Text;
            SLDocument doc = new SLDocument(@"C:\Users\Shay\Desktop\birdsProject\birdsProject\Users.xlsx");
            doc.SelectWorksheet("users");
            string username = doc.GetCellValueAsString("A2");
            string password = doc.GetCellValueAsString("C2");
            int flag = 0; int counter = 0;
            while(username != "")
            {
                if ((Password == password) && (Username==username))
                {
                    flag++;
                    username = doc.GetCellValueAsString("A" + counter);
                    password = doc.GetCellValueAsString("B" + counter);
                    counter++;
                }
                else
                {
                    username = doc.GetCellValueAsString("A"+ counter);
                    password = doc.GetCellValueAsString("B" + counter);
                    counter++;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("No account was found in the system, please sign up or contact the admin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _NavigationFrame.Navigate(new Uri("/pages/Homepage.xaml", UriKind.Relative));
            }

        }
    }
}
