using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OrderAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 19, 13, 58, 35, 929, DateTimeKind.Local).AddTicks(4603), new DateTime(2021, 12, 19, 13, 58, 35, 929, DateTimeKind.Local).AddTicks(4615) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 19, 13, 58, 35, 929, DateTimeKind.Local).AddTicks(5072), new DateTime(2021, 12, 19, 13, 58, 35, 929, DateTimeKind.Local).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 19, 13, 58, 35, 929, DateTimeKind.Local).AddTicks(5078), new DateTime(2021, 12, 19, 13, 58, 35, 929, DateTimeKind.Local).AddTicks(5079) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 19, 13, 58, 35, 929, DateTimeKind.Local).AddTicks(5080), new DateTime(2021, 12, 19, 13, 58, 35, 929, DateTimeKind.Local).AddTicks(5081) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 19, 13, 58, 35, 926, DateTimeKind.Local).AddTicks(2377), new DateTime(2021, 12, 19, 13, 58, 35, 927, DateTimeKind.Local).AddTicks(2298) });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 18, 16, 4, 34, 973, DateTimeKind.Local).AddTicks(6387), new DateTime(2021, 12, 18, 16, 4, 34, 973, DateTimeKind.Local).AddTicks(6401) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 18, 16, 4, 34, 973, DateTimeKind.Local).AddTicks(6816), new DateTime(2021, 12, 18, 16, 4, 34, 973, DateTimeKind.Local).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 18, 16, 4, 34, 973, DateTimeKind.Local).AddTicks(6823), new DateTime(2021, 12, 18, 16, 4, 34, 973, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 18, 16, 4, 34, 973, DateTimeKind.Local).AddTicks(6826), new DateTime(2021, 12, 18, 16, 4, 34, 973, DateTimeKind.Local).AddTicks(6827) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 18, 16, 4, 34, 970, DateTimeKind.Local).AddTicks(2455), new DateTime(2021, 12, 18, 16, 4, 34, 971, DateTimeKind.Local).AddTicks(2723) });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
