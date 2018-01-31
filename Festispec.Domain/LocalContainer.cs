namespace Festispec.Domain
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    class LocalContainer : DbContext
    {
        public LocalContainer()
            : base("name=LocalContainer")
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
    }
}