﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolMgDbEntities : DbContext
    {
        public SchoolMgDbEntities()
            : base("name=SchoolMgDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AnnualTable> AnnualTables { get; set; }
        public virtual DbSet<AttendanceTable> AttendanceTables { get; set; }
        public virtual DbSet<DesignationTable> DesignationTables { get; set; }
        public virtual DbSet<ExamTable> ExamTables { get; set; }
        public virtual DbSet<ProgrameSessionTable> ProgrameSessionTables { get; set; }
        public virtual DbSet<ProgrameTable> ProgrameTables { get; set; }
        public virtual DbSet<SessionTable> SessionTables { get; set; }
        public virtual DbSet<StaffAttendanceTable> StaffAttendanceTables { get; set; }
        public virtual DbSet<StaffTable> StaffTables { get; set; }
        public virtual DbSet<StudentTable> StudentTables { get; set; }
        public virtual DbSet<SubmissionFeeTable> SubmissionFeeTables { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }
        public virtual DbSet<UserTypeTable> UserTypeTables { get; set; }
        public virtual DbSet<ClassTable> ClassTables { get; set; }
        public virtual DbSet<StudentPromotTable> StudentPromotTables { get; set; }
        public virtual DbSet<ClassSubjectTable> ClassSubjectTables { get; set; }
        public virtual DbSet<ExamMarksTable> ExamMarksTables { get; set; }
        public virtual DbSet<SubjectTable> SubjectTables { get; set; }
        public virtual DbSet<TimeTblTable> TimeTblTables { get; set; }
    }
}
