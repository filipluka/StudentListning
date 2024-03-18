using Microsoft.EntityFrameworkCore;
using StudentListning.Models;

namespace StudentListning
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
              .HasOne(s => s.Address) // Student has one address, one to one relation
              .WithOne(a => a.Student) // Address is associated with one student
              .HasForeignKey<Address>(e => e.AddressID)
              .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<Address>()
               .HasKey(a => a.AddressID);

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<University>().ToTable("Universities");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Grade>().ToTable("Grades");
        }
        public virtual DbSet<Student> Students { get; set; }
    }
}
