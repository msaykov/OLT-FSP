namespace OLT_FSP.Models.Targets
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class AddTargetFormModel
    {

        [Display(Name = "Destination Address")]
        [Required]
        [StringLength(DestinationMaxLength, MinimumLength = DestinationMinLength, ErrorMessage = NamesErrorMsg)]
        public string Destination { get; set; }

        [Display(Name = "Destination Id")]
        [Required]
        public int CoremapNumber { get; set; } // Coremap Id

        [Display(Name = "Select Zone")]
        [Required]
        [StringLength(ZoneMaxLength, MinimumLength = ZoneMinLength, ErrorMessage = NamesErrorMsg)]
        public string Zone { get; set; }


    }
}
