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

        public BuildingVars() { }

        public BuildingVars(int? myInt, string? myString, bool thisMy, decimal myDecimal, double myDouble, DateTime myDateTime )
        {
            Validation(myInt, myString, thisMy, myDecimal, myDouble, myDateTime);
        }  
        
        private void Validation(int? myInt, string? myString, bool? thisMy, decimal? myDecimal, double? myDouble, DateTime? myDateTime)
        {
            BuildingVarsValidationException.WhenError(myInt is not int, "Your myInt is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(myString is not string, "Your string is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(thisMy is not bool, "Your bool is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(myDecimal is not decimal, "Your Decimal is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(myDouble is not double, "Your Double is empty. Please type something to be recorded");
            BuildingVarsValidationException.WhenError(myDateTime is not DateTime, "Your Double is empty. Please type something to be recorded");

            MyInt = myInt;
            MyString = myString;
            MyDecimal = myDecimal.Value;
            MyDouble = myDouble.Value;
            ThisMy = thisMy.Value;
            MyDateTime = myDateTime.Value;
        }
    }
}
