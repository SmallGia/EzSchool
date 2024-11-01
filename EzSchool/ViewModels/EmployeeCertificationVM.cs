using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace EzSchool.ViewModels
{
    public class EmployeeCertificationVM
    {
        public int EmployeeCertificationID { get; set; }
        [Required(ErrorMessage = "Please enter the certification name")]
        public string CertificationName { get; set; }
        [Required(ErrorMessage = "Please enter the certification Authority")]
        public string CertificationAuthority { get; set; }
        [Required(ErrorMessage = "Please enter the certification Level")]
        public string LevelCertification { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter the achievement date")]
        public Nullable<System.DateTime> FromYear { get; set; }
        public Nullable<int> EmployeeResumeID { get; set; }
        public int UserID { get; set; }
        public List<SelectListItem> ListOfLevel { get; set; }
    }
}