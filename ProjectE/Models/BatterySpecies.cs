using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectE.Models
{
    public class BatterySpecies
    {
        public int BatterySpeciesId { get; set; }
        public string Species { get; set; }

        public virtual ICollection<Battery> Batteries { get; set; }

        
    }
}