﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api.Domain.Entities.CityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CodIbge")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<Guid>("UfId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CodIbge");

                    b.HasIndex("UfId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Api.Domain.Entities.UfEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("Sigla")
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Sigla")
                        .IsUnique();

                    b.ToTable("Uf");

                    b.HasData(
                        new
                        {
                            Id = new Guid("febd2afb-f005-4fc9-b2de-f602db3dbcf2"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9131),
                            Name = "Acre",
                            Sigla = "AC"
                        },
                        new
                        {
                            Id = new Guid("8af66fac-98c0-4f6a-9ec1-8dcfc03229be"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9368),
                            Name = "Alagoas",
                            Sigla = "AL"
                        },
                        new
                        {
                            Id = new Guid("34bc544e-2499-4719-92db-988e6679b7e2"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9380),
                            Name = "Amapá",
                            Sigla = "AP"
                        },
                        new
                        {
                            Id = new Guid("6032b43f-7975-41cc-8ab6-f58cbdcdab6d"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9391),
                            Name = "Amazonas",
                            Sigla = "AM"
                        },
                        new
                        {
                            Id = new Guid("284473ab-b36d-40e3-8422-0205d9af7c91"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9401),
                            Name = "Bahia",
                            Sigla = "BA"
                        },
                        new
                        {
                            Id = new Guid("83ccb241-6bac-4943-b7a7-44027b2a9560"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9410),
                            Name = "Ceará",
                            Sigla = "CE"
                        },
                        new
                        {
                            Id = new Guid("9b1e1cc4-52c6-49e7-b544-61479bbc3d89"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9420),
                            Name = "Distrito Federal",
                            Sigla = "DF"
                        },
                        new
                        {
                            Id = new Guid("2be6a1a6-6ac3-4489-b519-7c5f3f25c5fd"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9433),
                            Name = "Espírito Santo",
                            Sigla = "ES"
                        },
                        new
                        {
                            Id = new Guid("0d167bcd-1801-4c1e-bdf3-74325f9bccb5"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9463),
                            Name = "Goiás",
                            Sigla = "GO"
                        },
                        new
                        {
                            Id = new Guid("7b8f2735-5d6f-4d87-8406-b6ab0d77ca3d"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9472),
                            Name = "Maranhão",
                            Sigla = "MA"
                        },
                        new
                        {
                            Id = new Guid("b39bea83-a0ad-4af6-a1c8-e0c36caeb526"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9481),
                            Name = "Mato Grosso",
                            Sigla = "MT"
                        },
                        new
                        {
                            Id = new Guid("df3ca68f-a964-4793-8749-b9bde470d297"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9490),
                            Name = "Mato Grosso do Sul",
                            Sigla = "MS"
                        },
                        new
                        {
                            Id = new Guid("7dad2d60-20cb-4547-9866-4a5aeb3004c0"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9499),
                            Name = "Minas Gerais",
                            Sigla = "MG"
                        },
                        new
                        {
                            Id = new Guid("9da685b8-8030-46ad-b8b2-9916b51754fc"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9506),
                            Name = "Pará",
                            Sigla = "PA"
                        },
                        new
                        {
                            Id = new Guid("074a1c90-e4ba-44f2-903a-5605fc8f8378"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9514),
                            Name = "Paraíba",
                            Sigla = "PB"
                        },
                        new
                        {
                            Id = new Guid("65663f69-d83d-4e4b-8740-0447de3d4197"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9522),
                            Name = "Paraná",
                            Sigla = "PR"
                        },
                        new
                        {
                            Id = new Guid("9bfcdf5f-f93b-48a6-9d69-d5f85dc7abd7"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9540),
                            Name = "Pernambuco",
                            Sigla = "PE"
                        },
                        new
                        {
                            Id = new Guid("fc7b3b78-e56a-45fd-abd4-3e537938bb5b"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9551),
                            Name = "Piauí",
                            Sigla = "PI"
                        },
                        new
                        {
                            Id = new Guid("9b863d2c-0cfa-4ad8-9cb3-deac2fa7730a"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9559),
                            Name = "Rio de Janeiro",
                            Sigla = "RJ"
                        },
                        new
                        {
                            Id = new Guid("50658783-90d2-4c68-a8c7-650e1ef6c626"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9568),
                            Name = "Rio Grande do Norte",
                            Sigla = "RN"
                        },
                        new
                        {
                            Id = new Guid("a5f38537-5019-4ebe-8885-8b196b7b0a17"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9576),
                            Name = "Rio Grande do Sul",
                            Sigla = "RS"
                        },
                        new
                        {
                            Id = new Guid("a9b097d9-34ef-4a3a-bfa2-54ae9c92366f"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9584),
                            Name = "Rondônia",
                            Sigla = "RO"
                        },
                        new
                        {
                            Id = new Guid("606adfed-6608-4d51-b880-5bf8eccbcd15"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9592),
                            Name = "Roraima",
                            Sigla = "RR"
                        },
                        new
                        {
                            Id = new Guid("c8211958-2df3-4a95-95f6-df5f3084b411"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9600),
                            Name = "Santa Catarina",
                            Sigla = "SC"
                        },
                        new
                        {
                            Id = new Guid("3b4dacd6-9ff1-4e70-9796-4142503d701e"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9617),
                            Name = "São Paulo",
                            Sigla = "SP"
                        },
                        new
                        {
                            Id = new Guid("5a8ace30-13b7-4aa6-9164-ca52f715dc65"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9626),
                            Name = "Sergipe",
                            Sigla = "SE"
                        },
                        new
                        {
                            Id = new Guid("c415fff7-779b-4a4b-9b58-d5483e5cf2cc"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9633),
                            Name = "Tocantins",
                            Sigla = "TO"
                        },
                        new
                        {
                            Id = new Guid("9e8776e9-5948-4843-8c82-ae203c1bbe64"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 370, DateTimeKind.Local).AddTicks(9642),
                            Name = "Espírito Santo",
                            Sigla = "ES"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("20f55a69-057e-4497-8562-92ae069e7359"),
                            CreatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 346, DateTimeKind.Local).AddTicks(9836),
                            Email = "wendreadm@gmail.com",
                            Name = "Administrator",
                            UpdatedAt = new DateTime(2022, 7, 18, 20, 56, 36, 350, DateTimeKind.Local).AddTicks(5493)
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.ZipCodeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Number")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ZipCode");

                    b.ToTable("ZipCode");
                });

            modelBuilder.Entity("Api.Domain.Entities.CityEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.UfEntity", "Uf")
                        .WithMany("Cities")
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Domain.Entities.ZipCodeEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.CityEntity", "City")
                        .WithMany("ZipCodes")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
