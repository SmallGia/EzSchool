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

    public partial class AttendanceTable
    {
        public int AttendanceID { get; set; }
        public int SessionID { get; set; }
        public int StudentID { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime AttendDate { get; set; }
        [DataType(DataType.Time)]
        public System.TimeSpan AttendTime { get; set; }
        public int ClassID { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
    }
}
