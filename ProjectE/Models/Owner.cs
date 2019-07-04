using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }

        

        public virtual ICollection<BatteryPack> BatteryPacks { get; set; }
    }
}