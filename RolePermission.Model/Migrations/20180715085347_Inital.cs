using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RolePermission.Model.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMFIELD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MYTEXTS = table.Column<string>(maxLength: 50, nullable: false),
                    PARENTID = table.Column<int>(maxLength: 36, nullable: true),
                    MYTABLES = table.Column<string>(maxLength: 50, nullable: true),
                    MYCOLUMS = table.Column<string>(maxLength: 50, nullable: true),
                    SORT = table.Column<decimal>(nullable: true),
                    REMARK = table.Column<string>(maxLength: 200, nullable: true),
                    CREATETIME = table.Column<DateTime>(nullable: true),
                    CREATEPERSON = table.Column<string>(maxLength: 50, nullable: true),
                    UPDATETIME = table.Column<DateTime>(nullable: true),
                    UPDATEPERSON = table.Column<string>(maxLength: 50, nullable: true),
                    MYVALUES = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMFIELD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMFIELD_SMFIELD_PARENTID",
                        column: x => x.PARENTID,
                        principalTable: "SMFIELD",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMFUNCTB",
                columns: table => new
                {
                    FUNC_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FUNC_CODE = table.Column<string>(nullable: true),
                    FUNC_NAME = table.Column<string>(nullable: true),
                    EVENT_NAME = table.Column<string>(nullable: true),
                    STATUS = table.Column<string>(nullable: true),
                    PARENTFUNC_CODE = table.Column<string>(nullable: true),
                    CLASS_NAME = table.Column<string>(nullable: true),
                    ORDERCODE = table.Column<int>(nullable: true),
                    SM_SYSTEM = table.Column<string>(nullable: true),
                    ICONIC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMFUNCTB", x => x.FUNC_ID);
                });

            migrationBuilder.CreateTable(
                name: "SMMENUTB",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 200, nullable: false),
                    PARENTID = table.Column<int>(nullable: true),
                    URL = table.Column<string>(maxLength: 200, nullable: true),
                    ICONIC = table.Column<string>(maxLength: 200, nullable: true),
                    SORT = table.Column<int>(nullable: true),
                    REMARK = table.Column<string>(maxLength: 4000, nullable: true),
                    STATE = table.Column<string>(maxLength: 200, nullable: true),
                    CREATEPERSON = table.Column<string>(maxLength: 200, nullable: true),
                    CREATETIME = table.Column<DateTime>(nullable: true),
                    UPDATETIME = table.Column<DateTime>(nullable: true),
                    UPDATEPERSON = table.Column<string>(maxLength: 200, nullable: true),
                    ISLEAF = table.Column<string>(maxLength: 20, nullable: true),
                    MENULEVEL = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMMENUTB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMMENUTB_SMMENUTB_PARENTID",
                        column: x => x.PARENTID,
                        principalTable: "SMMENUTB",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMUSERTB",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    U_ID = table.Column<string>(maxLength: 20, nullable: false),
                    U_PASSWORD = table.Column<string>(maxLength: 200, nullable: false),
                    GENDER = table.Column<string>(maxLength: 2, nullable: true),
                    USER_NAME = table.Column<string>(maxLength: 20, nullable: true),
                    CREATION_TIME = table.Column<DateTime>(nullable: true),
                    CREATION_USER = table.Column<int>(nullable: true),
                    UPDATE_TIME = table.Column<DateTime>(nullable: true),
                    UPDATE_USER = table.Column<int>(nullable: true),
                    STATUS = table.Column<string>(nullable: false),
                    COMPONENT_ID = table.Column<int>(nullable: true),
                    ISAUDIT = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMUSERTB", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_SMUSERTB_SMUSERTB_CREATION_USER",
                        column: x => x.CREATION_USER,
                        principalTable: "SMUSERTB",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMUSERTB_SMUSERTB_UPDATE_USER",
                        column: x => x.UPDATE_USER,
                        principalTable: "SMUSERTB",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuFunc",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    FuncId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuFunc", x => new { x.MenuId, x.FuncId });
                    table.ForeignKey(
                        name: "FK_MenuFunc_SMFUNCTB_FuncId",
                        column: x => x.FuncId,
                        principalTable: "SMFUNCTB",
                        principalColumn: "FUNC_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuFunc_SMMENUTB_MenuId",
                        column: x => x.MenuId,
                        principalTable: "SMMENUTB",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMLOG",
                columns: table => new
                {
                    LOG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LOG_DATETIME = table.Column<DateTime>(nullable: true),
                    USER_ID = table.Column<int>(nullable: true),
                    FUNC_CODE = table.Column<string>(maxLength: 32, nullable: true),
                    OPERATION_TYPE = table.Column<string>(nullable: true),
                    REMARK = table.Column<string>(maxLength: 4000, nullable: true),
                    CLASSNAME = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMLOG", x => x.LOG_ID);
                    table.ForeignKey(
                        name: "FK_SMLOG_SMUSERTB_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "SMUSERTB",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMROLETB",
                columns: table => new
                {
                    ROLE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ROLE_NAME = table.Column<string>(maxLength: 20, nullable: false),
                    CREATION_TIME = table.Column<DateTime>(nullable: true),
                    CREATION_USER = table.Column<int>(nullable: true),
                    UPDATE_TIME = table.Column<DateTime>(nullable: true),
                    UPDATE_USER = table.Column<int>(nullable: true),
                    REMARK = table.Column<string>(maxLength: 100, nullable: true),
                    STATUS = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMROLETB", x => x.ROLE_ID);
                    table.ForeignKey(
                        name: "FK_SMROLETB_SMUSERTB_CREATION_USER",
                        column: x => x.CREATION_USER,
                        principalTable: "SMUSERTB",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMROLETB_SMUSERTB_UPDATE_USER",
                        column: x => x.UPDATE_USER,
                        principalTable: "SMUSERTB",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMMENUROLEFUNCTB",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MENUID = table.Column<int>(nullable: true),
                    FUNC_ID = table.Column<int>(nullable: true),
                    ROLEID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMMENUROLEFUNCTB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMMENUROLEFUNCTB_SMFUNCTB_FUNC_ID",
                        column: x => x.FUNC_ID,
                        principalTable: "SMFUNCTB",
                        principalColumn: "FUNC_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMMENUROLEFUNCTB_SMMENUTB_MENUID",
                        column: x => x.MENUID,
                        principalTable: "SMMENUTB",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMMENUROLEFUNCTB_SMROLETB_ROLEID",
                        column: x => x.ROLEID,
                        principalTable: "SMROLETB",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_SMROLETB_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SMROLETB",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_SMUSERTB_UserId",
                        column: x => x.UserId,
                        principalTable: "SMUSERTB",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuFunc_FuncId",
                table: "MenuFunc",
                column: "FuncId");

            migrationBuilder.CreateIndex(
                name: "IX_SMFIELD_PARENTID",
                table: "SMFIELD",
                column: "PARENTID");

            migrationBuilder.CreateIndex(
                name: "IX_SMLOG_USER_ID",
                table: "SMLOG",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SMMENUROLEFUNCTB_FUNC_ID",
                table: "SMMENUROLEFUNCTB",
                column: "FUNC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SMMENUROLEFUNCTB_MENUID",
                table: "SMMENUROLEFUNCTB",
                column: "MENUID");

            migrationBuilder.CreateIndex(
                name: "IX_SMMENUROLEFUNCTB_ROLEID",
                table: "SMMENUROLEFUNCTB",
                column: "ROLEID");

            migrationBuilder.CreateIndex(
                name: "IX_SMMENUTB_PARENTID",
                table: "SMMENUTB",
                column: "PARENTID");

            migrationBuilder.CreateIndex(
                name: "IX_SMROLETB_CREATION_USER",
                table: "SMROLETB",
                column: "CREATION_USER");

            migrationBuilder.CreateIndex(
                name: "IX_SMROLETB_UPDATE_USER",
                table: "SMROLETB",
                column: "UPDATE_USER");

            migrationBuilder.CreateIndex(
                name: "IX_SMUSERTB_CREATION_USER",
                table: "SMUSERTB",
                column: "CREATION_USER");

            migrationBuilder.CreateIndex(
                name: "IX_SMUSERTB_UPDATE_USER",
                table: "SMUSERTB",
                column: "UPDATE_USER");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuFunc");

            migrationBuilder.DropTable(
                name: "SMFIELD");

            migrationBuilder.DropTable(
                name: "SMLOG");

            migrationBuilder.DropTable(
                name: "SMMENUROLEFUNCTB");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "SMFUNCTB");

            migrationBuilder.DropTable(
                name: "SMMENUTB");

            migrationBuilder.DropTable(
                name: "SMROLETB");

            migrationBuilder.DropTable(
                name: "SMUSERTB");
        }
    }
}
