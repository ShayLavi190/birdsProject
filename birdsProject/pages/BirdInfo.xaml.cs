using DocumentFormat.OpenXml.Office2010.CustomUI;
using DocumentFormat.OpenXml.Spreadsheet;
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

namespace birdsProject.pages
{
    /// <summary>
    /// Interaction logic for BirdInfo.xaml
    /// </summary>
    public partial class BirdInfo : System.Windows.Controls.Page
    {
        CellB birdC;
        public BirdInfo(CellB bird)
        {
            InitializeComponent();
            List<MyRowB> row = new List<MyRowB>();
            birdC = bird;
            row.Add(new MyRowB { Property1 = bird.id, Property2 = bird.BirdType, Property3 = bird.Subspecie, Property4 = bird.BirthDate, Property5 = bird.sexType, Property6 = bird.CageId, Property7 = bird.FatherId, Property8 = bird.MotherId });
            myGrid.ItemsSource = row;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("/pages/Birds/" + bird.BirdType+".jpg", UriKind.RelativeOrAbsolute);
            image.EndInit();
            BirdImage.Source = image;
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Page1.xaml", UriKind.Relative));
        }

        private void Addbaby(object sender, RoutedEventArgs e)
        {
            string[] birdSpeciesarray = { "Blue", "Goldian", "Straberry", "Zebra", "Saffron" };
            int index =0;
            for (int i = 0;birdSpeciesarray.Length > i; i++)
            {
                if (birdSpeciesarray[i] == birdC.BirdType) { index = i; }
            }
            AddBaybe page1 = new AddBaybe(birdC.id,birdC.sexType,birdC.CageId,birdC.Subspecie, index);
            _NavigationFrame.Navigate(page1);
        }

        private void editBird(object sender, SelectionChangedEventArgs e)
        {
            EditBaybe page1 = new EditBaybe(birdC);
            _NavigationFrame.Navigate(page1);
        }
    }
}
