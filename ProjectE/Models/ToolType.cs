using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class ToolType
    {
        public int ToolTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tool> Tools { get; set; }
    }
}