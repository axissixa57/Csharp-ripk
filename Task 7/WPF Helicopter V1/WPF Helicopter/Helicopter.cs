using System;
using System.Collections.Generic;
using System.ComponentModel; // IDataErrorInfo
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Helicopter
{
    public class Helicopter : IDataErrorInfo
    {

        public string Model { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public int CarryingCapacity { get; set; }
        public int EnginePower { get; set; }

        public string this[string columnName] // IDataErrorInfo
        {
            get
            {
                string error = "123";
                switch (columnName)
                {
                    case "Model":
                        if (string.IsNullOrEmpty(Model))
                        {
                            error = "Can't be empty";
                            return error;
                        }
                        break;
                    case "Length":
                        if ((Length < 1) || (Length > 30))
                        {
                            error = "Length can't be less than 0 and more than 50!";
                            return error;
                        }
                        break;
                    case "Height":
                        if (Height < 1)
                        {
                            error = "Height can't be less than 0 and more than 20!";
                            return error;
                        }
                        break;
                    case "Weight":
                        if (CarryingCapacity < 1)
                        {
                            error = "Carrying capacity can't be less than 0 and more than 30!";
                            return error;
                        }
                        break;
                    case "EnginePower":
                        if (EnginePower < 1)
                        {
                            error = "Engine power capacity can't be less than 0 and more than 5000!";
                            return error;
                        }
                        break;
                }

                return error;
            }
        }

        public string Error { get => String.Empty; } // IDataErrorInfo
    }

   
}
