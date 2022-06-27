namespace OLT_FSP.Services.Ports
{
    using System.ComponentModel.DataAnnotations;
    using static OLT_FSP.Data.DataConstants;

    public class EditPortServiceModel
    {
        [Display(Name = "Splitter Outputs")]
        [Required]
        public string SplitterOutputs { get; set; }

        [Display(Name = "ODF position")]
        [Required]
        [StringLength(PathMaxLength, MinimumLength = PathMinLength, ErrorMessage = NamesErrorMsg)]
        public string Path { get; set; }   // Rack-1 , ODF-1 , port 5 ....  

        //[Required]
        //[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = NamesErrorMsg)]
        //public string Description { get; set; } // Residential customers , Business customers ... 

        [Display(Name = "Destination Id")]
        [Required]
        public int CoremapNumber { get; set; } // Coremap Id

        [Display(Name = "Destination Address")]
        [Required]
        [StringLength(DestinationMaxLength, MinimumLength = DestinationMinLength, ErrorMessage = NamesErrorMsg)]
        public string Destination { get; set; }

        [Display(Name = "Select Zone")]
        [Required]
        [StringLength(ZoneMaxLength, MinimumLength = ZoneMinLength, ErrorMessage = NamesErrorMsg)]
        public string Zone { get; set; }

        [Required]
        [StringLength(NotesMaxLength, MinimumLength = NotesMinLength, ErrorMessage = NamesErrorMsg)]
        public string Notes { get; set; }  // 1/2 in Cabinet , .... 
    }    
}
