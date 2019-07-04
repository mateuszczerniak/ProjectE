using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectE.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tool> Tools { get; set; }
        public virtual ICollection<DeviceModel> DeviceModels { get; set; }

        public virtual ICollection<Battery> Batteries { get; set; }
    }
}