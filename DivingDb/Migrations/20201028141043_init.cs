using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DivingDb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeepGroups",
                columns: table => new
                {
                    DeepGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeepGroups", x => x.DeepGroupId);
                });

            migrationBuilder.CreateTable(
                name: "DeepTables",
                columns: table => new
                {
                    DeepTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeepTables", x => x.DeepTableId);
                });

            migrationBuilder.CreateTable(
                name: "Divers",
                columns: table => new
                {
                    DiverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Identifier = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divers", x => x.DiverId);
                });

            migrationBuilder.CreateTable(
                name: "DiveTypePermissions",
                columns: table => new
                {
                    DiveTypePermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiveTypePermissions", x => x.DiveTypePermissionId);
                });

            migrationBuilder.CreateTable(
                name: "DivingEquipmentCategories",
                columns: table => new
                {
                    DivingEquipmentCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingEquipmentCategories", x => x.DivingEquipmentCategory);
                });

            migrationBuilder.CreateTable(
                name: "DivingLaborStatus",
                columns: table => new
                {
                    DivingLaborStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingLaborStatus", x => x.DivingLaborStatusId);
                });

            migrationBuilder.CreateTable(
                name: "DivingTimePeriods",
                columns: table => new
                {
                    DivingTimePeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingTimePeriods", x => x.DivingTimePeriodId);
                });

            migrationBuilder.CreateTable(
                name: "DivingTypeJobs",
                columns: table => new
                {
                    DivingTypeJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingTypeJobs", x => x.DivingTypeJobId);
                });

            migrationBuilder.CreateTable(
                name: "DivingLabors",
                columns: table => new
                {
                    DivingLaborId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(700)", nullable: true),
                    WaveHeight = table.Column<double>(type: "float", nullable: false),
                    WindDirection = table.Column<double>(type: "float", nullable: false),
                    Flowing = table.Column<double>(type: "float", nullable: false),
                    TypeOfPermisionId = table.Column<int>(type: "int", nullable: false),
                    DiveTypePermissionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    DivingLaborStatusId = table.Column<int>(type: "int", nullable: false),
                    CommentReview = table.Column<string>(type: "nvarchar(700)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingLabors", x => x.DivingLaborId);
                    table.ForeignKey(
                        name: "FK_DivingLabors_DiveTypePermissions_DiveTypePermissionId",
                        column: x => x.DiveTypePermissionId,
                        principalTable: "DiveTypePermissions",
                        principalColumn: "DiveTypePermissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivingLabors_DivingLaborStatus_DivingLaborStatusId",
                        column: x => x.DivingLaborStatusId,
                        principalTable: "DivingLaborStatus",
                        principalColumn: "DivingLaborStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivingTypeSubJobs",
                columns: table => new
                {
                    DivingTypeSubJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    DivingTypeJobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingTypeSubJobs", x => x.DivingTypeSubJobId);
                    table.ForeignKey(
                        name: "FK_DivingTypeSubJobs_DivingTypeJobs_DivingTypeJobId",
                        column: x => x.DivingTypeJobId,
                        principalTable: "DivingTypeJobs",
                        principalColumn: "DivingTypeJobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivingActivities",
                columns: table => new
                {
                    DivingActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivingLaborId = table.Column<int>(type: "int", nullable: false),
                    DiverId = table.Column<int>(type: "int", nullable: false),
                    IsBackup = table.Column<bool>(type: "bit", nullable: false),
                    MaxDeep = table.Column<double>(type: "float", nullable: false),
                    DeepGroupId = table.Column<int>(type: "int", nullable: false),
                    DeepTableId = table.Column<int>(type: "int", nullable: false),
                    DivingTimePeriodId = table.Column<int>(type: "int", nullable: false),
                    IsColdWater = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<string>(type: "varchar(5)", nullable: false),
                    EndTime = table.Column<string>(type: "varchar(5)", nullable: false),
                    TotalTime = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingActivities", x => x.DivingActivityId);
                    table.ForeignKey(
                        name: "FK_DivingActivities_DeepGroups_DeepGroupId",
                        column: x => x.DeepGroupId,
                        principalTable: "DeepGroups",
                        principalColumn: "DeepGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivingActivities_DeepTables_DeepTableId",
                        column: x => x.DeepTableId,
                        principalTable: "DeepTables",
                        principalColumn: "DeepTableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivingActivities_Divers_DiverId",
                        column: x => x.DiverId,
                        principalTable: "Divers",
                        principalColumn: "DiverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivingActivities_DivingLabors_DivingLaborId",
                        column: x => x.DivingLaborId,
                        principalTable: "DivingLabors",
                        principalColumn: "DivingLaborId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivingActivities_DivingTimePeriods_DivingTimePeriodId",
                        column: x => x.DivingTimePeriodId,
                        principalTable: "DivingTimePeriods",
                        principalColumn: "DivingTimePeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivingEquipments",
                columns: table => new
                {
                    DivingEquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivingEquipmentCategoryId = table.Column<int>(type: "int", nullable: false),
                    Identifier = table.Column<string>(type: "varchar(60)", nullable: false),
                    DivingActivExpirationTimeityId = table.Column<DateTime>(type: "datetime", nullable: false),
                    DivingLaborId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingEquipments", x => x.DivingEquipmentId);
                    table.ForeignKey(
                        name: "FK_DivingEquipments_DivingEquipmentCategories_DivingEquipmentCategoryId",
                        column: x => x.DivingEquipmentCategoryId,
                        principalTable: "DivingEquipmentCategories",
                        principalColumn: "DivingEquipmentCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivingEquipments_DivingLabors_DivingLaborId",
                        column: x => x.DivingLaborId,
                        principalTable: "DivingLabors",
                        principalColumn: "DivingLaborId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivingActivityDetails",
                columns: table => new
                {
                    DivingActivityDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivingTypeSubJobId = table.Column<int>(type: "int", nullable: false),
                    DivingActivityId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingActivityDetails", x => x.DivingActivityDetailId);
                    table.ForeignKey(
                        name: "FK_DivingActivityDetails_DivingActivities_DivingActivityId",
                        column: x => x.DivingActivityId,
                        principalTable: "DivingActivities",
                        principalColumn: "DivingActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivingActivityDetails_DivingTypeSubJobs_DivingTypeSubJobId",
                        column: x => x.DivingTypeSubJobId,
                        principalTable: "DivingTypeSubJobs",
                        principalColumn: "DivingTypeSubJobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivingEquipmentAssignment",
                columns: table => new
                {
                    DivingEquipmentAssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiverId = table.Column<int>(nullable: false),
                    DivingEquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingEquipmentAssignment", x => x.DivingEquipmentAssignmentId);
                    table.ForeignKey(
                        name: "FK_DivingEquipmentAssignment_Divers_DiverId",
                        column: x => x.DiverId,
                        principalTable: "Divers",
                        principalColumn: "DiverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivingEquipmentAssignment_DivingEquipments_DivingEquipmentId",
                        column: x => x.DivingEquipmentId,
                        principalTable: "DivingEquipments",
                        principalColumn: "DivingEquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivingActivities_DeepGroupId",
                table: "DivingActivities",
                column: "DeepGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingActivities_DeepTableId",
                table: "DivingActivities",
                column: "DeepTableId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingActivities_DiverId",
                table: "DivingActivities",
                column: "DiverId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingActivities_DivingLaborId",
                table: "DivingActivities",
                column: "DivingLaborId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingActivities_DivingTimePeriodId",
                table: "DivingActivities",
                column: "DivingTimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingActivityDetails_DivingActivityId",
                table: "DivingActivityDetails",
                column: "DivingActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingActivityDetails_DivingTypeSubJobId",
                table: "DivingActivityDetails",
                column: "DivingTypeSubJobId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingEquipmentAssignment_DiverId",
                table: "DivingEquipmentAssignment",
                column: "DiverId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingEquipmentAssignment_DivingEquipmentId",
                table: "DivingEquipmentAssignment",
                column: "DivingEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingEquipments_DivingEquipmentCategoryId",
                table: "DivingEquipments",
                column: "DivingEquipmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingEquipments_DivingLaborId",
                table: "DivingEquipments",
                column: "DivingLaborId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingLabors_DiveTypePermissionId",
                table: "DivingLabors",
                column: "DiveTypePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingLabors_DivingLaborStatusId",
                table: "DivingLabors",
                column: "DivingLaborStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingTypeSubJobs_DivingTypeJobId",
                table: "DivingTypeSubJobs",
                column: "DivingTypeJobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DivingActivityDetails");

            migrationBuilder.DropTable(
                name: "DivingEquipmentAssignment");

            migrationBuilder.DropTable(
                name: "DivingActivities");

            migrationBuilder.DropTable(
                name: "DivingTypeSubJobs");

            migrationBuilder.DropTable(
                name: "DivingEquipments");

            migrationBuilder.DropTable(
                name: "DeepGroups");

            migrationBuilder.DropTable(
                name: "DeepTables");

            migrationBuilder.DropTable(
                name: "Divers");

            migrationBuilder.DropTable(
                name: "DivingTimePeriods");

            migrationBuilder.DropTable(
                name: "DivingTypeJobs");

            migrationBuilder.DropTable(
                name: "DivingEquipmentCategories");

            migrationBuilder.DropTable(
                name: "DivingLabors");

            migrationBuilder.DropTable(
                name: "DiveTypePermissions");

            migrationBuilder.DropTable(
                name: "DivingLaborStatus");
        }
    }
}
