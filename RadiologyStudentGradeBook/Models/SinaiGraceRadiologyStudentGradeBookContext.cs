using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RadiologyStudentGradeBook.Models
{
    public partial class SinaiGraceRadiologyStudentGradeBookContext : DbContext
    {
        public SinaiGraceRadiologyStudentGradeBookContext()
        {
        }

        public SinaiGraceRadiologyStudentGradeBookContext(DbContextOptions<SinaiGraceRadiologyStudentGradeBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassToStudent> ClassToStudent { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=SinaiGraceRadiologyStudentGradeBook;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<ClassToStudent>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassToStudent)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__ClassToSt__Class__5EBF139D");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassToStudent)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__ClassToSt__Stude__5FB337D6");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Grade__ClassId__5812160E");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Grade__StudentId__59063A47");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(75);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });
        }
    }
}
