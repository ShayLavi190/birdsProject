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
    /// Interaction logic for BirdsTable.xaml
    /// </summary>
    public class MyRowB
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
        public string Property6 { get; set; }
        public string Property7 { get; set; }
        public string Property8 { get; set; }

    }
    public partial class BirdsTable : Page
    {
        CellB[] matchingBirds;
        public BirdsTable(CellB[] mb)
        {
            InitializeComponent();
            matchingBirds = mb;
            List<MyRowB> rows = new List<MyRowB>();
            for (int i = 0; i < matchingBirds.Length; i++)
            {
                rows.Add(new MyRowB { Property1 = matchingBirds[i].id, Property2 = matchingBirds[i].BirdType, Property3 = matchingBirds[i].Subspecie, Property4 = matchingBirds[i].BirthDate, Property5 = matchingBirds[i].sexType, Property6 = matchingBirds[i].CageId, Property7 = matchingBirds[i].FatherId, Property8 = matchingBirds[i].MotherId });
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
            BirdInfo page1 = new BirdInfo(matchingBirds[rowIndex]);
            _NavigationFrame.Navigate(page1);
        }
    }
}