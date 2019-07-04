using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class Load
    {
        public int LoadId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}