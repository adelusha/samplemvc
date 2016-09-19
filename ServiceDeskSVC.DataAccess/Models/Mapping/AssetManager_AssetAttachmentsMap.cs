using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class AssetManager_AssetAttachmentsMap : EntityTypeConfiguration<AssetManager_AssetAttachments>
    {
        public AssetManager_AssetAttachmentsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FileName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Data)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AssetManager_AssetAttachments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.FileSize).HasColumnName("FileSize");
            this.Property(t => t.HardwareAssetId).HasColumnName("HardwareAssetId");
            this.Property(t => t.SoftwareAssetId).HasColumnName("SoftwareAssetId");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.CompaniesId).HasColumnName("CompaniesId");
            this.Property(t => t.DescriptionNotes).HasColumnName("DescriptionNotes");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedById).HasColumnName("CreatedById");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedById).HasColumnName("ModifiedById");

            // Relationships
            this.HasOptional(t => t.AssetManager_Companies)
                .WithMany(t => t.AssetManager_AssetAttachments)
                .HasForeignKey(d => d.CompaniesId);
            this.HasRequired(t => t.ServiceDesk_Users)
                .WithMany(t => t.AssetManager_AssetAttachments)
                .HasForeignKey(d => d.CreatedById);
            this.HasOptional(t => t.AssetManager_Hardware)
                .WithMany(t => t.AssetManager_AssetAttachments)
                .HasForeignKey(d => d.HardwareAssetId);
            this.HasOptional(t => t.AssetManager_Models)
                .WithMany(t => t.AssetManager_AssetAttachments)
                .HasForeignKey(d => d.ModelId);
            this.HasRequired(t => t.ServiceDesk_Users1)
                .WithMany(t => t.AssetManager_AssetAttachments1)
                .HasForeignKey(d => d.ModifiedById);
            this.HasOptional(t => t.AssetManager_Software)
                .WithMany(t => t.AssetManager_AssetAttachments)
                .HasForeignKey(d => d.SoftwareAssetId);

        }
    }
}
