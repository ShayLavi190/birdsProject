using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using MaterialDesignThemes.Wpf;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for cageTable.xaml
    /// </summary>
    public class MyRow
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
    }
    public partial class cageTable : Page
    {
        public Cell[] matchingCages;
        public cageTable(Cell[] mc)
        {
            InitializeComponent();
            matchingCages = mc;
            List<MyRow> rows = new List<MyRow>();
            for (int i = 0; i < matchingCages.Length; i++)
            {
                rows.Add(new MyRow { Property1 = matchingCages[i].id, Property2 = matchingCages[i].Length, Property3 = matchingCages[i].Hight, Property4 = matchingCages[i].Width, Property5 = matchingCages[i].Matirial});
                myGrid.ItemsSource = rows;
            }
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Page1.xaml", UriKind.Relative));
        }
        private void More(object sender, SelectionChangedEventArgs e)
        {
            int rowIndex = myGrid.SelectedIndex;
            CellB[] matchingBirds = new CellB[0];
            SLDocument doc = new SLDocument(@"C:\Users\Shay\Desktop\birdsProject\birdsProject\Data.xlsx");
            doc.SelectWorksheet("Birds");
            string cell = doc.GetCellValueAsString("F2");
            int counter = 2;    
            while (cell != "")
            {
                if(cell == matchingCages[rowIndex].id)
                {
                    string idExcel = doc.GetCellValueAsString("A" + (counter));
                    string BirdTypeExcel = doc.GetCellValueAsString("B" + (counter));
                    string SubspecieExcel = doc.GetCellValueAsString("C" + (counter));
                    string BirthDateExcel = doc.GetCellValueAsString("D" + (counter));
                    string sexTypeExcel = doc.GetCellValueAsString("E" + (counter));
                    string cageIdExcel = doc.GetCellValueAsString("F" + (counter));
                    string fatherIdExcel = doc.GetCellValueAsString("G" + (counter));
                    string motherIdExcel = doc.GetCellValueAsString("H" + (counter));
                    CellB[] temp = new CellB[matchingBirds.Length + 1];
                    for (int i = 0; i < matchingBirds.Length; i++)
                    {
                        temp[i] = matchingBirds[i];
                    }
                    CellB newCell = new CellB(idExcel, BirdTypeExcel, SubspecieExcel, BirthDateExcel, sexTypeExcel, cageIdExcel, fatherIdExcel, motherIdExcel);
                    temp[matchingBirds.Length]=newCell;
                    matchingBirds = new CellB[matchingBirds.Length + 1];
                    matchingBirds = temp;
                    counter++;
                    cell = doc.GetCellValueAsString("F"+counter);
                }
                else
                {
                    counter++;
                    cell = doc.GetCellValueAsString("F" + counter);
                }
            }
            Array.Sort(matchingBirds, new CellBIdComparer());
            CageInfo page1 = new CageInfo(matchingCages[rowIndex],matchingBirds);
            _NavigationFrame.Navigate(page1);
        }
    }
}
