using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EzSchool.Models
{
    public class Language
    {
        [Key]
        public int IdLang { get; set; }
        public string LanguageName { get; set; }
        public string Proficiency { get; set; }
        public Nullable<int> IdPers { get; set; }
        public virtual Person Person { get; set; }
    }
}