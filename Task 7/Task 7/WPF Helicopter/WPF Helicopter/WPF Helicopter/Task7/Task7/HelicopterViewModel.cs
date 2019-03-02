using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task7
{
    public class HelicopterViewModel : INotifyPropertyChanged
    {
        //private ICollection<Helicopter> helicopters;
        //public ICollection<Helicopter> Helicopters
        //{
        //    get => helicopters;
        //    set
        //    {
        //        helicopters = value;
        //        OnPropertyChanged("Heroes");
        //    }
        //}

        private ObservableCollection<Helicopter> helicopters;
        // при любом изменении ObservableCollection может уведомлять элементы, которые применяют привязку, 
        // в результате чего обновляется не только сам объект ObservableCollection, но и привязанные к нему элементы интерфейса.
        // ObservableCollection позволит добавить например новую запись в ListBox; List не сможет этого сделать
        public ObservableCollection<Helicopter> Helicopters
        {
            get => helicopters;
            set
            {
                helicopters = value;
                OnPropertyChanged("Heroes");
            }
        }

        private Helicopter helicopter;

        public Helicopter ModelHelicopter
        {
            get => helicopter;
            set
            {
                helicopter = value;
                OnPropertyChanged("ModelHelicopter");
            }
        }

        private DoCommand addHelicopterCommand;
        //public DoCommand AddHelicopterCommand
        //{
        //    get
        //    {
        //        return addHelicopterCommand ??
        //        (addHelicopterCommand = new DoCommand((obj) =>
        //        {
        //            HeroWindow heroWindow = new HeroWindow(new Hero());
        //            if (heroWindow.ShowDialog() == true)
        //            {
        //                Hero h = heroWindow.Hero;
        //                Heroes.Add(h);
        //            }
        //        }));
        //    }
        //}

        public HelicopterViewModel()
        {
            LoadHelicoptersToListbox();
        }

        private void LoadHelicoptersToListbox()
        {
            helicopters = new ObservableCollection<Helicopter>
            {
                new Helicopter(){ Model = "Apache", Length = 10, Height = 7, Weight = 7000, EnginePower = 1400 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DoCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged // Событие CanExecuteChanged вызывается при изменении условий, указывающий, может ли команда выполняться. Для этого используется событие CommandManager.RequerySuggested.
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DoCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
