using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfLabBat.Model;

namespace WpfLabBat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string SelectedLegko = "";
        public List<Legko> LegkoList { get; set; }

        private IEnumerable<Car> _CarList = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<Car> CarList
        {
            get
            {
                return _CarList
                    .Where(c => (SelectedLegko == "Все виды" || c.Legko == SelectedLegko));
            }
            set
            {
                _CarList = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Globals.dataProvider = new LocalDataProvider();
            CarList = Globals.dataProvider.GetCars();
            LegkoList = Globals.dataProvider.GetLegkos().ToList();
            LegkoList.Insert(0, new Legko { Title = "Все виды" });
            
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
           

        }
        private void Invalidate()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("CarList"));
        }

        private void LegkoFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedLegko = (LegkoFilterComboBox.SelectedItem as Legko).Title;
            Invalidate();
        }
    }
}
