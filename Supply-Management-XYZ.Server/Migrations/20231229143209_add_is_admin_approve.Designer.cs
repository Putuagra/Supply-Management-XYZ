﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Supply_Management_XYZ.Server.Data;

#nullable disable

namespace Supply_Management_XYZ.Server.Migrations
{
    [DbContext(typeof(SupplyManagementDbContext))]
    [Migration("20231229143209_add_is_admin_approve")]
    partial class add_is_admin_approve
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Account", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.AccountRole", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("account_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("role_guid");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid");

                    b.HasIndex("RoleGuid");

                    b.ToTable("tb_tr_account_roles");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.AccountVendor", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_account_vendors");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Employee", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.HasKey("Guid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Project", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<Guid>("VendorGuid")
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("vendor_guid");

                    b.HasKey("Guid");

                    b.HasIndex("VendorGuid");

                    b.ToTable("tb_m_projects");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Role", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Vendor", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsAdminApprove")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_admin_approve");

                    b.Property<bool>("IsManagerApprove")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_manager_approve");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("vendor_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("PhotoProfile")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("photo_profile");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("sector");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("type");

                    b.HasKey("Guid");

                    b.HasIndex("Email", "PhoneNumber")
                        .IsUnique();

                    b.ToTable("tb_m_vendors");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Account", b =>
                {
                    b.HasOne("Supply_Management_XYZ.Server.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("Supply_Management_XYZ.Server.Models.Account", "Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.AccountRole", b =>
                {
                    b.HasOne("Supply_Management_XYZ.Server.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supply_Management_XYZ.Server.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.AccountVendor", b =>
                {
                    b.HasOne("Supply_Management_XYZ.Server.Models.Vendor", "Vendor")
                        .WithOne("AccountVendor")
                        .HasForeignKey("Supply_Management_XYZ.Server.Models.AccountVendor", "Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Project", b =>
                {
                    b.HasOne("Supply_Management_XYZ.Server.Models.Vendor", "Vendor")
                        .WithMany("Projects")
                        .HasForeignKey("VendorGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Employee", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("Supply_Management_XYZ.Server.Models.Vendor", b =>
                {
                    b.Navigation("AccountVendor");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}