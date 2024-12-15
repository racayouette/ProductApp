using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "57CB9D5740231C0370F4BF587147ADA149392A8B6174EDB69BD92BCDB8D973C8:E227A7D7C0B2E3C0D52C2DB57FC441AE:50000:SHA256");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "47BF37887243A68951D279750A84B77F2CDAE82B447AC99C0B52D33384DF9FB4:B1F8EA2EF18C24E4EA5AF503503C0985:50000:SHA256");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "647C77B2CFFF2BB3BE371DE8864EBAD9195979AF97ECD6DEE47E8A64221D42FC:E53E4331007CB84EF07BC583216DA047:50000:SHA256");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "A0F5D07F914042781B141DB9DB5491371B15597F78D8641868390F08264DB3F0:B8E741E79977323746992497CF68925F:50000:SHA256");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "FE319BE40FD36ED21B4D79246AB5AD6A663D3514585F424E0E0982B15B5E4422:56817F85F6EF291D80120E6641B61327:50000:SHA256");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");
        }
    }
}
