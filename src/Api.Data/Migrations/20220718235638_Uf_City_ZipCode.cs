using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Uf_City_ZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uf",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Sigla = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    CodIbge = table.Column<int>(nullable: false),
                    UfId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Uf_UfId",
                        column: x => x.UfId,
                        principalTable: "Uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZipCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 60, nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: true),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZipCode_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Uf",
                columns: new[] { "Id", "CreatedAt", "Name", "Sigla", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("febd2afb-f005-4fc9-b2de-f602db3dbcf2"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9131), "Acre", "AC", null },
                    { new Guid("c415fff7-779b-4a4b-9b58-d5483e5cf2cc"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9633), "Tocantins", "TO", null },
                    { new Guid("5a8ace30-13b7-4aa6-9164-ca52f715dc65"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9626), "Sergipe", "SE", null },
                    { new Guid("3b4dacd6-9ff1-4e70-9796-4142503d701e"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9617), "São Paulo", "SP", null },
                    { new Guid("c8211958-2df3-4a95-95f6-df5f3084b411"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9600), "Santa Catarina", "SC", null },
                    { new Guid("606adfed-6608-4d51-b880-5bf8eccbcd15"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9592), "Roraima", "RR", null },
                    { new Guid("a9b097d9-34ef-4a3a-bfa2-54ae9c92366f"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9584), "Rondônia", "RO", null },
                    { new Guid("a5f38537-5019-4ebe-8885-8b196b7b0a17"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9576), "Rio Grande do Sul", "RS", null },
                    { new Guid("50658783-90d2-4c68-a8c7-650e1ef6c626"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9568), "Rio Grande do Norte", "RN", null },
                    { new Guid("9b863d2c-0cfa-4ad8-9cb3-deac2fa7730a"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9559), "Rio de Janeiro", "RJ", null },
                    { new Guid("fc7b3b78-e56a-45fd-abd4-3e537938bb5b"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9551), "Piauí", "PI", null },
                    { new Guid("9bfcdf5f-f93b-48a6-9d69-d5f85dc7abd7"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9540), "Pernambuco", "PE", null },
                    { new Guid("65663f69-d83d-4e4b-8740-0447de3d4197"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9522), "Paraná", "PR", null },
                    { new Guid("9e8776e9-5948-4843-8c82-ae203c1bbe64"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9642), "Espírito Santo", "ES", null },
                    { new Guid("074a1c90-e4ba-44f2-903a-5605fc8f8378"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9514), "Paraíba", "PB", null },
                    { new Guid("7dad2d60-20cb-4547-9866-4a5aeb3004c0"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9499), "Minas Gerais", "MG", null },
                    { new Guid("df3ca68f-a964-4793-8749-b9bde470d297"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9490), "Mato Grosso do Sul", "MS", null },
                    { new Guid("b39bea83-a0ad-4af6-a1c8-e0c36caeb526"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9481), "Mato Grosso", "MT", null },
                    { new Guid("7b8f2735-5d6f-4d87-8406-b6ab0d77ca3d"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9472), "Maranhão", "MA", null },
                    { new Guid("0d167bcd-1801-4c1e-bdf3-74325f9bccb5"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9463), "Goiás", "GO", null },
                    { new Guid("2be6a1a6-6ac3-4489-b519-7c5f3f25c5fd"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9433), "Espírito Santo", "ES", null },
                    { new Guid("9b1e1cc4-52c6-49e7-b544-61479bbc3d89"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9420), "Distrito Federal", "DF", null },
                    { new Guid("83ccb241-6bac-4943-b7a7-44027b2a9560"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9410), "Ceará", "CE", null },
                    { new Guid("284473ab-b36d-40e3-8422-0205d9af7c91"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9401), "Bahia", "BA", null },
                    { new Guid("6032b43f-7975-41cc-8ab6-f58cbdcdab6d"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9391), "Amazonas", "AM", null },
                    { new Guid("34bc544e-2499-4719-92db-988e6679b7e2"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9380), "Amapá", "AP", null },
                    { new Guid("8af66fac-98c0-4f6a-9ec1-8dcfc03229be"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9368), "Alagoas", "AL", null },
                    { new Guid("9da685b8-8030-46ad-b8b2-9916b51754fc"), new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9506), "Pará", "PA", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "UpdatedAt" },
                values: new object[] { new Guid("20f55a69-057e-4497-8562-92ae069e7359"), new DateTime(2022, 7, 18, 20, 56, 36, 346, DateTimeKind.Local).AddTicks(9836), "wendreadm@gmail.com", "Administrator", new DateTime(2022, 7, 18, 20, 56, 36, 350, DateTimeKind.Local).AddTicks(5493) });

            migrationBuilder.CreateIndex(
                name: "IX_City_CodIbge",
                table: "City",
                column: "CodIbge");

            migrationBuilder.CreateIndex(
                name: "IX_City_UfId",
                table: "City",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_Uf_Sigla",
                table: "Uf",
                column: "Sigla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_CityId",
                table: "ZipCode",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_ZipCode",
                table: "ZipCode",
                column: "ZipCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZipCode");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Uf");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("20f55a69-057e-4497-8562-92ae069e7359"));
        }
    }
}
