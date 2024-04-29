using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removed_validations_of_user_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Picture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PECNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyPhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BloodGroup",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "299b9930-f6b9-44bc-8622-eb1b00920ab0", null, "Sales Agent TBD", "SALES AGENT TBD" },
                    { "36558546-de63-4a4d-b09f-d08290c2302b", null, "Project Manager", "PROJECT MANAGER" },
                    { "4d42721e-374a-4c57-ad77-be3a5d38e240", null, "Sales Leader", "SALES LEADER" },
                    { "4fa4a04e-1c52-4804-b22b-020c613dac68", null, "QTO Estimator MEP", "QTO ESTIMATOR MEP" },
                    { "57f4d783-c194-42a7-94e5-9776ce8218b4", null, "HR Manager", "HR MANAGER" },
                    { "658e1e21-878d-4d54-b805-2e2e9e33cc65", null, "Sales Agent BUILDCROFTTRADING", "SALES AGENT BUILDCROFTTRADING" },
                    { "7367fdc4-6640-44d4-b74a-58bcb98efada", null, "Cost Estimator CIVIL", "COST ESTIMATOR  CIVIL" },
                    { "9fe73299-c6a5-42dc-b23b-c9cf497079ee", null, "QTO Estimator QC", "QTO ESTIMATOR QC" },
                    { "a83c8eed-b7ab-4e75-bd77-300b07a3c37b", null, "Data Entry", "DATA ENTRY" },
                    { "a9e6796c-bd8c-49da-8656-c638862b753d", null, "Cost Estimator MEP", "COST ESTIMATOR MEP" },
                    { "acf9e535-7ab5-4beb-916f-a453264ab351", null, "Sales Agent SUBBIDDING", "SALES AGENT SUBBIDDING" },
                    { "c744b2b8-ca1a-46df-af98-8df78c4d8ecc", null, "Data Manager", "DATA MANAGER" },
                    { "dcc84c08-ea69-41b7-9131-eb6de5b0b3d6", null, "Cost Estimator BOTH", "COST ESTIMATOR BOTH" },
                    { "eb868f87-396b-4716-a054-70dbd45bcd07", null, "QTO Estimator BOTH", "QTO ESTIMATOR BOTH" },
                    { "fc58b8f1-5e36-4fbc-8f7f-d41a9d759b42", null, "QTO Estimator CIVIL", "QTO ESTIMATOR CIVIL" },
                    { "feb0d3f8-2d81-4c9c-aa94-db3d290da21a", null, "Super Admin", "SUPER ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "299b9930-f6b9-44bc-8622-eb1b00920ab0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36558546-de63-4a4d-b09f-d08290c2302b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d42721e-374a-4c57-ad77-be3a5d38e240");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fa4a04e-1c52-4804-b22b-020c613dac68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57f4d783-c194-42a7-94e5-9776ce8218b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "658e1e21-878d-4d54-b805-2e2e9e33cc65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7367fdc4-6640-44d4-b74a-58bcb98efada");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fe73299-c6a5-42dc-b23b-c9cf497079ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a83c8eed-b7ab-4e75-bd77-300b07a3c37b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9e6796c-bd8c-49da-8656-c638862b753d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acf9e535-7ab5-4beb-916f-a453264ab351");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c744b2b8-ca1a-46df-af98-8df78c4d8ecc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcc84c08-ea69-41b7-9131-eb6de5b0b3d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb868f87-396b-4716-a054-70dbd45bcd07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc58b8f1-5e36-4fbc-8f7f-d41a9d759b42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feb0d3f8-2d81-4c9c-aa94-db3d290da21a");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PECNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyPhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodGroup",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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
    }
}
