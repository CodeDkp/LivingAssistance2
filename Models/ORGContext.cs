using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LivingAssistance2.Models
{
    public partial class ORGContext : DbContext
    {
        public ORGContext()
        {
        }

        public ORGContext(DbContextOptions<ORGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<CareGiver> CareGivers { get; set; } = null!;
        public virtual DbSet<Guardian> Guardians { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientDetail> PatientDetails { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;
        public virtual DbSet<VerificationState> VerificationStates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Deepak_Kumar");

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingReferenceId)
                    .HasName("PK__Booking___57D9D2DFDBE69955");

                entity.ToTable("Booking_Details", "dbo");

                entity.Property(e => e.BookingReferenceId)
                    .HasMaxLength(50)
                    .HasColumnName("Booking_reference_ID");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasColumnName("Booking_Date");

                entity.Property(e => e.BookingTime).HasColumnName("booking_Time");

                entity.Property(e => e.CareGiverId)
                    .HasMaxLength(50)
                    .HasColumnName("CareGiver_Id");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(50)
                    .HasColumnName("Patient_Id");

                entity.Property(e => e.ServicesReq)
                    .HasMaxLength(50)
                    .HasColumnName("Services_Req");

                entity.Property(e => e.TotalCharges)
                    .HasColumnType("money")
                    .HasColumnName("Total_Charges");

                entity.HasOne(d => d.CareGiver)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.CareGiverId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CareGiver_Id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Patient_Id");
            });

            modelBuilder.Entity<CareGiver>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__CareGive__C1F8DC3943D45202");

                entity.ToTable("CareGivers", "dbo");

                entity.HasIndex(e => e.Uid, "UQ__CareGive__C5B19663645425AA")
                    .IsUnique();

                entity.Property(e => e.Cid)
                    .HasMaxLength(50)
                    .HasColumnName("CId");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Mname).HasMaxLength(50);

                entity.Property(e => e.Uid)
                    .HasMaxLength(50)
                    .HasColumnName("UId");

                entity.Property(e => e.Vfstatus)
                    .HasMaxLength(50)
                    .HasColumnName("VFStatus");

                entity.HasOne(d => d.VfstatusNavigation)
                    .WithMany(p => p.CareGivers)
                    .HasForeignKey(d => d.Vfstatus)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_VFStatus");
            });

            modelBuilder.Entity<Guardian>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("PK__Guardian__C51F0F1EE6DD8EA5");

                entity.ToTable("Guardian", "dbo");

                entity.Property(e => e.Gid)
                    .HasMaxLength(50)
                    .HasColumnName("GId");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Mname).HasMaxLength(50);

                entity.Property(e => e.PatientId)
                    .HasMaxLength(50)
                    .HasColumnName("Patient_Id");

                entity.Property(e => e.RelationWithPatient)
                    .HasMaxLength(50)
                    .HasColumnName("Relation_with_patient");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Guardians)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PId");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Patient__1788CC4C88889FF2");

                entity.ToTable("Patient", "dbo");

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GuardianContact).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Serviceneeded).HasMaxLength(50);
            });

            modelBuilder.Entity<PatientDetail>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Patient___C577554069056116");

                entity.ToTable("Patient_details", "dbo");

                entity.Property(e => e.Pid)
                    .HasMaxLength(50)
                    .HasColumnName("PId");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Mname).HasMaxLength(50);

                entity.Property(e => e.PAddress).HasColumnName("P_address");

                entity.Property(e => e.SelectedCg)
                    .HasMaxLength(50)
                    .HasColumnName("Selected_CG");

                entity.Property(e => e.TAddress).HasColumnName("T_Address");

                entity.HasOne(d => d.SelectedCgNavigation)
                    .WithMany(p => p.PatientDetails)
                    .HasForeignKey(d => d.SelectedCg)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Selected_CG");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServicesId)
                    .HasName("PK__Services__A74BF8549A93B504");

                entity.ToTable("Services", "dbo");

                entity.HasIndex(e => e.ServicesId, "SV_Services_ID")
                    .IsUnique();

                entity.Property(e => e.ServicesId)
                    .HasMaxLength(50)
                    .HasColumnName("Services_ID");

                entity.Property(e => e.ServicesName)
                    .HasMaxLength(50)
                    .HasColumnName("Services_Name");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User_Det__536C85E59225F801");

                entity.ToTable("User_Details", "dbo");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Mname).HasMaxLength(50);

                entity.Property(e => e.UserTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("user_type_id");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_utid");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserTypes", "dbo");

                entity.Property(e => e.UserTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("User_Type_Id");

                entity.Property(e => e.UserTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("User_Type_Name");
            });

            modelBuilder.Entity<VerificationState>(entity =>
            {
                entity.HasKey(e => e.VerificationId)
                    .HasName("PK_Verification_ID");

                entity.ToTable("VerificationState", "dbo");

                entity.Property(e => e.VerificationId)
                    .HasMaxLength(50)
                    .HasColumnName("Verification_ID");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
