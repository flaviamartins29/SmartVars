using SmartVars.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Domain.Entities
{
    public class BuildingVars
    {
        public int Id { get; set; }
        public int? MyInt { get; set; }
        public string? MyString { get; set; }
        public bool? ThisMy { get; set; }
        public decimal? MyDecimal { get; set; }
        public double? MyDouble { get; set; }
        public DateTime? MyDateTime { get; set; }


        public BuildingVars(int id, int myInt, string myString, bool thisMy, decimal myDecimal, double myDouble, DateTime myDateTime )
        {
            Validation(id, myInt, myString, thisMy, myDecimal, myDouble, myDateTime);
        }  
        
        private void Validation(int id, int myInt, string myString, bool? thisMy, decimal? myDecimal, double? myDouble, DateTime? myDateTime)
        {
            BuildingVarsValidationException.WhenError(id < 0, "This id is not allowed to edit ou removed");
            BuildingVarsValidationException.WhenError(myInt < 0, "Your myInt is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(string.IsNullOrEmpty(myString), "Your string is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(!thisMy.HasValue, "Your bool is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(!myDecimal.HasValue, "Your myDecimal is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(!myDouble.HasValue, "Your myDouble is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(!myDateTime.HasValue, "Your myDouble is empty. Please type something to be recorded");

            MyInt = myInt;
            MyString = myString;
            MyDecimal = myDecimal.Value;
            MyDouble = myDouble.Value;
            ThisMy = thisMy.Value;
            MyDateTime = myDateTime.Value;
        }
    }
}
