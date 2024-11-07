﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EzSchool.Models
{
    public class Skill
    {
        [Key]
        public int IdSki { get; set; }
        public string SkillName { get; set; }
        public Nullable<int> IdPers { get; set; }
        public virtual Person Person { get; set; }
    }
}