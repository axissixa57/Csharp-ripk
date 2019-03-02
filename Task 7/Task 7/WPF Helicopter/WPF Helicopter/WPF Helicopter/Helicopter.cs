using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Helicopter
{
    public class Helicopter
    {
        private int length;
        private int height;

        public string Model { get; set; }
        public int Length
        {
            get { return length; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception($"Длина должна быть больше 0");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                length = value;
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception($"Высота должна быть больше 0");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                height = value;
            }
        }
        public int CarryingCapacity { get; set; }
        public int EnginePower { get; set; }

        //public string this[string columnName] // IDataErrorInfo
        //{
        //    get
        //    {
        //        string error = String.Empty;
        //        switch (columnName)
        //        {
        //            case "Model":
        //                if (string.IsNullOrEmpty(model))
        //                {
        //                    error = "Can't be empty";
        //                }
        //                break;
        //            case "Length":
        //                if ((length < 1) || (length > 30))
        //                {
        //                    error = "0 < Length < 30!";
        //                }
        //                break;
        //            case "Height":
        //                if (height < 1)
        //                {
        //                    error = "Height must be > 0";
        //                }
        //                break;
        //            case "Weight":
        //                if (weight < 1)
        //                {
        //                    error = "Weight should be > 0";
        //                }
        //                break;
        //            case "EnginePower":
        //                if (enginePower < 1)
        //                {
        //                    error = "EnginePower should be > 0";
        //                }
        //                break;
        //        }

        //        return error;
        //    }
        //}

        //public string Error { get => String.Empty; } // IDataErrorInfo
    }

   
}
