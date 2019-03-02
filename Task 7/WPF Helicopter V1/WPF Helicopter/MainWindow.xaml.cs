using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_Helicopter 
{
    /// Interaction logic for MainWindow.xaml
    /// Второй созданный по умолчанию и обязательный для WPF приложения класс - класс Window, который представляет собой 
    /// окно (разработка настольного приложения с графическим интерфейсом - это, по сути, разработка окна).
    /// Поскольку вам нужен интерфейс, то вы создаёте (или Visual Studio за вас) свой класс окна, по умолчанию MainWindow, производный от библиотечного класса окна Window.
    /// Он тоже partial, и описан в двух файлах: код на C# в файле MainWindow.xaml.cs и разметка XAML в файле MainWindow.xaml.
    public partial class MainWindow : Window
    {
        // замена List<Helicopter>. Его преимущество заключается в том, что при любом изменении ObservableCollection может уведомлять элементы, 
        // которые применяют привязку, в результате чего обновляется не только сам объект ObservableCollection, но и привязанные к нему элементы интерфейса.
        // List не сможет добавить новый объект Helicopter с отображением в xaml окне. Helicopters.Add(helicopters); - только через ObservableCollection сможет
        public ObservableCollection<Helicopter> Helicopters { get; set; } 

        public MainWindow()
        {
            Helicopter hel = new Helicopter();
            this.DataContext = hel;

            InitializeComponent(); 

            Helicopters = new ObservableCollection<Helicopter>
            {
                new Helicopter { Model = "Apache", Length = 10, Height = 7, CarryingCapacity = 5, EnginePower = 1400 },
                new Helicopter { Model = "МИ-6", Length = 33, Height = 8, CarryingCapacity = 10, EnginePower = 8000 },
            };

            helicoptersList.ItemsSource = Helicopters; // С помощью атрибута ItemsSource задаем привязку к свойству Helicopters
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            Helicopter helicopter = new Helicopter();

            if (helicopter != null)
            {
                if (string.IsNullOrEmpty(ModelTextBox.Text))
                {
                    MessageBox.Show("Model can't be empty");
                    return;
                }
                else
                    helicopter.Model = ModelTextBox.Text;

                if (string.IsNullOrEmpty(LengthTextBox.Text))
                {
                    MessageBox.Show("Length can't be empty");
                    return;
                }
                else if (Convert.ToInt32(LengthTextBox.Text) < 1 || Convert.ToInt32(LengthTextBox.Text) > 50)
                {
                    MessageBox.Show("Length can't be less than 0 and more than 50");
                    return;
                }
                else
                    helicopter.Length = int.Parse(LengthTextBox.Text);

                if (string.IsNullOrEmpty(HeightTextBox.Text))
                {
                    MessageBox.Show("Height can't be empty");
                    return;
                }
                else if (int.Parse(HeightTextBox.Text) < 1 || int.Parse(HeightTextBox.Text) > 20)
                {
                    MessageBox.Show("Height can't be less than 0 and more than 20");
                    return;
                }
                else
                    helicopter.Height = int.Parse(HeightTextBox.Text);

                if (string.IsNullOrEmpty(CarryingСapacityTextBox.Text))
                {
                    MessageBox.Show("Carrying capacity can't be empty");
                    return;
                }
                else if (int.Parse(CarryingСapacityTextBox.Text) < 1 || int.Parse(CarryingСapacityTextBox.Text) > 30)
                {
                    MessageBox.Show("Carrying capacity can't be less than 0 and more than 30");
                    return;
                }
                else
                    helicopter.CarryingCapacity = int.Parse(CarryingСapacityTextBox.Text);

                if (string.IsNullOrEmpty(EnginePowerTextBox.Text))
                {
                    MessageBox.Show("Engine power can't be empty");
                    return;
                }
                else if (int.Parse(EnginePowerTextBox.Text) < 1 || int.Parse(EnginePowerTextBox.Text) > 5000)
                {
                    MessageBox.Show("Engine power capacity can't be less than 0 and more than 10000");
                    return;
                }
                else
                    helicopter.EnginePower = int.Parse(EnginePowerTextBox.Text);

                Helicopters.Add(helicopter);
            }
        }

        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {
            Helicopter helicopter = (Helicopter)helicoptersList.SelectedItem; //Helicopter helicopter = helicoptersList.SelectedItem as Helicopter;

            if (helicopter != null)
            {
                if (string.IsNullOrEmpty(ModelTextBox.Text))
                {
                    MessageBox.Show("Model can't be empty");
                    return;
                }
                else
                    helicopter.Model = ModelTextBox.Text;

                if (string.IsNullOrEmpty(LengthTextBox.Text))
                {
                    MessageBox.Show("Length can't be empty");
                    return;
                }
                else if (Convert.ToInt32(LengthTextBox.Text) < 0 || Convert.ToInt32(LengthTextBox.Text) > 50)
                {
                    MessageBox.Show("Length can't be less than 0 and more than 50");
                    return;
                }
                else
                    helicopter.Length = int.Parse(LengthTextBox.Text);

                if (string.IsNullOrEmpty(HeightTextBox.Text))
                {
                    MessageBox.Show("Height can't be empty");
                    return;
                }
                else if (int.Parse(HeightTextBox.Text) < 0 || int.Parse(HeightTextBox.Text) > 20)
                {
                    MessageBox.Show("Height can't be less than 0 and more than 20");
                    return;
                }
                else
                    helicopter.Height = int.Parse(HeightTextBox.Text);

                if (string.IsNullOrEmpty(CarryingСapacityTextBox.Text))
                {
                    MessageBox.Show("Carrying capacity can't be empty");
                    return;
                }
                else if (int.Parse(CarryingСapacityTextBox.Text) < 0 || int.Parse(CarryingСapacityTextBox.Text) > 30)
                {
                    MessageBox.Show("Carrying capacity can't be less than 0 and more than 30");
                    return;
                }
                else
                    helicopter.CarryingCapacity = int.Parse(CarryingСapacityTextBox.Text);

                if (string.IsNullOrEmpty(EnginePowerTextBox.Text))
                {
                    MessageBox.Show("Engine power can't be empty");
                    return;
                }
                else if (int.Parse(EnginePowerTextBox.Text) < 0 || int.Parse(EnginePowerTextBox.Text) > 10000)
                {
                    MessageBox.Show("Engine power can't be less than 0 and more than 10000");
                    return;
                }
                else
                    helicopter.EnginePower = int.Parse(EnginePowerTextBox.Text);

                helicoptersList.Items.Refresh();
            }
        }

        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            Helicopter helicopter = (Helicopter)helicoptersList.SelectedItem; //Helicopter helicopter = helicoptersList.SelectedItem as Helicopter;
            if (helicopter != null)
            {
                Helicopters.Remove(helicopter);
                helicoptersList.SelectedItem = null;
            }
        }

        private void helicoptersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Helicopter helicopter = (Helicopter)helicoptersList.SelectedItem; //Helicopter helicopter = helicoptersList.SelectedItem as Helicopter;
            if (helicopter != null)
            {
                ModelTextBox.Text = helicopter.Model;
                LengthTextBox.Text = helicopter.Length.ToString();
                HeightTextBox.Text = helicopter.Height.ToString();
                CarryingСapacityTextBox.Text = helicopter.CarryingCapacity.ToString();
                EnginePowerTextBox.Text = helicopter.EnginePower.ToString();
            }
        }
    }
}
