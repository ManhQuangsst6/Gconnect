using System.ComponentModel;
using System.Reflection;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Domain.Entities;
using Gconnect.Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Gconnect.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }


    public DbSet<AspNetResource> AspNetResources => Set<AspNetResource>();

    public DbSet<AspNetRole> AspNetRoles => Set<AspNetRole>();

    public DbSet<AspNetRoleClaim> AspNetRoleClaims => Set<AspNetRoleClaim>();

    public DbSet<AspNetRoleResource> AspNetRoleResources => Set<AspNetRoleResource>();

    public DbSet<AspNetUser> AspNetUsers => Set<AspNetUser>();

    public DbSet<AspNetUserClaim> AspNetUserClaims => Set<AspNetUserClaim>();

    public DbSet<AspNetUserLogin> AspNetUserLogins => Set<AspNetUserLogin>();

    public DbSet<AspNetUserRole> AspNetUserRoles => Set<AspNetUserRole>();

    public DbSet<AspNetUserToken> AspNetUserTokens => Set<AspNetUserToken>();

    // Danh muc
    public DbSet<DmDonVi> DmDonVis => Set<DmDonVi>();
    public DbSet<DmPhong> DmPhongs => Set<DmPhong>();

    DbSet<DmMatHoatDong> DmMatHoatDongs => Set<DmMatHoatDong>();
    DbSet<DmThoiHanBaoQuan> DmThoiHanBaoQuans => Set<DmThoiHanBaoQuan>();

    // Thu thap
    public DbSet<TT_YeuCauLapDanhMucHoSo> TtYeuCauLapDanhMucHoSos => Set<TT_YeuCauLapDanhMucHoSo>();
    public DbSet<TT_YeuCauLapDanhMucHoSoDsDonVi> TtYeuCauLapDanhMucHoSoDsDonVis => Set<TT_YeuCauLapDanhMucHoSoDsDonVi>();
    public DbSet<TT_DanhMucHoSoDuKien> TtDanhMucHoSoDuKiens => Set<TT_DanhMucHoSoDuKien>();
    public DbSet<TT_DanhMucHoSoChiTiet> TtDanhMucHoSoChiTiets => Set<TT_DanhMucHoSoChiTiet>();
    public DbSet<TT_KeHoachGiaoNop> TtKeHoachGiaoNops => Set<TT_KeHoachGiaoNop>();
    public DbSet<TT_KeHoachGiaoNopDonVi> TtKeHoachGiaoNopDonVis => Set<TT_KeHoachGiaoNopDonVi>();

    public override DatabaseFacade Database
    {
        get
        {
            return base.Database;
        }
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        MappingModel(builder);
        MappingModelDanhMuc(builder);
        MappingModelThuThap(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder/*.UseLazyLoadingProxies()*/.UseSqlServer("Server=192.168.1.100,1433;Database=QLTT;User id=qllt;Password=qllt@123456;Encrypt=False").EnableDetailedErrors(true);

            //optionsBuilder/*.UseLazyLoadingProxies()*/.UseNpgsql("Server=localhost,5432;Database=mapdata;User id=postgres;Password=Ab@123456",
            //    x => x.UseNetTopologySuite());
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {

        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");

        base.ConfigureConventions(builder);

    }

    protected void MappingModel(ModelBuilder modelBuilder)
    {
        //modelBuilder
        //    .HasPostgresExtension("hstore")
        //    .HasPostgresExtension("postgis")
        //    .HasPostgresExtension("postgres_fdw");


        modelBuilder.Entity<AspNetResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AspNetResource_pkey");

            entity.ToTable("AspNetResource");

            entity.HasIndex(e => e.ResourceCode, "Resouce_Code_Uni").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.ResourceCode)
                .HasMaxLength(50)
                .HasColumnName("Resource_Code");
            entity.Property(e => e.ResourceName).HasColumnName("Resource_Name");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetRoleResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AspNetRoleResource_pkey");

            entity.ToTable("AspNetRoleResource");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.ResouceId).HasColumnName("Resouce_Id");
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");

            entity.HasOne(d => d.Resouce).WithMany(p => p.AspNetRoleResources)
                .HasForeignKey(d => d.ResouceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AspNetRoleResource_Res_FK");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleResources)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AspNetRoleResource_Role_FK");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AspNetUserRoles_pkey");

            entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetUserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserRoles).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

    }
    protected void MappingModelDanhMuc(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmDonVi>(entity =>
        {
            entity.ToTable("DM_DonVi");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_DmDonVi_Id");
            entity.HasIndex(e => e.MaDonVi, "IX_DmDonVi_MaDonVi");
            entity.HasIndex(e => e.IdDonViCha, "IX_DmDonVi_IdDonViCha");
            entity.HasIndex(e => e.MaDonViCha, "IX_DmDonVi_MaDonViCha");
            entity.HasOne(e => e.DonViCha).WithMany(e => e.DonViTrucThuocs)
                .HasForeignKey(e => e.IdDonViCha).Metadata.DeleteBehavior = DeleteBehavior.NoAction;
        });
        modelBuilder.Entity<DmPhong>(entity =>
        {
            entity.ToTable("DM_Phong");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_DmPhong_Id");
        });
        modelBuilder.Entity<DmThoiHanBaoQuan>(entity =>
        {
            entity.ToTable("DM_ThoiHanBaoQuan");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_DmThoiHanBaoQuan_Id");
        });
        modelBuilder.Entity<DmMatHoatDong>(entity =>
        {
            entity.ToTable("DM_MatHoatDong");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_DmMatHoatDong_Id");
        });
    }

    protected void MappingModelThuThap(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TT_YeuCauLapDanhMucHoSo>(entity =>
        {
            entity.ToTable("TT_YeuCauLapDanhMucHoSo");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_TT_YeuCauLapDanhMucHoSo_Id");
            entity.HasMany(e => e.DonViNhanYeuCaus).WithOne(e => e.YeuCauLapDanhMucHoSo).HasForeignKey(e => e.YeuCauId).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.DanhMucHoSoChiTiets).WithOne(e => e.YeuCauLapDanhMucHoSo).HasForeignKey(e => e.YeuCauLapDanhMucHoSoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(e => e.DanhMucHoSoDuKiens).WithOne(e => e.YeuCauLapDanhMucHoSo).HasForeignKey(e => e.YeuCauLapDanhMucHoSoId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TT_YeuCauLapDanhMucHoSoDsDonVi>(entity =>
        {
            entity.ToTable("TT_YeuCauLapDanhMucHoSo_DsDonVi");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_TT_YeuCauLapDanhMucHoSo_Id");
            entity.HasOne(e => e.DonViNhanYeuCau).WithMany(e => e.YeuCauLapHoSoCuaDonVi)
            .HasForeignKey(e => e.DonViId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TT_DanhMucHoSoDuKien>(entity =>
        {
            entity.ToTable("TT_DanhMucHoSoDuKien");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_TT_DanhMucHoSoDuKien_Id");
            entity.HasMany(e => e.DanhMucHoSoChiTiets).WithOne(e => e.DanhMucHoSoDuKien)
            .HasForeignKey(e => e.DanhMucHoSoDuKienId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TT_DanhMucHoSoChiTiet>(entity =>
        {
            entity.ToTable("TT_DanhMucHoSoChiTiet");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_TT_DanhMucHoSoChiTiet_Id");
        });
        modelBuilder.Entity<TT_KeHoachGiaoNop>(entity =>
        {
            entity.ToTable("TT_KeHoachGiaoNop");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_TT_KeHoachGiaoNop_Id");
            entity.HasMany(e => e.KeHoachGiaoNopDonVis).WithOne(e => e.KeHoachGiaoNop).HasForeignKey(e => e.KeHoachGiaoNopId).OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<TT_KeHoachGiaoNopDonVi>(entity =>
        {
            entity.ToTable("TT_KeHoachGiaoNopDonVi");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id, "IX_TT_KeHoachGiaoNopDonVi_Id");
        });
    }
}