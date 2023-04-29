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
    /// Interaction logic for EditBaybe.xaml
    /// </summary>
    public partial class EditBaybe : Page
    {
        CellB bird;
        public EditBaybe(CellB b)
        {
            InitializeComponent();
            bird = b;
            id.Text = b.id;
            string[] birdSpeciesarray = { "Blue", "Goldian", "Straberry", "Zebra", "Saffron" };
            int index = 0;int index1 = 0;
            for (int i = 0; birdSpeciesarray.Length > i; i++)
            {
                if (birdSpeciesarray[i] == b.BirdType) { index = i; }
            }
            birdSpecie.SelectedIndex = index;
            subspecie.Text = b.Subspecie;
            birthDate.Text = b.BirthDate;
            if(b.sexType == "Male")
            {
                index = 0;
            }
            if (b.sexType == "Female")
            {
                index = 1;
            }
            sex.SelectedIndex = index;
            cageId.Text = b.CageId;
            fatherId.Text = b.FatherId;
            motherId.Text = b.MotherId;
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
        private void SaveBird(object sender, RoutedEventArgs e)
        {
            string[] sexarray = { "Male", "Female" };
            string[] birdSpeciesarray = { "Blue", "Goldian", "Straberry", "Zebra", "Saffron" };
            string Id = id.Text;
            int birdSpecieindex = birdSpecie.SelectedIndex;
            string birdSpeciec = birdSpeciesarray[birdSpecieindex];
            string subspeciec = subspecie.Text;
            string birthDatec = birthDate.Text;
            int sexIndex = sex.SelectedIndex;
            string sexc = sexarray[sexIndex];
            string cageIdc = cageId.Text;
            string fatherIdc = fatherId.Text;
            string motherIdc = motherId.Text;
            if ((Id.Length == 8) && (subspeciec == "pink") && (cageIdc.Length == 8) && (fatherIdc.Length == 8) && (motherIdc.Length == 8) && (cageIsFound(cageIdc, 'A')) && (IsFound(fatherIdc, 'A')) && (IsFound(motherIdc, 'A')) && (IsFound(Id, 'A')))
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
                    int flag2 = 0;  
                    while (cell != "")
                    {
                        if ((cell == bird.id) && (flag2==0))
                        {
                            doc.SetCellValue("A" + (index), Id);
                            doc.SetCellValue("B" + (index), birdSpeciec);
                            doc.SetCellValue("C" + (index), subspeciec);
                            doc.SetCellValue("D" + (index), birthDatec);
                            doc.SetCellValue("E" + (index), sexc);
                            doc.SetCellValue("F" + (index), cageIdc);
                            doc.SetCellValue("G" + (index), fatherIdc);
                            doc.SetCellValue("H" + (index), motherIdc);
                            index++;
                            flag2++;
                            cell = doc.GetCellValueAsString("A" + index);
                            MessageBox.Show("Bird saved", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else 
                        {
                            index++;
                            cell = doc.GetCellValueAsString("A" + index);
                        }
                    }
                    if (flag2 == 0)
                    {
                        MessageBox.Show("Bird not found in data, you can't change id of the bird", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
