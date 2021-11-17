namespace OLT_FSP.Models.Ports
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;


    public class AddPortFormModel
    {
        public int Number { get; set; }  // AutoFill

        [Display(Name = "Select Zone")]
        [Required]
        [StringLength(ZoneMaxLength, MinimumLength = ZoneMinLength, ErrorMessage = NamesErrorMsg)]
        public string Zone { get; set; }

        [Required]
        [StringLength(PathMaxLength, MinimumLength = PathMinLength, ErrorMessage = NamesErrorMsg)]
        public string Path { get; set; }   // Rack-1 , ODF-1 , port 5 ....  

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = NamesErrorMsg)]
        public string Description { get; set; } // Residential customers , Business customers ... 

        [Display(Name = "Destination Address")]
        [Required]
        [StringLength(DestinationMaxLength, MinimumLength = DestinationMinLength, ErrorMessage = NamesErrorMsg)]
        public string Destination { get; set; }

        [Display(Name = "Destination Id")]
        [Required]
        public int CoremapNumber { get; set; } // Coremap Id

        [Required]
        [StringLength(NotesMaxLength, MinimumLength = NotesMinLength, ErrorMessage = NamesErrorMsg)]
        public string Notes { get; set; }  // 1/2 in Cabinet , ....   
    }
}
