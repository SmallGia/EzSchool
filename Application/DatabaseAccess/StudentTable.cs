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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class StudentTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentTable()
        {
            this.AttendanceTables = new HashSet<AttendanceTable>();
            this.ExamMarksTables = new HashSet<ExamMarksTable>();
            this.SchoolLeavingTables = new HashSet<SchoolLeavingTable>();
            this.StudentPromotTables = new HashSet<StudentPromotTable>();
            this.SubmissionFeeTables = new HashSet<SubmissionFeeTable>();
        }
    
        public int StudentID { get; set; }
        public int SessionID { get; set; }
        public int ProgrameID { get; set; }
        public int ClassID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime AddmissionDate { get; set; }
        public string PreviousSchool { get; set; }
        public Nullable<double> PreviousPercentage { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "{0} Required Field!")]
        public HttpPostedFileBase PhotoFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceTable> AttendanceTables { get; set; }
        public virtual ClassTable ClassTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamMarksTable> ExamMarksTables { get; set; }
        public virtual ProgrameTable ProgrameTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolLeavingTable> SchoolLeavingTables { get; set; }
        public virtual SessionTable SessionTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentPromotTable> StudentPromotTables { get; set; }
        public virtual UserTable UserTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmissionFeeTable> SubmissionFeeTables { get; set; }
    }
}
