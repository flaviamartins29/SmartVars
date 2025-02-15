using FluentValidation;
using SmartVars.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Application.Validation
{
    public class BuildingVarsValidateError : AbstractValidator<BuildingVarsModel>
    {
        public BuildingVarsValidateError()
        {
            RuleFor(x => x.MyInt)
             .Must(x => x is int || x == null)
             .WithMessage("The field must contain exactly one character as an integer, try again.");

            RuleFor(x => x.MyString)
            .Must(x => x  is string || x == null)
            .WithMessage("The field must contain exactly one character as a string, try again.");

            RuleFor(x => x.ThisMy)
             .Must(x => x is bool || x == null)
             .WithMessage("The field must contain exactly one character as a bolean, try again.");

            RuleFor(x => x.MyDouble)
              .Must(x => x is double || x == null)
              .WithMessage("The field must contain exactly one character as a double, try again.");

            RuleFor(x => x.MyDecimal)
              .Must(x => x is decimal || x == null)
              .WithMessage("The field must contain exactly one character as a decimal, try again.");

        }

    }
}
