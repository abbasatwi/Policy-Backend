using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EffectiveDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PolicyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_PolicyTypes_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "PolicyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    PolicyMemberId = table.Column<int>(type: "int", nullable: false),
                    ClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberClaims_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberClaims_PolicyMembers_PolicyMemberId",
                        column: x => x.PolicyMemberId,
                        principalTable: "PolicyMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyPolicyMember",
                columns: table => new
                {
                    PoliciesId = table.Column<int>(type: "int", nullable: false),
                    PolicyMembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyPolicyMember", x => new { x.PoliciesId, x.PolicyMembersId });
                    table.ForeignKey(
                        name: "FK_PolicyPolicyMember_Policies_PoliciesId",
                        column: x => x.PoliciesId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyPolicyMember_PolicyMembers_PolicyMembersId",
                        column: x => x.PolicyMembersId,
                        principalTable: "PolicyMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberClaims_PolicyId",
                table: "MemberClaims",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberClaims_PolicyMemberId",
                table: "MemberClaims",
                column: "PolicyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PolicyTypeId",
                table: "Policies",
                column: "PolicyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyPolicyMember_PolicyMembersId",
                table: "PolicyPolicyMember",
                column: "PolicyMembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberClaims");

            migrationBuilder.DropTable(
                name: "PolicyPolicyMember");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "PolicyMembers");

            migrationBuilder.DropTable(
                name: "PolicyTypes");
        }
    }
}
