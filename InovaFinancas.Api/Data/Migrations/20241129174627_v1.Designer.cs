﻿// <auto-generated />
using System;
using InovaFinancas.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InovaFinancas.Api.Migrations
{
    [DbContext(typeof(AppDbConext))]
    [Migration("20241129174627_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InovaFinancas.Core.Models.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("InovaFinancas.Core.Models.Transacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoriaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataRecebimento")
                        .HasColumnType("datetime2");

                    b.Property<short>("Tipo")
                        .HasColumnType("SMALLINT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("Valor")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Transacao", (string)null);
                });

            modelBuilder.Entity("InovaFinancas.Core.Models.Transacao", b =>
                {
                    b.HasOne("InovaFinancas.Core.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
