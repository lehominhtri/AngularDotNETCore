using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleAPI.Models
{
    public class VehicleDetail
    {
        [Key]
        [Column(TypeName = "nvarchar(100)")]
        public string VIN { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string VehicleMaker { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string VehicleModel { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime InspectionDate { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string InspectorName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string InspectionLocation { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool InspectionStatus { get; set; }
        [Column(TypeName = "ntext")]
        public string InspectionNotes { get; set; }
    }
}
