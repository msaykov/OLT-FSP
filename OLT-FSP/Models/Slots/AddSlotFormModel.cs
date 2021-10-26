namespace OLT_FSP.Models.Slots
{
    using System.ComponentModel.DataAnnotations;

    public class AddSlotFormModel
    {
        [Display(Name = "Choose Ports Count - 8 or 16")]
        [Required]
        public int PortsCount { get; set; }  // 8 , 16

        
    }
}
