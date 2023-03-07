﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;


namespace webapi.DatabaseContext;

public partial class MeFitContext : DbContext
{
    public MeFitContext()
    {
    }

    public MeFitContext(DbContextOptions<MeFitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contributionrequest> Contributionrequests { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Musclegroup> Musclegroups { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Trainingprogram> Trainingprograms { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MeFit;Encrypt=False;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.AddressLine1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("AddressLine_1");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("AddressLine_2");
            entity.Property(e => e.AddressLine3)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("AddressLine_3");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Category1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Category");
        });

        modelBuilder.Entity<Contributionrequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Contributionrequests_1");

            entity.Property(e => e.FkProfileId).HasColumnName("Fk_profile_id");

            entity.HasOne(d => d.FkProfile).WithMany(p => p.Contributionrequests)
                .HasForeignKey(d => d.FkProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contributionrequests_Profiles1");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        // Excercise-Musclegroup Linking table

        modelBuilder.Entity<Exercise>()
            .HasMany(m => m.Musclegroups)
            .WithMany(c => c.Exercises)
            .UsingEntity<Dictionary<string, object>>(
                "Exercise_Musclegroups",
                r => r.HasOne<Musclegroup>().WithMany().HasForeignKey("Fk_Musclegroup_Id"),
                l => l.HasOne<Exercise>().WithMany().HasForeignKey("Fk_Exercise_Id"),
                je =>
                {
                    je.HasKey("Fk_Exercise_Id", "Fk_Musclegroup_Id");
                    je.Property<int>("Fk_Exercise_Id").ValueGeneratedNever();
                    je.Property<int>("Fk_Musclegroup_Id").ValueGeneratedNever();

                });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.FkProfileId).HasColumnName("Fk_profile_id");
            entity.Property(e => e.FkTrainingprogramId).HasColumnName("Fk_Trainingprogram_id");
            entity.Property(e => e.FkStatusId).HasColumnName("Fk_status_id");

            entity.HasOne(d => d.FkProfile).WithMany(p => p.Goals)
                .HasForeignKey(d => d.FkProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goals_Profiles");

            entity.HasOne(d => d.FkProgram).WithMany(p => p.Goals)
                .HasForeignKey(d => d.FkTrainingprogramId)
                .HasConstraintName("FK_Goals_Trainingprograms");

            entity.HasOne(d => d.FkStatus).WithMany(p => p.Goals)
                .HasForeignKey(d => d.FkStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goals_Status");
        });

        modelBuilder.Entity<Musclegroup>(entity =>
        {
            entity.ToTable("Musclegroup");

            entity.Property(e => e.Musclegroup1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Musclegroup");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.Property(e => e.Disabilities).HasColumnType("text");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FkAddressId).HasColumnName("Fk_address_id");
            entity.Property(e => e.FkUserId).HasColumnName("Fk_user_id");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.MedicalCondition).HasColumnType("text");
            entity.Property(e => e.Picture)
                .HasMaxLength(250)
                .IsFixedLength();

            entity.HasOne(d => d.FkAddress).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.FkAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profiles_Addresses");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.FkUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profiles_Users");
        });

        modelBuilder.Entity<Trainingprogram>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        // Program Category linking table


        modelBuilder.Entity<Trainingprogram>()
            .HasMany(m => m.Categories)
            .WithMany(c => c.Trainingprograms)
            .UsingEntity<Dictionary<string, object>>(
                "Trainingprogram_Categories",
                r => r.HasOne<Category>().WithMany().HasForeignKey("Fk_Category_Id"),
                l => l.HasOne<Trainingprogram>().WithMany().HasForeignKey("Fk_Trainingprogram_Id"),
                je =>
                {
                    je.HasKey("Fk_Trainingprogram_Id", "Fk_Category_Id");
                    je.Property<int>("Fk_Trainingprogram_Id").ValueGeneratedNever();
                    je.Property<int>("Fk_Category_Id").ValueGeneratedNever();

                });

        // Trainingprogram Workout linking table


        modelBuilder.Entity<Trainingprogram>()
            .HasMany(m => m.Workouts)
            .WithMany(c => c.Trainingprograms)
            .UsingEntity<Dictionary<string, object>>(
                "Trainingprogram_Workouts",
                r => r.HasOne<Workout>().WithMany().HasForeignKey("Fk_Workout_Id"),
                l => l.HasOne<Trainingprogram>().WithMany().HasForeignKey("Fk_Trainingprogram_Id"),
                je =>
                {
                    je.HasKey("Fk_Trainingprogram_Id", "Fk_Workout_Id");
                    je.Property<int>("Fk_Trainingprogram_Id").ValueGeneratedNever();
                    je.Property<int>("Fk_Workout_Id").ValueGeneratedNever();

                });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.Property(e => e.FkExerciseId).HasColumnName("Fk_exercise_id");

            entity.HasOne(d => d.FkExercise).WithMany(p => p.Sets)
                .HasForeignKey(d => d.FkExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sets_Exercises");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Statustype)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Token)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.ToTable("Workout");

            entity.Property(e => e.FkSetId).HasColumnName("Fk_set_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.FkSet).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.FkSetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Workout_Sets");
        });

        // Workout Goal linking table
        modelBuilder.Entity<Workout>()
            .HasMany(m => m.Goals)
            .WithMany(c => c.Workouts)
            .UsingEntity<Dictionary<string, object>>(
                "Workout_Goals",
                r => r.HasOne<Goal>().WithMany().HasForeignKey("Fk_Goal_Id"),
                l => l.HasOne<Workout>().WithMany().HasForeignKey("Fk_Workout_Id"),
                je =>
                {
                    je.HasKey("Fk_Workout_Id", "Fk_Goal_Id");
                    je.HasOne<Status>().WithMany().HasForeignKey("Fk_Status_Id");
                    je.ToTable("Workout_Goals_Status");

                });



        //modelBuilder.Entity<WorkoutGoal>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("Workout_Goals");

        //    entity.Property(e => e.FkGoalId).HasColumnName("Fk_goal_id");
        //    entity.Property(e => e.FkStatusId).HasColumnName("Fk_status_id");
        //    entity.Property(e => e.FkWorkoutId).HasColumnName("Fk_workout_id");

        //    entity.HasOne(d => d.FkGoal).WithMany()
        //        .HasForeignKey(d => d.FkGoalId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Workout_Goals_Goals");

        //    entity.HasOne(d => d.FkStatus).WithMany()
        //        .HasForeignKey(d => d.FkStatusId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Workout_Goals_Status");

        //    entity.HasOne(d => d.FkWorkout).WithMany()
        //        .HasForeignKey(d => d.FkWorkoutId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Workout_Goals_Workout");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
