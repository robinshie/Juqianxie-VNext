using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrainagetubeService.Infrastructure.Migrations
{
    public partial class addliquireportr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrainageLiquidReporters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HospitalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurgicalMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TubType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiquidColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiquidProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Liquidodour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TubeState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volum = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrainageLiquidReporters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrainageUserReporters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uid = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HospitalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurgicalMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TubType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrainageUserReporters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_DrainageLiquid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiquidColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiquidProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Liquidodour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TubeState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    TubeKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uid = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_DrainageLiquid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Drainagetube",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TubeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TubePosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TubeExtention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Drainagetube", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrainageLiquidReporters");

            migrationBuilder.DropTable(
                name: "DrainageUserReporters");

            migrationBuilder.DropTable(
                name: "T_DrainageLiquid");

            migrationBuilder.DropTable(
                name: "T_Drainagetube");
        }
    }
}
