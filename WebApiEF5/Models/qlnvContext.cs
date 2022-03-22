using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiEF5.Models
{
    public partial class qlnvContext : DbContext
    {
        public qlnvContext()
        {
        }

        public qlnvContext(DbContextOptions<qlnvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<SalaryGrade> SalaryGrades { get; set; }
        public virtual DbSet<Timekeeper> Timekeepers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //  #warning To protect potentially sensitive information in your connection string, you should move it out of source code.
                //  You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration
                //  - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings,
                //  see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql(
                    "server=localhost;port=3306;database=qlnv;user=root;password=123456789", 
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PRIMARY");

                entity.ToTable("department");

                entity.HasIndex(e => e.DeptNo, "dept_no")
                    .IsUnique();

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("dept_id");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("dept_name");

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("dept_no");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmplId)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.HasIndex(e => e.DeptId, "FK_EmplDepart");

                entity.HasIndex(e => e.MngId, "FK_EmplManager");

                entity.HasIndex(e => e.EmplNo, "empl_no")
                    .IsUnique();

                entity.Property(e => e.EmplId)
                    .ValueGeneratedNever()
                    .HasColumnName("empl_id");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.EmplName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("empl_name");

                entity.Property(e => e.EmplNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("empl_no");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("job");

                entity.Property(e => e.MngId).HasColumnName("mng_id");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmplDepart");

                entity.HasOne(d => d.Mng)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.MngId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmplManager");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.MngId)
                    .HasName("PRIMARY");

                entity.ToTable("manager");

                entity.Property(e => e.MngId)
                    .ValueGeneratedNever()
                    .HasColumnName("mng_id");

                entity.Property(e => e.MngPosition)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("mng_position");
            });

            modelBuilder.Entity<SalaryGrade>(entity =>
            {
                entity.HasKey(e => e.Grade)
                    .HasName("PRIMARY");

                entity.ToTable("salary_grade");

                entity.Property(e => e.Grade)
                    .ValueGeneratedNever()
                    .HasColumnName("grade");

                entity.Property(e => e.HighSalary).HasColumnName("high_salary");

                entity.Property(e => e.LowSalary).HasColumnName("low_salary");
            });

            modelBuilder.Entity<Timekeeper>(entity =>
            {
                entity.ToTable("timekeeper");

                entity.HasIndex(e => e.EmplId, "FK_EmplTimekeeper");

                entity.Property(e => e.TimekeeperId)
                    .HasMaxLength(36)
                    .HasColumnName("timekeeper_id");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time");

                entity.Property(e => e.EmplId).HasColumnName("empl_id");

                entity.Property(e => e.InOut)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("in_out")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.Timekeepers)
                    .HasForeignKey(d => d.EmplId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmplTimekeeper");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
