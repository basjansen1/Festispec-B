﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Festispec.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FestispecContainer : DbContext
    {
        public FestispecContainer()
            : base("name=FestispecContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRole { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<InspectionStatus> InspectionStatus { get; set; }
        public virtual DbSet<Planning> Planning { get; set; }
        public virtual DbSet<Regulation> Regulation { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<InspectionQuestion> InspectionQuestion { get; set; }
        public virtual DbSet<InspectionQuestionAnswer> InspectionQuestionAnswer { get; set; }
        public virtual DbSet<TemplateQuestion> TemplateQuestion { get; set; }
    }
}
