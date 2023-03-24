﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.DatabaseContext;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(MeFitContext))]
    [Migration("20230324202509_new-migration-for-sets")]
    partial class newmigrationforsets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exercise_Musclegroups", b =>
                {
                    b.Property<int>("Fk_Exercise_Id")
                        .HasColumnType("int");

                    b.Property<int>("Fk_Musclegroup_Id")
                        .HasColumnType("int");

                    b.HasKey("Fk_Exercise_Id", "Fk_Musclegroup_Id");

                    b.HasIndex("Fk_Musclegroup_Id");

                    b.ToTable("Exercise_Musclegroups");
                });

            modelBuilder.Entity("Trainingprogram_Categories", b =>
                {
                    b.Property<int>("Fk_Trainingprogram_Id")
                        .HasColumnType("int");

                    b.Property<int>("Fk_Category_Id")
                        .HasColumnType("int");

                    b.HasKey("Fk_Trainingprogram_Id", "Fk_Category_Id");

                    b.HasIndex("Fk_Category_Id");

                    b.ToTable("Trainingprogram_Categories");
                });

            modelBuilder.Entity("Trainingprogram_Workouts", b =>
                {
                    b.Property<int>("Fk_Trainingprogram_Id")
                        .HasColumnType("int");

                    b.Property<int>("Fk_Workout_Id")
                        .HasColumnType("int");

                    b.HasKey("Fk_Trainingprogram_Id", "Fk_Workout_Id");

                    b.HasIndex("Fk_Workout_Id");

                    b.ToTable("Trainingprogram_Workouts");
                });

            modelBuilder.Entity("webapi.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("AddressLine_1")
                        .IsFixedLength();

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("AddressLine_2")
                        .IsFixedLength();

                    b.Property<string>("AddressLine3")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("AddressLine_3")
                        .IsFixedLength();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("webapi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Category")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("webapi.Models.Contributionrequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FkUserProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_UserProfile_id");

                    b.HasKey("Id")
                        .HasName("PK_Contributionrequests_1");

                    b.HasIndex("FkUserProfileId");

                    b.ToTable("Contributionrequests");
                });

            modelBuilder.Entity("webapi.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("webapi.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("FkStatusId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_status_id");

                    b.Property<int?>("FkTrainingprogramId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Trainingprogram_id");

                    b.Property<int>("FkUserProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_UserProfile_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("FkStatusId");

                    b.HasIndex("FkTrainingprogramId");

                    b.HasIndex("FkUserProfileId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("webapi.Models.GoalWorkouts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FkGoalId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Goal_id");

                    b.Property<int>("FkStatusId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Status_id");

                    b.Property<int>("FkWorkoutId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Workout_id");

                    b.HasKey("Id");

                    b.HasIndex("FkGoalId");

                    b.HasIndex("FkStatusId");

                    b.HasIndex("FkWorkoutId");

                    b.ToTable("Goal_Workouts", (string)null);
                });

            modelBuilder.Entity("webapi.Models.Musclegroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Musclegroup1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Musclegroup")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Musclegroup", (string)null);
                });

            modelBuilder.Entity("webapi.Models.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FkExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Exercise_Id");

                    b.Property<int>("FkWorkoutId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Workout_Id");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FkExerciseId");

                    b.HasIndex("FkWorkoutId");

                    b.ToTable("Sets", (string)null);
                });

            modelBuilder.Entity("webapi.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Statustype")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("webapi.Models.Trainingprogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Trainingprograms");
                });

            modelBuilder.Entity("webapi.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("FirstLogin")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("webapi.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Disabilities")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.Property<int>("FkAddressId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_address_id");

                    b.Property<string>("FkUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Fk_user_id");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.Property<string>("MedicalCondition")
                        .HasColumnType("text");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FkAddressId");

                    b.HasIndex("FkUserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("webapi.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FkUserProfileId")
                        .HasColumnType("int")
                        .HasColumnName("FkUserProfileId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("FkUserProfileId");

                    b.ToTable("Workout", (string)null);
                });

            modelBuilder.Entity("Exercise_Musclegroups", b =>
                {
                    b.HasOne("webapi.Models.Exercise", null)
                        .WithMany()
                        .HasForeignKey("Fk_Exercise_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Musclegroup", null)
                        .WithMany()
                        .HasForeignKey("Fk_Musclegroup_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trainingprogram_Categories", b =>
                {
                    b.HasOne("webapi.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("Fk_Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Trainingprogram", null)
                        .WithMany()
                        .HasForeignKey("Fk_Trainingprogram_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trainingprogram_Workouts", b =>
                {
                    b.HasOne("webapi.Models.Trainingprogram", null)
                        .WithMany()
                        .HasForeignKey("Fk_Trainingprogram_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Workout", null)
                        .WithMany()
                        .HasForeignKey("Fk_Workout_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webapi.Models.Contributionrequest", b =>
                {
                    b.HasOne("webapi.Models.UserProfile", "FkUserProfile")
                        .WithMany("Contributionrequests")
                        .HasForeignKey("FkUserProfileId")
                        .IsRequired()
                        .HasConstraintName("FK_Contributionrequests_UserProfiles1");

                    b.Navigation("FkUserProfile");
                });

            modelBuilder.Entity("webapi.Models.Goal", b =>
                {
                    b.HasOne("webapi.Models.Status", "FkStatus")
                        .WithMany("Goals")
                        .HasForeignKey("FkStatusId")
                        .IsRequired()
                        .HasConstraintName("FK_Goals_Status");

                    b.HasOne("webapi.Models.Trainingprogram", "FkTrainingprogram")
                        .WithMany("Goals")
                        .HasForeignKey("FkTrainingprogramId")
                        .HasConstraintName("FK_Goals_Trainingprograms");

                    b.HasOne("webapi.Models.UserProfile", "FkUserProfile")
                        .WithMany("Goals")
                        .HasForeignKey("FkUserProfileId")
                        .IsRequired()
                        .HasConstraintName("FK_Goals_UserProfiles");

                    b.Navigation("FkStatus");

                    b.Navigation("FkTrainingprogram");

                    b.Navigation("FkUserProfile");
                });

            modelBuilder.Entity("webapi.Models.GoalWorkouts", b =>
                {
                    b.HasOne("webapi.Models.Goal", "FkGoal")
                        .WithMany("GoalWorkouts")
                        .HasForeignKey("FkGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Status", "FkStatus")
                        .WithMany()
                        .HasForeignKey("FkStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Workout", "FkWorkout")
                        .WithMany("GoalWorkouts")
                        .HasForeignKey("FkWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FkGoal");

                    b.Navigation("FkStatus");

                    b.Navigation("FkWorkout");
                });

            modelBuilder.Entity("webapi.Models.Set", b =>
                {
                    b.HasOne("webapi.Models.Exercise", "FkExercise")
                        .WithMany("Sets")
                        .HasForeignKey("FkExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Workout", "FkWorkout")
                        .WithMany("Sets")
                        .HasForeignKey("FkWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FkExercise");

                    b.Navigation("FkWorkout");
                });

            modelBuilder.Entity("webapi.Models.UserProfile", b =>
                {
                    b.HasOne("webapi.Models.Address", "FkAddress")
                        .WithMany("UserProfiles")
                        .HasForeignKey("FkAddressId")
                        .IsRequired()
                        .HasConstraintName("FK_UserProfiles_Addresses");

                    b.HasOne("webapi.Models.User", "FkUser")
                        .WithMany("UserProfiles")
                        .HasForeignKey("FkUserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserProfiles_Users");

                    b.Navigation("FkAddress");

                    b.Navigation("FkUser");
                });

            modelBuilder.Entity("webapi.Models.Workout", b =>
                {
                    b.HasOne("webapi.Models.UserProfile", "FkUserProfile")
                        .WithMany("Workouts")
                        .HasForeignKey("FkUserProfileId");

                    b.Navigation("FkUserProfile");
                });

            modelBuilder.Entity("webapi.Models.Address", b =>
                {
                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("webapi.Models.Exercise", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("webapi.Models.Goal", b =>
                {
                    b.Navigation("GoalWorkouts");
                });

            modelBuilder.Entity("webapi.Models.Status", b =>
                {
                    b.Navigation("Goals");
                });

            modelBuilder.Entity("webapi.Models.Trainingprogram", b =>
                {
                    b.Navigation("Goals");
                });

            modelBuilder.Entity("webapi.Models.User", b =>
                {
                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("webapi.Models.UserProfile", b =>
                {
                    b.Navigation("Contributionrequests");

                    b.Navigation("Goals");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("webapi.Models.Workout", b =>
                {
                    b.Navigation("GoalWorkouts");

                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
