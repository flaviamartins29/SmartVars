using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Application.Model
{
    public class BuildingVarsModel
    {
        public int Id { get; set; }
        public int? MyInt { get; set; }
        public string? MyString { get; set; }
        public bool? ThisMy { get; set; }
        public decimal? MyDecimal { get; set; }
        public double? MyDouble { get; set; }
        public DateTime? MyDateTime { get; set; }
    }
}
