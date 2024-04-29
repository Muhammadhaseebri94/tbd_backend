using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_user_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01915553-d334-403d-a39a-8775d6e9d689");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0613a9cf-c5ba-48ce-9165-7f96bd8bde5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07419b38-de4b-4ed7-a7b9-fa64599e0968");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bdf5bb9-aa09-426c-8c77-89e36f8ed441");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c18aa08-407b-4b52-a3c8-5a9c5ccf44a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304b5724-3ae1-4f2e-b6a5-eb77f4895f54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "390446d0-84f3-4a44-993a-582ae2b4d8f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "462898df-763a-44ab-860c-5a6803dfc482");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "577896ef-e3e3-4446-9fae-a0f6b4f841da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "831a2a27-a604-44ca-af67-b2dd41914d14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d9dadc2-149f-4ce1-97ba-47cf078550d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e337624-d77d-4eb6-ac94-32d5602b8199");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaaea76c-a440-491e-a7b1-3ce85ec653ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c436f2a0-5665-4e3d-981b-696a5783fd15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8e3fd50-f94f-442a-80db-a1d0e0a02216");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e41e607d-fd79-42ff-bcc2-c144cd0516ad");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29f417bb-9de0-4403-8b44-107e365dedb0", null, "Super Admin", "SUPER ADMIN" },
                    { "364e2a2a-b67c-4c3c-a62e-9a4c2477431f", null, "Cost Estimator CIVIL", "COST ESTIMATOR  CIVIL" },
                    { "4d3ef0b3-ab9a-42ae-8b55-e97e7fee66a2", null, "QTO Estimator MEP", "QTO ESTIMATOR MEP" },
                    { "4d765cef-0990-4d9e-a7db-034b4ae9cbc0", null, "Cost Estimator BOTH", "COST ESTIMATOR BOTH" },
                    { "6ba1715f-9bde-4220-a7ef-c6b4f6e04e07", null, "Sales Agent BUILDCROFTTRADING", "SALES AGENT BUILDCROFTTRADING" },
                    { "7545d684-9da5-419a-b9d2-78bc2096571d", null, "Sales Agent SUBBIDDING", "SALES AGENT SUBBIDDING" },
                    { "798e28f2-830b-4963-8bdc-3dfaf8fa2390", null, "Project Manager", "PROJECT MANAGER" },
                    { "9d24306a-ec95-4633-9d70-658d217a6823", null, "QTO Estimator CIVIL", "QTO ESTIMATOR CIVIL" },
                    { "ace4f03c-6e29-4d04-8b02-46e5076e4a6b", null, "Sales Leader", "SALES LEADER" },
                    { "ad1d0bfb-4cf7-4bf3-a960-358e949bfa15", null, "QTO Estimator BOTH", "QTO ESTIMATOR BOTH" },
                    { "af8bf6a6-1a8b-4758-ae41-8a0a0c10dc86", null, "HR Manager", "HR MANAGER" },
                    { "cdaee46c-be88-4797-be07-163dae1913d3", null, "QTO Estimator QC", "QTO ESTIMATOR QC" },
                    { "ee161847-4cd7-441d-8b07-8571358f52ec", null, "Data Manager", "DATA MANAGER" },
                    { "f49fb901-b7b5-4d79-aaed-f57bc1967db6", null, "Sales Agent TBD", "SALES AGENT TBD" },
                    { "f784e25c-fc99-4632-a3aa-236c285d409e", null, "Data Entry", "DATA ENTRY" },
                    { "ff28365a-7be9-4bf6-acce-9dbbb9a638be", null, "Cost Estimator MEP", "COST ESTIMATOR MEP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29f417bb-9de0-4403-8b44-107e365dedb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "364e2a2a-b67c-4c3c-a62e-9a4c2477431f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3ef0b3-ab9a-42ae-8b55-e97e7fee66a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d765cef-0990-4d9e-a7db-034b4ae9cbc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ba1715f-9bde-4220-a7ef-c6b4f6e04e07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7545d684-9da5-419a-b9d2-78bc2096571d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798e28f2-830b-4963-8bdc-3dfaf8fa2390");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d24306a-ec95-4633-9d70-658d217a6823");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace4f03c-6e29-4d04-8b02-46e5076e4a6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad1d0bfb-4cf7-4bf3-a960-358e949bfa15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af8bf6a6-1a8b-4758-ae41-8a0a0c10dc86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdaee46c-be88-4797-be07-163dae1913d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee161847-4cd7-441d-8b07-8571358f52ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f49fb901-b7b5-4d79-aaed-f57bc1967db6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f784e25c-fc99-4632-a3aa-236c285d409e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff28365a-7be9-4bf6-acce-9dbbb9a638be");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01915553-d334-403d-a39a-8775d6e9d689", null, "Cost Estimator CIVIL", "COST ESTIMATOR  CIVIL" },
                    { "0613a9cf-c5ba-48ce-9165-7f96bd8bde5e", null, "Sales Agent BUILDCROFTTRADING", "SALES AGENT BUILDCROFTTRADING" },
                    { "07419b38-de4b-4ed7-a7b9-fa64599e0968", null, "Cost Estimator MEP", "COST ESTIMATOR MEP" },
                    { "1bdf5bb9-aa09-426c-8c77-89e36f8ed441", null, "Sales Agent TBD", "SALES AGENT TBD" },
                    { "1c18aa08-407b-4b52-a3c8-5a9c5ccf44a7", null, "QTO Estimator MEP", "QTO ESTIMATOR MEP" },
                    { "304b5724-3ae1-4f2e-b6a5-eb77f4895f54", null, "Sales Agent SUBBIDDING", "SALES AGENT SUBBIDDING" },
                    { "390446d0-84f3-4a44-993a-582ae2b4d8f7", null, "Data Manager", "DATA MANAGER" },
                    { "462898df-763a-44ab-860c-5a6803dfc482", null, "Data Entry", "DATA ENTRY" },
                    { "577896ef-e3e3-4446-9fae-a0f6b4f841da", null, "QTO Estimator CIVIL", "QTO ESTIMATOR CIVIL" },
                    { "831a2a27-a604-44ca-af67-b2dd41914d14", null, "Sales Leader", "SALES LEADER" },
                    { "9d9dadc2-149f-4ce1-97ba-47cf078550d5", null, "HR Manager", "HR MANAGER" },
                    { "9e337624-d77d-4eb6-ac94-32d5602b8199", null, "Project Manager", "PROJECT MANAGER" },
                    { "aaaea76c-a440-491e-a7b1-3ce85ec653ec", null, "QTO Estimator QC", "QTO ESTIMATOR QC" },
                    { "c436f2a0-5665-4e3d-981b-696a5783fd15", null, "Super Admin", "SUPER ADMIN" },
                    { "c8e3fd50-f94f-442a-80db-a1d0e0a02216", null, "Cost Estimator BOTH", "COST ESTIMATOR BOTH" },
                    { "e41e607d-fd79-42ff-bcc2-c144cd0516ad", null, "QTO Estimator BOTH", "QTO ESTIMATOR BOTH" }
                });
        }
    }
}
