using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class AssetManager_SoftwareMap : EntityTypeConfiguration<AssetManager_Software>
    {
        public AssetManager_SoftwareMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AccountingReqNumber)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AssetManager_Software");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SoftwareAssetNumber).HasColumnName("SoftwareAssetNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SoftwareTypeId).HasColumnName("SoftwareTypeId");
            this.Property(t => t.ProductOwnerId).HasColumnName("ProductOwnerId");
            this.Property(t => t.ProductUsersId).HasColumnName("ProductUsersId");
            this.Property(t => t.SupportingCompanyId).HasColumnName("SupportingCompanyId");
            this.Property(t => t.AssociatedCompanyId).HasColumnName("AssociatedCompanyId");
            this.Property(t => t.PublisherId).HasColumnName("PublisherId");
            this.Property(t => t.AccountingReqNumber).HasColumnName("AccountingReqNumber");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.LicensingInfo).HasColumnName("LicensingInfo");
            this.Property(t => t.DateOfPurchase).HasColumnName("DateOfPurchase");
            this.Property(t => t.EndOfSupportDate).HasColumnName("EndOfSupportDate");
            this.Property(t => t.LicenseCount).HasColumnName("LicenseCount");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedById).HasColumnName("CreatedById");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedById).HasColumnName("ModifiedById");

            // Relationships
            this.HasOptional(t => t.AssetManager_Companies)
                .WithMany(t => t.AssetManager_Software)
                .HasForeignKey(d => d.AssociatedCompanyId);
            this.HasOptional(t => t.AssetManager_Companies1)
                .WithMany(t => t.AssetManager_Software1)
                .HasForeignKey(d => d.SupportingCompanyId);
            this.HasRequired(t => t.ServiceDesk_Users)
                .WithMany(t => t.AssetManager_Software)
                .HasForeignKey(d => d.CreatedById);
            this.HasRequired(t => t.ServiceDesk_Users1)
                .WithMany(t => t.AssetManager_Software1)
                .HasForeignKey(d => d.PublisherId);
            this.HasOptional(t => t.ServiceDesk_Users2)
                .WithMany(t => t.AssetManager_Software2)
                .HasForeignKey(d => d.ModifiedById);
            this.HasOptional(t => t.ServiceDesk_Users3)
                .WithMany(t => t.AssetManager_Software3)
                .HasForeignKey(d => d.ProductOwnerId);
            this.HasOptional(t => t.ServiceDesk_Users4)
                .WithMany(t => t.AssetManager_Software4)
                .HasForeignKey(d => d.ProductUsersId);
            this.HasRequired(t => t.AssetManager_Software_AssetType)
                .WithMany(t => t.AssetManager_Software)
                .HasForeignKey(d => d.SoftwareTypeId);

        }
    }
}
