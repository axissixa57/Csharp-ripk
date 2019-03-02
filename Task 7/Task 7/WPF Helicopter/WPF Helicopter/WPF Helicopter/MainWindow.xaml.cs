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
    public partial class MainWindow : Window
    {
        public ObservableCollection<Helicopter> Helicopters { get; set; } // замена List<Helicopter>

        public MainWindow()
        {
            InitializeComponent();

            Helicopters = new ObservableCollection<Helicopter>
            {
                new Helicopter { Model = "Apache", Length = 10, Height = 7, CarryingCapacity = 5, EnginePower = 1400 },
                new Helicopter { Model = "МИ-6", Length = 33, Height = 8, CarryingCapacity = 10, EnginePower = 8000 },
            };

            helicoptersList.ItemsSource = Helicopters;
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            Helicopter helicopter = new Helicopter();
            
            //while(true)
            //{
                if (string.IsNullOrEmpty(ModelTextBox.Text))
                {
                    MessageBox.Show("Model can't be empty");
                }
                else
                {
                    helicopter.Model = ModelTextBox.Text;
                }

                if (LengthTextBox.Text != String.Empty)
                {
                    if (int.Parse(LengthTextBox.Text) < 0 && int.Parse(LengthTextBox.Text) > 50)
                        MessageBox.Show("Length can't be less than 0 and more than 50");
                    else
                        helicopter.Length = int.Parse(LengthTextBox.Text);
                }
                
                if (EnginePowerTextBox.Text != String.Empty)
                {
                    if (int.Parse(HeightTextBox.Text) < 0 && int.Parse(HeightTextBox.Text) > 20)
                        MessageBox.Show("Height can't be less than 0 and more than 20");
                    else
                        if (EnginePowerTextBox.Text != String.Empty)
                        helicopter.Height = int.Parse(HeightTextBox.Text);
                }
                    

            if (EnginePowerTextBox.Text != String.Empty)
                if (int.Parse(CarryingСapacityTextBox.Text) < 0 && int.Parse(CarryingСapacityTextBox.Text) > 30)
                {
                    //if (EnginePowerTextBox.Text != String.Empty)
                        MessageBox.Show("Carrying capacity can't be less than 0 and more than 30");
                }
                else
                {
                    if (EnginePowerTextBox.Text != String.Empty)
                        helicopter.CarryingCapacity = int.Parse(HeightTextBox.Text);
                }

                if (int.Parse(EnginePowerTextBox.Text) < 0 && int.Parse(EnginePowerTextBox.Text) > 5000)
                {
                    //if (EnginePowerTextBox.Text != String.Empty)
                        MessageBox.Show("Engine power capacity can't be less than 0 and more than 5000");
                }
                else
                {
                    if (EnginePowerTextBox.Text != String.Empty)
                        helicopter.EnginePower = int.Parse(HeightTextBox.Text);
                }

                Helicopters.Add(helicopter);
          //  }
            

            //if (EnginePowerTextBox.Text != String.Empty)
            //    helicopter.EnginePower = int.Parse(EnginePowerTextBox.Text);

            
        }

        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {
            Helicopter helicopter = helicoptersList.SelectedItem as Helicopter;
            if (helicopter != null)
            {
                helicopter.Model = ModelTextBox.Text;
                if (LengthTextBox.Text != String.Empty)
                    helicopter.Length = int.Parse(LengthTextBox.Text);
                if (HeightTextBox.Text != String.Empty)
                    helicopter.Height = int.Parse(HeightTextBox.Text);
                if (CarryingСapacityTextBox.Text != String.Empty)
                    helicopter.CarryingCapacity = int.Parse(CarryingСapacityTextBox.Text);
                if (EnginePowerTextBox.Text != String.Empty)
                    helicopter.EnginePower = int.Parse(EnginePowerTextBox.Text);
                helicoptersList.Items.Refresh();
            }
        }

        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            Helicopter helicopter = helicoptersList.SelectedItem as Helicopter;
            if(helicopter != null)
            {
                Helicopters.Remove(helicopter);
                helicoptersList.SelectedItem = null;
            }
        }

        private void helicoptersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Helicopter helicopter = helicoptersList.SelectedItem as Helicopter;
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
