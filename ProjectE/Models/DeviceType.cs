using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Device> Devices { get; set; }
    }
}