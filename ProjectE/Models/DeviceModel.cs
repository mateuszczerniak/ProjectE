using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class DeviceModel
    {
        public int DeviceModelId { get; set; }
        public string Name { get; set; }
        public float Power { get; set; }
        public float InputVoltage { get; set; }
        public float OutputVoltage { get; set; }
        public float InputCurrent { get; set; }
        public float OutputCurrent { get; set; }
        public int InputPhaseNumber { get; set; }
        public int OutputPhaseNumber { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("DeviceType")]
        public int DeviceTypeId { get; set; }
        public virtual DeviceType DeviceType { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}