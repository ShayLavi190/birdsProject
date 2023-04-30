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
    /// Interaction logic for AddBaybe.xaml
    /// </summary>
    public partial class AddBaybe : Page
    {
        public AddBaybe(string id, string sext, string cid,string subs , int birdspecieindex)
        {
            InitializeComponent();
            if (sext == "Male")
            {
                fatherId.Text = id;
            }
            else
            {
                motherId.Text = id;
            }
            cageId.Text= cid;
            subspecie.Text= subs;
            birdSpecie.SelectedIndex= birdspecieindex;
        }
        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Page1.xaml", UriKind.Relative));
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {

            }
        }
        private void AddBaby(object sender, RoutedEventArgs e)
        {
            string[] sexarray = { "Male", "Female" };
            string[] birdSpeciesarray = { "Blue", "Goldian", "Straberry", "Zebra", "Saffron" };
            string Id = id.Text;
            int birdSpecieindex = birdSpecie.SelectedIndex;
            string birdSpeciec;
            if (-1 == birdSpecieindex)
            {
                birdSpeciec = "-1";
            }
            else
            {
                birdSpeciec = birdSpeciesarray[birdSpecieindex];

            }
            string subspeciec = subspecie.Text;
            string birthDatec = birthDate.Text;
            int sexIndex = sex.SelectedIndex;
            string sexc;
            if (-1 == sexIndex)
            {
                sexc = "-1";
            }
            else
            {
                sexc = sexarray[sexIndex];

            }
            string cageIdc = cageId.Text;
            string fatherIdc = fatherId.Text;
            string motherIdc = motherId.Text;
            if ((Id.Length == 8) && (subspeciec == "pink") && (cageIdc.Length == 8) && (fatherIdc.Length == 8) && (motherIdc.Length == 8) && (cageIsFound(cageIdc, 'A')) && (IsFound(fatherIdc, 'A')) && (IsFound(motherIdc, 'A')) && (!IsFound(Id, 'A')) && (sexc != "-1") && (birdSpeciec != "-1"))
            {
                SLDocument doc = new SLDocument(@"C:\Users\Shay\Desktop\birdsProject\birdsProject\Data.xlsx");
                doc.SelectWorksheet("Birds");
                string cell = doc.GetCellValueAsString("A2");
                int flag = 0;
                int index = 2;
                int num;
                if (!(int.TryParse(Id, out num)))
                {
                    flag = 1;
                }
                string[] arr = birthDatec.Split('/');
                for (int i = 0; i < arr.Length; i++)
                {
                    int numt;
                    bool isNumeric = int.TryParse(arr[i], out numt);
                    if (!isNumeric)
                    {
                        flag = 1;
                    }
                }
                if (flag == 1) { MessageBox.Show("An error occurred: The parameters are not valid. please try again and read the instractions in the left", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
                else
                {
                    while (cell != "")
                    {
                        index++;
                        cell = doc.GetCellValueAsString("A" + index);
                    }
                    doc.SetCellValue("A" + (index), Id);
                    doc.SetCellValue("B" + (index), birdSpeciec);
                    doc.SetCellValue("C" + (index), subspeciec);
                    doc.SetCellValue("D" + (index), birthDatec);
                    doc.SetCellValue("E" + (index), sexc);
                    doc.SetCellValue("F" + (index), cageIdc);
                    doc.SetCellValue("G" + (index), fatherIdc);
                    doc.SetCellValue("H" + (index), motherIdc);
                    doc.Save();
                    MessageBox.Show("Bird added", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("An error occurred: The parameters are not valid. please try again and read the instractions in the left", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool IsFound(string id, char letter)
        {
            SLDocument doc = new SLDocument(@"C:\Users\Shay\Desktop\birdsProject\birdsProject\Data.xlsx");
            doc.SelectWorksheet("Birds");
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
