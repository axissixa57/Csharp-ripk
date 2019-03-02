using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Helicopter
{
    /// Interaction logic for App.xaml
    /// Каркасом любого WPF приложения должен быть класс, производный от класса Application.
    /// Это как функция Main в консольных приложениях. Это то, что создаётся при запуске программы. 
    /// Он может быть пустым, этого всё равно будет достаточно. 
    /// Система сама сделает всё необходимое на основании методов, полученных от базового класса.
    /// partial обозначает, что определение этого класса разбито на несколько файлов.
    /// Т.е. в этом файле лишь часть описания класса App.
    /// вторая часть в app.XAML файле
    public partial class App : Application
    {
    }
}
