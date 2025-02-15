using FluentValidation.Results;
using SmartVars.Application.Notification;
using SmartVars.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Application.Services
{
    public class BuildingVarsResultsServices
    {
        public bool IsSucsess { get; set; }
        public string Message { get; set; }
        public ICollection<BuildingVarsResultNotifcation> Errors { get; set; }

        public static BuildingVarsResultsServices RequestError(string message, ValidationResult validations)
        {
            return new BuildingVarsResultsServices
            {
                IsSucsess = false,
                Message = message,
                Errors = validations.Errors.Select(x => new BuildingVarsResultNotifcation
                {
                    Field = x.PropertyName,
                    Message = x.ErrorMessage,
                }).ToList(),

            };
        }
        public static BuildingVarsResultsServices<T> RequestError<T>(string message, ValidationResult validations)
        {
            return new BuildingVarsResultsServices<T>
            {
                IsSucsess = false,
                Message = message,
                Errors = validations.Errors.Select(x => new BuildingVarsResultNotifcation
                {
                    Field = x.PropertyName,
                    Message = x.ErrorMessage,
                }).ToList(),

            };
        }

        public static BuildingVarsResultsServices Fail(string message) => new BuildingVarsResultsServices
        {
            IsSucsess = false,
            Message = message,
        };

        public static BuildingVarsResultsServices<T> Fail<T>(string message) => new BuildingVarsResultsServices<T>
        {
            IsSucsess = false,
            Message = message,
        };

        public static BuildingVarsResultsServices Sucess(string message) => new BuildingVarsResultsServices
        {
            IsSucsess = true,
            Message = message,
        };

        public static BuildingVarsResultsServices<T> Sucess<T>(T data) => new BuildingVarsResultsServices<T>
        {
            IsSucsess = true,
            Data = data,
        };


    }


    public class BuildingVarsResultsServices<T> : BuildingVarsResultsServices
    {
        public T Data { get; set; }

    }

}
