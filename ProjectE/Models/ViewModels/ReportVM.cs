using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectE.Models.ViewModels
{
    public class ReportVM
    {
        public WorkSheet worksheet { get; set; }
        public List<SelectListItem> workreason { get; set; }
    }
}