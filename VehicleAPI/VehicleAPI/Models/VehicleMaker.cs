using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleAPI.Models
{
    public class VehicleMaker
    {
        [Key]
        [Column(TypeName = "nvarchar(100)")]
        public string Maker_ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Maker_Name { get; set; }
    }
}
