//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EmployeeResumeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeResumeTable()
        {
            this.EmployeeCertificationTables = new HashSet<EmployeeCertificationTable>();
            this.EmployeeEducationTables = new HashSet<EmployeeEducationTable>();
            this.EmployeeLanguageTables = new HashSet<EmployeeLanguageTable>();
            this.EmployeeSkillTables = new HashSet<EmployeeSkillTable>();
            this.EmployeeWorkExperienceTables = new HashSet<EmployeeWorkExperienceTable>();
        }
    
        public int EmployeeResumeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string EducationalLevel { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; }
        public string LinkedInProdil { get; set; }
        public string FaceBookProfil { get; set; }
        public string C_CornerProfil { get; set; }
        public string TwitterProfil { get; set; }
        public byte[] Profil { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeCertificationTable> EmployeeCertificationTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeEducationTable> EmployeeEducationTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeLanguageTable> EmployeeLanguageTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeSkillTable> EmployeeSkillTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeWorkExperienceTable> EmployeeWorkExperienceTables { get; set; }
    }
}
