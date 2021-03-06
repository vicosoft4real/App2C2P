﻿// <auto-generated />
using System;
using App2c2pTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App2c2pTest.Data.Migrations
{
    [DbContext(typeof(App2c2pContext))]
    [Migration("20181010083644_Card_length_updated")]
    partial class Card_length_updated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App2c2pTest.Data.Entites.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasMaxLength(19);

                    b.Property<string>("CardDescription");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("ExpiryDate")
                        .HasMaxLength(6);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });
#pragma warning restore 612, 618
        }
    }
}
