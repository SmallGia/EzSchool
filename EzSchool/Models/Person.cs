using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EzSchool.Models
{
    public class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Certifications = new HashSet<Certification>();
            this.Educations = new HashSet<Education>();
            this.Languages = new HashSet<Language>();
            this.Skills = new HashSet<Skill>();
            this.WorkExperiences = new HashSet<WorkExperience>();
        }
        public int IdPers { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string EducationLevel { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; }
        public string LinkedInProfil { get; set; }
        public string FacebookProfil{ get; set; }
        public string TwitterProfil { get; set; }
        public byte[] Profil { get; set; }
        public Nullable<int> EmpID { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certification> Certifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Educations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Languages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skill> Skills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}