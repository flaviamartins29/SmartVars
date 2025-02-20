using System.ComponentModel.DataAnnotations;

namespace SmartVars.Application.ViewModel
{
    [Serializable]
    public class BuildingVarsViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "MyInt")]
        public int? MyInt { get; set; }

        [Display(Name = "MyString")]
        public string? MyString { get; set; }

        [Display(Name = "ThisMy")]
        public bool? ThisMy { get; set; }

        [Display(Name = "MyDecimal")]
        public decimal? MyDecimal { get; set; }

        [Display(Name = "MyDouble")]
        public double? MyDouble { get; set; }

        [Display(Name = "MyDateTime")]
        public DateTime? MyDateTime { get; set; }
    }
}
