﻿// <auto-generated />
using System;
using ToDoAppTemplate.Data.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToDoAppTemplate.Data.Infrastructure.EF;

#nullable disable

namespace ToDoAppTemplate.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240121110228_AddPasswordResetCodes")]
    partial class AddPasswordResetCodes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ToDoAppTemplate.Domain.Todos.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_completed");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("DateUpdated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_updated")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)")
                        .HasColumnName("description");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean")
                        .HasColumnName("is_complete");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("owner_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_todos");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_todos_is_deleted");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_todos_owner_id");

                    b.ToTable("Todos", (string)null);
                });

            modelBuilder.Entity("ToDoAppTemplate.Domain.Users.PasswordResetCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("code");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("DateUpdated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_updated")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean")
                        .HasColumnName("is_used");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_password_reset_codes");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_password_reset_codes_is_deleted");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_password_reset_codes_user_id");

                    b.ToTable("PasswordResetCodes", (string)null);
                });

            modelBuilder.Entity("ToDoAppTemplate.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("DateUpdated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_updated")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("email");

                    b.Property<bool>("IsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_blocked");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_users_is_deleted");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ToDoAppTemplate.Domain.Todos.Todo", b =>
                {
                    b.HasOne("ToDoAppTemplate.Domain.Users.User", "Owner")
                        .WithMany("Todos")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_todos_user_owner_id");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ToDoAppTemplate.Domain.Users.PasswordResetCode", b =>
                {
                    b.HasOne("ToDoAppTemplate.Domain.Users.User", "User")
                        .WithMany("PasswordResetCodes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_password_reset_codes_user_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDoAppTemplate.Domain.Users.User", b =>
                {
                    b.Navigation("PasswordResetCodes");

                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
