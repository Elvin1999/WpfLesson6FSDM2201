using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public Car MyCar { get; set; }

        public ObservableCollection<Car> Cars { get; set; }

        private string someText;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string SomeText
        {
            get { return someText; }
            set
            {
                someText = value; OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            SomeText = "Salam";
            this.DataContext = this;
            MyCar = new Car
            {
                Model = "X7",
                Vendor = "BMW",
                Year = 2021
            };

            Cars = new ObservableCollection<Car>
            {
                new Car
                {
                    Model="Cruze",
                    Vendor="Chevrolet",
                    Year=2015
                },
                new Car
                {
                    Model="CLS",
                    Vendor="Mercedes",
                    Year=2015
                },
                new Car
                {
                    Model="Quadraporte",
                    Vendor="Maseratti",
                    Year=2015
                }
            };

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyCar.Model = "Best Model";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var linear = new LinearGradientBrush();
            linear.GradientStops.Add(new GradientStop
            {
                Color = Colors.Red,
                Offset = 0
            });
            linear.GradientStops.Add(new GradientStop
            {
                Color = Colors.Black,
                Offset = 1
            });
            this.Resources["PrimaryColor"] = linear;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                Model = "La ferrari",
                Vendor = "Ferrari",
                Year = 2020
            };
            Cars.Add(car);
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var infoWindow = new InfoWindow();
            //infoWindow.InfoCar = listbox.SelectedItem as Car;
            infoWindow.Car = listbox.SelectedItem as Car;
            infoWindow.ShowDialog();
        }
    }
}
