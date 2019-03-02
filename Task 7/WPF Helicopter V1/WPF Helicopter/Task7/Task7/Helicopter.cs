using System;
using System.ComponentModel; // INotifyPropertyChanged, IDataErrorInfo

namespace Task7
{
    public class Helicopter : INotifyPropertyChanged, IDataErrorInfo
    {
        public static int Count { get; private set; }

        private string model;
        public string Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        private int length;
        public int Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged("Length");
            }
        }

        private int height;
        public int Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }

        private int weight;
        public int Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged("Weight");
            }
        }

        private int enginePower;
        public int EnginePower
        {
            get => enginePower;
            set
            {
                enginePower = value;
                OnPropertyChanged("EnginePower");
            }
        }

        public string this[string columnName] // IDataErrorInfo
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Model":
                        if (string.IsNullOrEmpty(model))
                        {
                            error = "Can't be empty";
                        }
                        break;
                    case "Length":
                        if ((length < 1) || (length > 30))
                        {
                            error = "0 < Length < 30!";
                        }
                        break;
                    case "Height":
                        if (height < 1)
                        {
                            error = "Height must be > 0";
                        }
                        break;
                    case "Weight":
                        if (weight < 1)
                        {
                            error = "Weight should be > 0";
                        }
                        break;
                    case "EnginePower":
                        if (enginePower < 1)
                        {
                            error = "EnginePower should be > 0";
                        }
                        break;
                }

                return error;
            }
        }
                                                                                                                
        public string Error { get => String.Empty; } // IDataErrorInfo

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) // Когда объект класса изменяет значение свойства, то он через событие PropertyChanged извещает систему об изменении свойства. А система обновляет все привязанные объекты.
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Helicopter(string model = "", int length = 0, int height = 0, int weight = 0, int enginePower = 0)
        {
            Model = model;
            Length = length;
            Height = height;
            Weight = weight;
            EnginePower = enginePower;
            Count++;
        }
    }
}
