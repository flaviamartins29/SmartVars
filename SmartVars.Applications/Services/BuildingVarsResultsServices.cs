using SmartVars.Application.Notification;
using SmartVars.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Application.Services
{
    public class BuildingVarsResultsServices
    {
        public bool IsSucsess { get; set; }
        public string Message { get; set; }
        public ICollection<BuildingVarsResultNotifcation> Errors { get; set; }

        public BuildingVarsResultsServices() 
        {
        }

    }


    public class BuildingVarsResultsServices<T> : BuildingVarsResultsServices
    {
        public T Data { get; set; }

    }

}
