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

    public partial class StaffTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffTable()
        {
            this.EmployeeLeavingTables = new HashSet<EmployeeLeavingTable>();
            this.EmployeeSalaryTables = new HashSet<EmployeeSalaryTable>();
            this.StaffAttendanceTables = new HashSet<StaffAttendanceTable>();
            this.TimeTblTables = new HashSet<TimeTblTable>();
        }
    
        public int StaffID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int DesignationID { get; set; }
        public string ContactNo { get; set; }
        public double BasicSalary { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Gender { get; set; }
        public string HomePhone { get; set; }
        public Nullable<bool> Doyouhaveanydisability { get; set; }
        public string Ifdisabilityyesthengiveusdetail { get; set; }
        public Nullable<bool> Areyoutakinganymedication { get; set; }
        public string Imedicationyesthengiveusdetail { get; set; }
        public Nullable<bool> AnyCriminaloffcenceagainstyou { get; set; }
        public string Ifcriminaloffcenceyesthengiveusdetail { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime RegistrationDate { get; set; }
    
        public virtual DesignationTable DesignationTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeLeavingTable> EmployeeLeavingTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeSalaryTable> EmployeeSalaryTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffAttendanceTable> StaffAttendanceTables { get; set; }
        public virtual UserTable UserTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeTblTable> TimeTblTables { get; set; }
    }
}
