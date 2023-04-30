using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    /// Interaction logic for addCage.xaml
    /// </summary>
    public partial class addCage : Page
    {
        public addCage()
        {
            InitializeComponent();
        }
        private void addCageClick(object sender, RoutedEventArgs e)
        {
            string Id = id.Text;
            string Length = length.Text;
            string Hight = hight.Text;
            string Width = width.Text;
            string[] matirials= {"wood","steel","plastic"};
            int matirialindex = material.SelectedIndex;
            string Matirial;
            if (matirialindex == -1)
            {
                Matirial = "-1";

            }
            else
            {
                Matirial = matirials[matirialindex];

            }
            int num;
            int index = 2;
            if ((int.Parse(Id) > 0) && (int.Parse(Length) > 0 ) && (int.Parse(Hight) > 0) && (int.Parse(Width) > 0) && (!cageIsFound(Id,'A')) && (Matirial!="-1"))
            {
                if ((!(int.TryParse(Id, out num))) || (!(int.TryParse(Length, out num)))|| (!(int.TryParse(Hight, out num))) || (!(int.TryParse(Width, out num))))
                {
                    MessageBox.Show("An error occurred: The parameters are not valid. please try again and read the instractions in the left", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    SLDocument doc = new SLDocument(@"C:\Users\Shay\Desktop\birdsProject\birdsProject\Data.xlsx");
                    doc.SelectWorksheet("Cages");
                    string cell = doc.GetCellValueAsString("A2");
                    while (cell != "")
                    {
                        index++;
                        cell = doc.GetCellValueAsString("A" + index);
                    }
                    doc.SetCellValue("A" + (index), Id);
                    doc.SetCellValue("B" + (index), Length);
                    doc.SetCellValue("C" + (index), Hight);
                    doc.SetCellValue("D" + (index), Width);
                    doc.SetCellValue("F" + (index), Matirial);
                    doc.Save();
                    MessageBox.Show("Cage added", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("An error occurred: The parameters are not valid. please try again and read the instractions in the left", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("pages/Page1.xaml", UriKind.Relative));
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
        public bool cageIsFound(string id, char letter)
        {
            SLDocument doc = new SLDocument(@"C:\Users\Shay\Desktop\birdsProject\birdsProject\Data.xlsx");

            doc.SelectWorksheet("Cages");
            int counter = 2;
            int flag = 0;
            string cell = doc.GetCellValueAsString("" + letter + "" + counter);
            while (cell != "")
            {
                if ((id == cell))
                {
                    counter++;
                    return true;
                }
                else
                {
                    counter++;
                    cell = doc.GetCellValueAsString("" + letter + "" + counter);
                }
            }
            return false;
        }
    }

}
