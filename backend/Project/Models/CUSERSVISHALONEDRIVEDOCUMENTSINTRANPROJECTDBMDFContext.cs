using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project.Models
{
    public partial class CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext : DbContext
    {
        public CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext()
        {
        }

        public CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext(DbContextOptions<CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApproveCompany> ApproveCompany { get; set; }
        public virtual DbSet<ApproveResume> ApproveResume { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Imageupload> Imageupload { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<RejectedCompany> RejectedCompany { get; set; }
        public virtual DbSet<RejectedResume> RejectedResume { get; set; }
        public virtual DbSet<Resume> Resume { get; set; }
        public object output { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Vishal\\OneDrive\\Documents\\intranprojectdb.mdf;Integrated Security=True;Connect Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApproveCompany>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ApproveAt)
                    .HasColumnName("approve_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .IsRequired()
                    .HasColumnName("contactno")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Glassdoor)
                    .IsRequired()
                    .HasColumnName("glassdoor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Linkdin)
                    .IsRequired()
                    .HasColumnName("linkdin")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("website")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApproveResume>(entity =>
            {
                entity.Property(e => e.ApproveAt)
                    .HasColumnName("approve_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.Candidatename)
                    .IsRequired()
                    .HasColumnName("candidatename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Companyid)
                    .IsRequired()
                    .HasColumnName("companyid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .IsRequired()
                    .HasColumnName("contactno")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Highestqualification)
                    .IsRequired()
                    .HasColumnName("highestqualification")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Previouscompany)
                    .IsRequired()
                    .HasColumnName("previouscompany")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Resumeid).HasColumnName("resumeid");

                entity.Property(e => e.Skill)
                    .IsRequired()
                    .HasColumnName("skill")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyUsername)
                    .HasColumnName("company_username")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DelBy).HasColumnName("del_by");

                entity.Property(e => e.DetDt)
                    .HasColumnName("det_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Glassdoor)
                    .HasColumnName("glassdoor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsBy).HasColumnName("ins_by");

                entity.Property(e => e.InsDt)
                    .HasColumnName("ins_dt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsTest).HasColumnName("is_test");

                entity.Property(e => e.Linkdin)
                    .HasColumnName("linkdin")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy).HasColumnName("upd_by");

                entity.Property(e => e.UpdDt)
                    .HasColumnName("upd_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Imageupload>(entity =>
            {
                entity.Property(e => e.Imagepath)
                    .HasColumnName("imagepath")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<RejectedCompany>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .IsRequired()
                    .HasColumnName("contactno")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Glassdoor)
                    .IsRequired()
                    .HasColumnName("glassdoor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Linkdin)
                    .IsRequired()
                    .HasColumnName("linkdin")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.RejectedAt)
                    .HasColumnName("rejected_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("website")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RejectedResume>(entity =>
            {
                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.Candidatename)
                    .IsRequired()
                    .HasColumnName("candidatename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Companyid)
                    .IsRequired()
                    .HasColumnName("companyid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .IsRequired()
                    .HasColumnName("contactno")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Highestqualification)
                    .IsRequired()
                    .HasColumnName("highestqualification")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Previouscompany)
                    .IsRequired()
                    .HasColumnName("previouscompany")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RejectedAt)
                    .HasColumnName("rejected_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resumeid).HasColumnName("resumeid");

                entity.Property(e => e.Skill)
                    .IsRequired()
                    .HasColumnName("skill")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<Resume>(entity =>
            {
                entity.ToTable("resume");

                entity.HasIndex(e => e.ResumeId)
                    .HasName("u_resume_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Approved)
                    .HasColumnName("approved")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Candidatename)
                    .HasColumnName("candidatename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyUsername)
                    .HasColumnName("company_username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("date");

                entity.Property(e => e.DelBy).HasColumnName("del_by");

                entity.Property(e => e.DetDt)
                    .HasColumnName("det_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Highestqulification)
                    .HasColumnName("highestqulification")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsBy).HasColumnName("ins_by");

                entity.Property(e => e.InsDt)
                    .HasColumnName("ins_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsTest).HasColumnName("is_test");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Previouscompany)
                    .HasColumnName("previouscompany")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResumeId)
                    .HasColumnName("resume_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Skill)
                    .HasColumnName("skill")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy).HasColumnName("upd_by");

                entity.Property(e => e.UpdDt)
                    .HasColumnName("upd_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Upload)
                    .HasColumnName("upload")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });
        }
    }
}
