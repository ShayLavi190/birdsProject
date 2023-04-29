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
    /// Interaction logic for CageInfo.xaml
    /// </summary>
    public partial class CageInfo : Page
    {
        Cell cureentCage;
        CellB[] birds;
        public CageInfo(Cell cage, CellB[] mb)
        {
            InitializeComponent();
            birds = mb;
            cureentCage = cage;
            List<MyRow> row = new List<MyRow>();
            row.Add(new MyRow { Property1 = cage.id, Property2 = cage.Length, Property3 = cage.Hight, Property4 = cage.Width, Property5 = cage.Matirial});
            myGrid.ItemsSource = row;
            List<MyRowB> rowB = new List<MyRowB>();
            for(int i = 0; i < birds.Length; i++) 
            {
                rowB.Add(new MyRowB { Property1 = birds[i].id, Property2 = birds[i].BirdType, Property3 = birds[i].Subspecie, Property4 = birds[i].BirthDate, Property5 = birds[i].sexType, Property6 = birds[i].CageId, Property7 = birds[i].FatherId, Property8 = birds[i].MotherId });
            }
            BirdsGrid.ItemsSource = rowB;
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Page1.xaml", UriKind.Relative));
        }
        private void EditCage(object sender, SelectionChangedEventArgs e)
        {
            EditCage page1 = new EditCage(cureentCage);
            _NavigationFrame.Navigate(page1);
        }

    }
}
