﻿// <auto-generated />
using System;
using Gconnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230609124113_update7")]
    partial class update7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetResource", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("ResourceCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Resource_Code");

                    b.Property<string>("ResourceName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Resource_Name");

                    b.HasKey("Id")
                        .HasName("AspNetResource_pkey");

                    b.HasIndex(new[] { "ResourceCode" }, "Resouce_Code_Uni")
                        .IsUnique();

                    b.ToTable("AspNetResource", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetRoleClaim", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetRoleResource", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("ResouceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Resouce_Id");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Role_Id");

                    b.HasKey("Id")
                        .HasName("AspNetRoleResource_pkey");

                    b.HasIndex("ResouceId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleResource", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUserClaim", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("AspNetUserRoles_pkey");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.DmDonVi", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDonViCha")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaDonVi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaDonViCha")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenDonVi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_DmDonVi_Id");

                    b.HasIndex(new[] { "IdDonViCha" }, "IX_DmDonVi_IdDonViCha");

                    b.HasIndex(new[] { "MaDonVi" }, "IX_DmDonVi_MaDonVi");

                    b.HasIndex(new[] { "MaDonViCha" }, "IX_DmDonVi_MaDonViCha");

                    b.ToTable("DM_DonVi", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.DmMatHoatDong", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatHoatDong")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_DmMatHoatDong_Id");

                    b.ToTable("DM_MatHoatDong", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.DmPhong", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhong")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_DmPhong_Id");

                    b.ToTable("DM_Phong", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.DmThoiHanBaoQuan", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenThoiHanBaoQuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThoiGianBaoQuan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_DmThoiHanBaoQuan_Id");

                    b.ToTable("DM_ThoiHanBaoQuan", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_DanhMucHoSoChiTiet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DanhMucHoSoDuKienId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DonViId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonViLapDanhMucId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatHoatDongId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiLapId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhongId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoKyHieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenMatHoatDong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenThoiHanBaoQuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThoiHanBaoQuanId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("YeuCauLapDanhMucHoSoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DanhMucHoSoDuKienId");

                    b.HasIndex("YeuCauLapDanhMucHoSoId");

                    b.HasIndex(new[] { "Id" }, "IX_TT_DanhMucHoSoChiTiet_Id");

                    b.ToTable("TT_DanhMucHoSoChiTiet", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_DanhMucHoSoDuKien", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonViId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Nam")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayQdPheDuyet")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoQdPheDuyet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YeuCauLapDanhMucHoSoId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_TT_DanhMucHoSoDuKien_Id");

                    b.ToTable("TT_DanhMucHoSoDuKien", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_KeHoachGiaoNop", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Nam")
                        .HasColumnType("int");

                    b.Property<string>("NguoiLap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKeHoach")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_TT_KeHoachGiaoNop_Id");

                    b.ToTable("TT_KeHoachGiaoNop", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_KeHoachGiaoNopDonVi", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonViId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeHoachGiaoNopId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenDonVi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KeHoachGiaoNopId");

                    b.HasIndex(new[] { "Id" }, "IX_TT_KeHoachGiaoNopDonVi_Id");

                    b.ToTable("TT_KeHoachGiaoNopDonVi", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_YeuCauLapDanhMucHoSo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Nam")
                        .HasColumnType("int");

                    b.Property<string>("TenYeuCau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TinhTrangPheDuyet")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_TT_YeuCauLapDanhMucHoSo_Id");

                    b.ToTable("TT_YeuCauLapDanhMucHoSo", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_YeuCauLapDanhMucHoSoDsDonVi", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonViId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TinhTrang")
                        .HasColumnType("int");

                    b.Property<string>("YeuCauId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DonViId");

                    b.HasIndex("YeuCauId");

                    b.HasIndex(new[] { "Id" }, "IX_TT_YeuCauLapDanhMucHoSo_Id");

                    b.ToTable("TT_YeuCauLapDanhMucHoSo_DsDonVi", (string)null);
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetRoleClaim", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetRoleResource", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.AspNetResource", "Resouce")
                        .WithMany("AspNetRoleResources")
                        .HasForeignKey("ResouceId")
                        .IsRequired()
                        .HasConstraintName("AspNetRoleResource_Res_FK");

                    b.HasOne("Gconnect.Domain.Entities.AspNetRole", "Role")
                        .WithMany("AspNetRoleResources")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("AspNetRoleResource_Role_FK");

                    b.Navigation("Resouce");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUserClaim", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUserLogin", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUserRole", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.AspNetRole", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gconnect.Domain.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUserToken", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.DmDonVi", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.DmDonVi", "DonViCha")
                        .WithMany("DonViTrucThuocs")
                        .HasForeignKey("IdDonViCha")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("DonViCha");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_DanhMucHoSoChiTiet", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.TT_DanhMucHoSoDuKien", "DanhMucHoSoDuKien")
                        .WithMany("DanhMucHoSoChiTiets")
                        .HasForeignKey("DanhMucHoSoDuKienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gconnect.Domain.Entities.TT_YeuCauLapDanhMucHoSo", "YeuCauLapDanhMucHoSo")
                        .WithMany("DanhMucHoSoChiTiets")
                        .HasForeignKey("YeuCauLapDanhMucHoSoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucHoSoDuKien");

                    b.Navigation("YeuCauLapDanhMucHoSo");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_KeHoachGiaoNopDonVi", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.TT_KeHoachGiaoNop", "KeHoachGiaoNop")
                        .WithMany("KeHoachGiaoNopDonVis")
                        .HasForeignKey("KeHoachGiaoNopId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("KeHoachGiaoNop");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_YeuCauLapDanhMucHoSoDsDonVi", b =>
                {
                    b.HasOne("Gconnect.Domain.Entities.DmDonVi", "DonViNhanYeuCau")
                        .WithMany("YeuCauLapHoSoCuaDonVi")
                        .HasForeignKey("DonViId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gconnect.Domain.Entities.TT_YeuCauLapDanhMucHoSo", "YeuCauLapDanhMucHoSo")
                        .WithMany("DonViNhanYeuCaus")
                        .HasForeignKey("YeuCauId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonViNhanYeuCau");

                    b.Navigation("YeuCauLapDanhMucHoSo");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetResource", b =>
                {
                    b.Navigation("AspNetRoleResources");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");

                    b.Navigation("AspNetRoleResources");

                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserRoles");

                    b.Navigation("AspNetUserTokens");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.DmDonVi", b =>
                {
                    b.Navigation("DonViTrucThuocs");

                    b.Navigation("YeuCauLapHoSoCuaDonVi");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_DanhMucHoSoDuKien", b =>
                {
                    b.Navigation("DanhMucHoSoChiTiets");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_KeHoachGiaoNop", b =>
                {
                    b.Navigation("KeHoachGiaoNopDonVis");
                });

            modelBuilder.Entity("Gconnect.Domain.Entities.TT_YeuCauLapDanhMucHoSo", b =>
                {
                    b.Navigation("DanhMucHoSoChiTiets");

                    b.Navigation("DonViNhanYeuCaus");
                });
#pragma warning restore 612, 618
        }
    }
}
