using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace SmartVars.Application.Model
{
    public class BuildingVarsModel
    {
        [SwaggerSchema("Unique identifier of the record")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [SwaggerSchema("Customized integer value")]
        [Display(Name = "MyInt")]
        public int? MyInt { get; set; }

        [SwaggerSchema("Descriptive text")]
        [Display(Name = "MyString")]
        public string? MyString { get; set; }

        [SwaggerSchema("Boolean representing a condition")]
        [Display(Name = "ThisMy")]
        public bool? ThisMy { get; set; }

        [SwaggerSchema("Decimal value for financial calculations")]
        [Display(Name = "MyDecimal")]
        public decimal? MyDecimal { get; set; }

        [SwaggerSchema("Value tyo float")]
        [Display(Name = "MyDouble")]
        public double? MyDouble { get; set; }

        [SwaggerSchema("My Date")]
        [Display(Name = "MyDateTime")]
        public DateTime? MyDateTime { get; set; }
    }
}
