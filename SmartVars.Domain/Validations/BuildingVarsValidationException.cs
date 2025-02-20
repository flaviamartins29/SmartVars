using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Domain.Validations
{
    public class BuildingVarsValidationException : Exception
    {
        public BuildingVarsValidationException(string error) : base(error)
        { }

        public static void WhenError(bool hasError, string mesageError)
        {
            if (hasError) 
                throw new BuildingVarsValidationException(mesageError);
            
        }

    }
}
