﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine_1 = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    AddressLine_2 = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    AddressLine_3 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musclegroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Musclegroup = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musclegroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statustype = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainingprograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainingprograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Fk_exercise_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_Exercises",
                        column: x => x.Fk_exercise_id,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exercise_Musclegroups",
                columns: table => new
                {
                    Fk_Exercise_Id = table.Column<int>(type: "int", nullable: false),
                    Fk_Musclegroup_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise_Musclegroups", x => new { x.Fk_Exercise_Id, x.Fk_Musclegroup_Id });
                    table.ForeignKey(
                        name: "FK_Exercise_Musclegroups_Exercises_Fk_Exercise_Id",
                        column: x => x.Fk_Exercise_Id,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_Musclegroups_Musclegroup_Fk_Musclegroup_Id",
                        column: x => x.Fk_Musclegroup_Id,
                        principalTable: "Musclegroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusclegroupTrainingprogram",
                columns: table => new
                {
                    MusclegroupsId = table.Column<int>(type: "int", nullable: false),
                    TrainingprogramsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusclegroupTrainingprogram", x => new { x.MusclegroupsId, x.TrainingprogramsId });
                    table.ForeignKey(
                        name: "FK_MusclegroupTrainingprogram_Musclegroup_MusclegroupsId",
                        column: x => x.MusclegroupsId,
                        principalTable: "Musclegroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusclegroupTrainingprogram_Trainingprograms_TrainingprogramsId",
                        column: x => x.TrainingprogramsId,
                        principalTable: "Trainingprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainingprogram_Categories",
                columns: table => new
                {
                    Fk_Trainingprogram_Id = table.Column<int>(type: "int", nullable: false),
                    Fk_Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainingprogram_Categories", x => new { x.Fk_Trainingprogram_Id, x.Fk_Category_Id });
                    table.ForeignKey(
                        name: "FK_Trainingprogram_Categories_Categories_Fk_Category_Id",
                        column: x => x.Fk_Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainingprogram_Categories_Trainingprograms_Fk_Trainingprogram_Id",
                        column: x => x.Fk_Trainingprogram_Id,
                        principalTable: "Trainingprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_user_id = table.Column<int>(type: "int", nullable: false),
                    Fk_address_id = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    MedicalCondition = table.Column<string>(type: "text", nullable: true),
                    Disabilities = table.Column<string>(type: "text", nullable: true),
                    Firstname = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nchar(250)", fixedLength: true, maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Addresses",
                        column: x => x.Fk_address_id,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profiles_Users",
                        column: x => x.Fk_user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Fk_set_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workout_Sets",
                        column: x => x.Fk_set_id,
                        principalTable: "Sets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contributionrequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_profile_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributionrequests_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributionrequests_Profiles1",
                        column: x => x.Fk_profile_id,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_profile_id = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Achived = table.Column<bool>(type: "bit", nullable: false),
                    Fk_Trainingprogram_id = table.Column<int>(type: "int", nullable: true),
                    Fk_status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Profiles",
                        column: x => x.Fk_profile_id,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goals_Status",
                        column: x => x.Fk_status_id,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goals_Trainingprograms",
                        column: x => x.Fk_Trainingprogram_id,
                        principalTable: "Trainingprograms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainingprogram_Workouts",
                columns: table => new
                {
                    Fk_Trainingprogram_Id = table.Column<int>(type: "int", nullable: false),
                    Fk_Workout_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainingprogram_Workouts", x => new { x.Fk_Trainingprogram_Id, x.Fk_Workout_Id });
                    table.ForeignKey(
                        name: "FK_Trainingprogram_Workouts_Trainingprograms_Fk_Trainingprogram_Id",
                        column: x => x.Fk_Trainingprogram_Id,
                        principalTable: "Trainingprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainingprogram_Workouts_Workout_Fk_Workout_Id",
                        column: x => x.Fk_Workout_Id,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workout_Goals_Status",
                columns: table => new
                {
                    Fk_Workout_Id = table.Column<int>(type: "int", nullable: false),
                    Fk_Goal_Id = table.Column<int>(type: "int", nullable: false),
                    Fk_Status_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout_Goals_Status", x => new { x.Fk_Workout_Id, x.Fk_Goal_Id });
                    table.ForeignKey(
                        name: "FK_Workout_Goals_Status_Goals_Fk_Goal_Id",
                        column: x => x.Fk_Goal_Id,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workout_Goals_Status_Status_Fk_Status_Id",
                        column: x => x.Fk_Status_Id,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workout_Goals_Status_Workout_Fk_Workout_Id",
                        column: x => x.Fk_Workout_Id,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributionrequests_Fk_profile_id",
                table: "Contributionrequests",
                column: "Fk_profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Musclegroups_Fk_Musclegroup_Id",
                table: "Exercise_Musclegroups",
                column: "Fk_Musclegroup_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_Fk_profile_id",
                table: "Goals",
                column: "Fk_profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_Fk_status_id",
                table: "Goals",
                column: "Fk_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_Fk_Trainingprogram_id",
                table: "Goals",
                column: "Fk_Trainingprogram_id");

            migrationBuilder.CreateIndex(
                name: "IX_MusclegroupTrainingprogram_TrainingprogramsId",
                table: "MusclegroupTrainingprogram",
                column: "TrainingprogramsId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Fk_address_id",
                table: "Profiles",
                column: "Fk_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Fk_user_id",
                table: "Profiles",
                column: "Fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_Fk_exercise_id",
                table: "Sets",
                column: "Fk_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainingprogram_Categories_Fk_Category_Id",
                table: "Trainingprogram_Categories",
                column: "Fk_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainingprogram_Workouts_Fk_Workout_Id",
                table: "Trainingprogram_Workouts",
                column: "Fk_Workout_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_Fk_set_id",
                table: "Workout",
                column: "Fk_set_id");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_Goals_Status_Fk_Goal_Id",
                table: "Workout_Goals_Status",
                column: "Fk_Goal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_Goals_Status_Fk_Status_Id",
                table: "Workout_Goals_Status",
                column: "Fk_Status_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributionrequests");

            migrationBuilder.DropTable(
                name: "Exercise_Musclegroups");

            migrationBuilder.DropTable(
                name: "MusclegroupTrainingprogram");

            migrationBuilder.DropTable(
                name: "Trainingprogram_Categories");

            migrationBuilder.DropTable(
                name: "Trainingprogram_Workouts");

            migrationBuilder.DropTable(
                name: "Workout_Goals_Status");

            migrationBuilder.DropTable(
                name: "Musclegroup");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Trainingprograms");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}
