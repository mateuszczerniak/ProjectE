using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectE.Models
{
    public class Battery
    {
        public int BatteryId { get; set; }
        public string BatteryType { get; set; }
        public float Capacity { get; set; }
        public float CellVoltage { get; set; }
        public int CellQuantity { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<BatteryPack> BatteryPacks { get; set; }

        [ForeignKey("BatterySpecies")]
        public int BatterySpeciesId { get; set; }
        public virtual BatterySpecies BatterySpecies { get; set; }
        
    }
}