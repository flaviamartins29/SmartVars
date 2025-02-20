using FluentValidation.Results;
using SmartVars.Domain.Notifications;

namespace SmartVars.Domain.Validations
{
    public class BuildingVarsResults
    {
        public bool IsSucsess { get; set; }
        public string Message { get; set; }
        public ICollection<BuildingVarsResultNotifcation> Errors { get; set; }

        public static BuildingVarsResults RequestError(string message, ValidationResult validations)
        {
            return new BuildingVarsResults
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
        public static BuildingVarsResults<T> RequestError<T>(string message, ValidationResult validations)
        {
            return new BuildingVarsResults<T>
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
        public static BuildingVarsResults Fail(string message) => new BuildingVarsResults
        {
            IsSucsess = false,
            Message = message,
        };

        public static BuildingVarsResults<T> Fail<T>(string message) => new BuildingVarsResults<T>
        {
            IsSucsess = false,
            Message = message,
        };

        public static BuildingVarsResults Sucess(string message) => new BuildingVarsResults
        {
            IsSucsess = true,
            Message = message,
        };

        public static BuildingVarsResults<T> Sucess<T>(T data) => new BuildingVarsResults<T>
        {
            IsSucsess = true,
            Data = data,
        };


    }


    public class BuildingVarsResults<T> : BuildingVarsResults
    {
        public T Data { get; set; }

    }

}

