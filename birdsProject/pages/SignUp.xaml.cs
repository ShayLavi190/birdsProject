
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using SpreadsheetLight;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using System.Linq;

namespace birdsProject.pages

{
    public partial class SignUp : System.Windows.Controls.Page
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
               
            }
        }

        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/pages/Page1.xaml", UriKind.Relative));
        }
        private void signUpRequest(object sender, RoutedEventArgs e)
        {
            string Id = id.Text;
            string Username = username.Text;
            string Password = password.Password;
            if ((Id.Length == 9) && (Username.Length >= 6) && (Username.Length <= 8) && (Password.Length <= 10) && (Password.Length >=8))
            {
                int countLettersu = 0; int countdigitsu = 0;
                for (int i=0; i<Username.Length;i++)
                {
                    string temp = "" + Username[i];
                    if (int.TryParse(temp, out int numericValue))
                    {
                        countdigitsu++;
                    }
                    if ((Username[i] >= 'a' && Username[i] <= 'z') || (Username[i] >= 'A' && Username[i] <= 'Z'))
                    {
                        countLettersu++;
                    }
                }
                int countLettersp = 0; int countdigitsp = 0;
                for (int i = 0; i < Password.Length; i++)
                {
                    string temp = "" + Password[i];
                    if (int.TryParse(temp, out int numericValue))
                    {
                        countdigitsp++;
                    }
                    if ((Password[i] >= 'a' && Password[i] <= 'z') || (Password[i] >= 'A' && Password[i] <= 'Z'))
                    {
                        countLettersp++;
                    }
                }

                if (((countLettersu+countdigitsu==Username.Length)&&(countdigitsu<=2))&&((Password.Length-(countLettersp+countdigitsp)!=0)&&(countdigitsp>=1)&&(countLettersp>=1)))
                {
                    SLDocument doc = new SLDocument(@"C:\Users\Shay\Desktop\birdsProject\birdsProject\Users.xlsx");
                    doc.SelectWorksheet("users");
                    int counter = 2;int flag = 0;
                    string cell = doc.GetCellValueAsString("B2");
                    while (cell!="")
                    {
                        if (cell == Id)
                        {
                            flag++;
                            MessageBox.Show("An error occurred: your Id is been used before, please contact to the admin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                        counter++;
                        cell = doc.GetCellValueAsString("B" + counter);
                    }
                    if (flag == 0)
                    {
                        doc.SetCellValue("A" + counter, Username);
                        doc.SetCellValue("B" + counter, Id);
                        doc.SetCellValue("C" + counter, Password);
                    }
                    doc.Save();
                }
                else
                {
                    MessageBox.Show("An error occurred: your sign in parameters are not valid. please try again and read the instractions in the left", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("An error occurred: your sign in parameters are not valid. please try again and read the instractions in the left", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
