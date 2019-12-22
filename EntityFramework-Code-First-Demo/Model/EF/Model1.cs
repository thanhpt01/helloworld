namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=Model1")
        {
            Database.SetInitializer<ModelDbContext>(new CreateDatabaseIfNotExists<ModelDbContext>());
            //Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<ModelDbContext>());
        }

        public virtual DbSet<Student> Students { get; set; }
        public DbSet<UserAttachment> UserAttachment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        //// Migrations are considered configured for MyDbContext because this class implementation exists.
        //internal sealed class Configuration : System.Data.Entity.Migrations.DbMigrationsConfiguration<ModelDbContext>
        //{
        //    public Configuration()
        //    {
        //        AutomaticMigrationsEnabled = false;
        //    }
        //}

        //// Declaring (and elsewhere registering) this DB initializer of type MyDbContext - but a DbMigrationsConfiguration already exists for that type.
        //public class TestDatabaseInitializer : DropCreateDatabaseAlways<ModelDbContext>
        //{
        //    protected override void Seed(ModelDbContext context) { }
        //}
    }
}
