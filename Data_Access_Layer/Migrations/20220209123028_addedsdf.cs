using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data_Access_Layer.Migrations
{
    public partial class addedsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Posts_ID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CREATED_DATE",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "Posts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "POST_ID",
                table: "Posts",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "SLUG",
                table: "Categories",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Posts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Posts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Posts",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "POST_ID");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Categories",
                newName: "SLUG");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_DATE",
                table: "Posts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Categories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Posts_ID",
                table: "Categories",
                column: "ID",
                principalTable: "Posts",
                principalColumn: "POST_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
