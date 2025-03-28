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

    public partial class ClassSubjectTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassSubjectTable()
        {
            this.ExamMarksTables = new HashSet<ExamMarksTable>();
            this.TimeTblTables = new HashSet<TimeTblTable>();
        }

        [Required]
        public int ClassSubjectID { get; set; }
        public int ClassID { get; set; }
        [Required]
        public int SubjectID { get; set; }
        [Required]
        public string Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual SubjectTable SubjectTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamMarksTable> ExamMarksTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeTblTable> TimeTblTables { get; set; }
    }
}
