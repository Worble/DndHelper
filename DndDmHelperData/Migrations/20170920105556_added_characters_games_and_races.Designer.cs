﻿// <auto-generated />
using DndDmHelperData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DndDmHelperData.Migrations
{
    [DbContext(typeof(DndDmHelperContext))]
    [Migration("20170920105556_added_characters_games_and_races")]
    partial class added_characters_games_and_races
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("DndDmHelperData.Entities.Class", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("EditedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("DndDmHelperData.Entities.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EditedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OwnerID");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DndDmHelperData.Entities.GameCharacter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassID");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EditedDate");

                    b.Property<int>("GameID");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RaceID");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("GameID");

                    b.HasIndex("RaceID");

                    b.ToTable("GameCharacters");
                });

            modelBuilder.Entity("DndDmHelperData.Entities.Race", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("EditedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("DndDmHelperData.Entities.TemplateCharacter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassID");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EditedDate");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RaceID");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("RaceID");

                    b.ToTable("TemplateCharacters");
                });

            modelBuilder.Entity("DndDmHelperData.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("EditedDate");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DndDmHelperData.Entities.Game", b =>
                {
                    b.HasOne("DndDmHelperData.Entities.User", "Owner")
                        .WithMany("Games")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DndDmHelperData.Entities.GameCharacter", b =>
                {
                    b.HasOne("DndDmHelperData.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DndDmHelperData.Entities.Game", "Game")
                        .WithMany("Characters")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DndDmHelperData.Entities.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DndDmHelperData.Entities.TemplateCharacter", b =>
                {
                    b.HasOne("DndDmHelperData.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DndDmHelperData.Entities.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}