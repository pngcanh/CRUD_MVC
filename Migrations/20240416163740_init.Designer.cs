﻿// <auto-generated />
using System;
using BlogMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogMVC.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20240416163740_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogMVC.Models.ArticlesModel", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleID"));

                    b.Property<int>("AuID")
                        .HasColumnType("int");

                    b.Property<int>("CateID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasKey("ArticleID");

                    b.HasIndex("AuID");

                    b.HasIndex("CateID");

                    b.ToTable("articles");
                });

            modelBuilder.Entity("BlogMVC.Models.AuthorsModle", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Char");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.HasKey("AuthorID");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("BlogMVC.Models.CategoriesModel", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("ntext");

                    b.HasKey("CategoryID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("BlogMVC.Models.ArticlesModel", b =>
                {
                    b.HasOne("BlogMVC.Models.AuthorsModle", "AuthorID")
                        .WithMany()
                        .HasForeignKey("AuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogMVC.Models.CategoriesModel", "CategoriesID")
                        .WithMany()
                        .HasForeignKey("CateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorID");

                    b.Navigation("CategoriesID");
                });
#pragma warning restore 612, 618
        }
    }
}
