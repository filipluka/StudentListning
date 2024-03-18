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
              .HasForeignKey<Address>(e => e.AddressID);


            modelBuilder.Entity<Address>()
               .HasKey(a => a.AddressID);

            //modelBuilder.Entity<Grade>()
            //   .HasKey(g => g.GradeId);

            //modelBuilder.Entity<Grade>()
            //    .HasIndex(g => g.GradeName)
            //    .IsUnique();

            modelBuilder.Entity<Student>()
               .HasOne(s => s.Grade)
               .WithMany(g => g.Students)
               .OnDelete(DeleteBehavior.ClientCascade);

            //modelBuilder.Entity<University>()
            //   .HasMany(s => s.Students)
            //   .WithOne(s => s.University)
            //   .HasForeignKey(s => s.StudentID)
            //   .OnDelete(DeleteBehavior.ClientCascade);

          //  modelBuilder.Entity<Student>()
          // .HasOne<Grade>(s => s.Grade)
          // .WithMany(g => g.Students)
          // .HasForeignKey(g => g.GradeID).IsRequired();

          //  modelBuilder.Entity<Student>()
          //.HasOne<University>(s => s.University)
          //.WithMany(g => g.Students)
          //.HasForeignKey(g => g.UniversityID).IsRequired();

          //  modelBuilder.Entity<Student>()
          //.HasOne<Course>(s => s.Course)
          //.WithMany(g => g.Students)
          //.HasForeignKey(g => g.CourseID).IsRequired();

            //modelBuilder.Entity<Course>()
            //   .HasMany(s => s.Students)
            //   .WithOne(g => g.Course)
            //   .HasForeignKey(s => s.CourseID);

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<University>().ToTable("Universities");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Grade>().ToTable("Grades");
        }
        public virtual DbSet<Student> Students { get; set; }
    }
}
