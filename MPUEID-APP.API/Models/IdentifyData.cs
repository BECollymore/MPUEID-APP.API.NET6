using System.ComponentModel.DataAnnotations;

namespace MPUEID_APP.API.Models
{
    public partial class IdentifyData
    {
        [StringLength(255)]
        public string Address { get; set; } = string.Empty;

        [StringLength(8)]
        public string Pole { get; set; } = string.Empty;

        [StringLength(91)]
        public string Directions { get; set; } = string.Empty;

        [StringLength(50)]
        public string Applicant { get; set; } = string.Empty;

        [StringLength(14)]
        public string ApplicantTel { get; set; } = string.Empty;

        [StringLength(14)]
        public string WiremanTel { get; set; } = string.Empty;

        [StringLength(14)]
        public string AlternateTel { get; set; } = string.Empty;

        [StringLength(30)]
        public string ApplicationNo { get; set; } = string.Empty;

        [StringLength(30)]
        public string Wireman { get; set; } = string.Empty;
       
        [StringLength(1)]
        public string InspectionType { get; set; }
    }
}
