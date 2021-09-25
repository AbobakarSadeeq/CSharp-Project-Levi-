using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ADDUSERADDRESS12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AspNetUsers_User_ID",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Cities_City_ID",
                table: "UserAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress");

            migrationBuilder.RenameTable(
                name: "UserAddress",
                newName: "UserAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_User_ID",
                table: "UserAddresses",
                newName: "IX_UserAddresses_User_ID");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_City_ID",
                table: "UserAddresses",
                newName: "IX_UserAddresses_City_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses",
                column: "UserAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_AspNetUsers_User_ID",
                table: "UserAddresses",
                column: "User_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Cities_City_ID",
                table: "UserAddresses",
                column: "City_ID",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_AspNetUsers_User_ID",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Cities_City_ID",
                table: "UserAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses");

            migrationBuilder.RenameTable(
                name: "UserAddresses",
                newName: "UserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_User_ID",
                table: "UserAddress",
                newName: "IX_UserAddress_User_ID");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_City_ID",
                table: "UserAddress",
                newName: "IX_UserAddress_City_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress",
                column: "UserAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AspNetUsers_User_ID",
                table: "UserAddress",
                column: "User_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Cities_City_ID",
                table: "UserAddress",
                column: "City_ID",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
