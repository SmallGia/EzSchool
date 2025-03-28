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

    public partial class SchoolLeavingTable
    {
        public int SchoolLeavingID { get; set; }
        public int UserID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime LeavingDate { get; set; }
        public string LeavingReason { get; set; }
        public string LeavingComments { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime CreatedDate { get; set; }
    
        public virtual UserTable UserTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
    }
}
