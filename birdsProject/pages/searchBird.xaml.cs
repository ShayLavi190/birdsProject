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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace birdsProject.pages
{
    /// <summary>
    /// Interaction logic for searchBird.xaml
    /// </summary> 
    public class CellB
    {
        public string id;
        public string BirdType;
        public string Subspecie;
        public string BirthDate;
        public string sexType;
        public string CageId;
        public string FatherId;
        public string MotherId;
        public CellB(string idt, string BirdTypet, string Subspeciet, string BirthDatet, string sexTypet, string CageIdt, string FatherIdt, string MotherIdt)
        {
            this.id = idt;
            this.BirdType = BirdTypet;
            this.Subspecie = Subspeciet;
            this.BirthDate = BirthDatet;
            this.sexType = sexTypet;
            this.CageId = CageIdt;
            this.FatherId = FatherIdt;
            this.MotherId = MotherIdt;
        }
    }
    class CellBIdComparer : IComparer<CellB>
    {
        public int Compare(CellB x, CellB y)
        {
            return x.id.CompareTo(y.id);
        }
    }

    public partial class searchBird : Page
    {
        public searchBird()
        {
            InitializeComponent();
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
        private void searchBirdr(object sender, RoutedEventArgs e)
        {
            string Id = id.Text;
            string[] birdtype = { "Blue", "Goldian", "Straberry", "Zebra", "Saffron" };
            int birdSpecieindex = birdSpecie.SelectedIndex;
            string BirdType = birdtype[birdSpecieindex];
            string Subspecie = subspecie.Text;
            string BirthDate = birthDate.Text;
            string[] sexTypeArr = { "Male", "Female" };
            int sexindex = sex.SelectedIndex;
            string sexType = sexTypeArr[sexindex];
            string CageId = cageId.Text;
            string FatherId = fatherId.Text;
            string MotherId = motherId.Text;
            int num;
            int index = 2;
            int flag = 0;
            if ((int.Parse(Id) > 0) && (int.Parse(FatherId) > 0) && (int.Parse(MotherId) > 0) && (Subspecie =="Pink") && (int.TryParse(Id, out num)) && (int.TryParse(FatherId, out num)) && (int.TryParse(MotherId, out num)))
            {
                    CellB[] matchingCells = new CellB[0];
                    SLDocument doc = new SLDocument(@"C:\Users\Shay\Desktop\birdsProject\birdsProject\Data.xlsx");
                    doc.SelectWorksheet("Birds");
                    string cell = doc.GetCellValueAsString("A2");
                    while (cell != "")
                    {
                        string idExcel = doc.GetCellValueAsString("A" + (index));
                        string BirdTypeExcel = doc.GetCellValueAsString("B" + (index));
                        string SubspecieExcel = doc.GetCellValueAsString("C" + (index));
                        string BirthDateExcel = doc.GetCellValueAsString("D" + (index));
                        string sexTypeExcel = doc.GetCellValueAsString("E" + (index));
                        string cageIdExcel = doc.GetCellValueAsString("F" + (index));
                        string fatherIdExcel = doc.GetCellValueAsString("G" + (index));
                        string motherIdExcel = doc.GetCellValueAsString("H" + (index));

                    if ((BirdType == BirdTypeExcel) || (Subspecie == SubspecieExcel) || (BirthDate == BirthDateExcel) || (Id == idExcel)||(sexType==sexTypeExcel)||(CageId==cageIdExcel)||(fatherIdExcel== FatherId)||(motherIdExcel==MotherId))
                        {
                            flag++;
                            CellB[] temp = new CellB[matchingCells.Length + 1];
                            for (int i = 0; i < matchingCells.Length; i++)
                            {
                                temp[i] = matchingCells[i];
                            }
                            CellB newCell = new CellB(idExcel, BirdTypeExcel, SubspecieExcel, BirthDateExcel, sexTypeExcel, cageIdExcel, fatherIdExcel, motherIdExcel);
                            matchingCells = new CellB[matchingCells.Length + 1];
                            for (int i = 0; i < matchingCells.Length; i++)
                            {
                                if (temp[i] != null)
                                {
                                    matchingCells[i] = temp[i];
                                }
                            }
                            matchingCells[temp.Length - 1] = newCell;
                        }
                        index++;
                        cell = doc.GetCellValueAsString("A" + index);
                    }
                    Array.Sort(matchingCells, new CellBIdComparer());
                    doc.Save();
                    if(flag>0)
                    {
                        BirdsTable page1 = new BirdsTable(matchingCells);
                        NavigationService.Navigate(page1);
                    }
                    else
                    {
                        MessageBox.Show("No bird was found", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
            }
            else
            {
                MessageBox.Show("An error occurred: The parameters are not valid. please try again and read the instractions in the left", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
