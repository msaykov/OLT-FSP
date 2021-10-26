namespace OLT_FSP.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataConstants
    {
        public const int TownNameMinLength = 3;
        public const int TownNameMaxLength = 20;

        public const int DataCenterNameMinLength = 3;
        public const int DataCenterNameMaxLength = 20;

        public const int DeviceNameMaxLength = 7;
        public const int ManifacturerNameMinLength = 3;
        public const int ManifacturerNameMaxLength = 20;

        public const int ZoneMinLength = 3;
        public const int ZoneMaxLength = 100;
        public const int PathMinLength = 20;
        public const int PathMaxLength = 200;
        public const int DescriptionMinLength = 15;
        public const int DescriptionMaxLength = 50;
        public const int DestinationMinLength = 4;
        public const int DestinationMaxLength = 7;
        public const int NotesMinLength = 5;
        public const int NotesMaxLength = 200;

        public const int AddressMinLength = 10;
        public const int AddressMaxLength = 30;

        public const int ServiceSlotPortsCount = 0;
        public const int EmptyOltSlots = 0;
        public const int HalfSlotsMounted = 9;
        public const int AllSlotsMounted = 19;
        public const int FullOlt = 21;

        public const string NamesErrorMsg = "The {0} must be between {2} and {1} characters long.";
    }
}
