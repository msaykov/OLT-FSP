namespace OLT_FSP.Models.Devices
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OLT_FSP.Data.DataConstants;

    public class AddDeviceFormModel
    {
        [Display(Name = "Choose Manifacturer")]
        [Required]
        [StringLength(ManifacturerNameMaxLength, MinimumLength = ManifacturerNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Manifacturer { get; set; }  // ZTE , HUAWEI

        [Display(Name = "Choose DataCenter")]
        [Required]
        [StringLength(DataCenterNameMaxLength, MinimumLength = DataCenterNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string DataCenter { get; set; }

        [Display(Name = "Choose Town")]
        [Required]
        [StringLength(TownNameMaxLength, MinimumLength = TownNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Town { get; set; }
    }
}
