using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class AssetManager_ModelsMap : EntityTypeConfiguration<AssetManager_Models>
    {
        public AssetManager_ModelsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ModelName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SupportWebsite)
                .HasMaxLength(300);

            this.Property(t => t.ManufacturerWebsite)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("AssetManager_Models");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ModelName).HasColumnName("ModelName");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.DescriptionNotes).HasColumnName("DescriptionNotes");
            this.Property(t => t.SupportWebsite).HasColumnName("SupportWebsite");
            this.Property(t => t.ManufacturerWebsite).HasColumnName("ManufacturerWebsite");

            // Relationships
            this.HasRequired(t => t.AssetManager_Companies)
                .WithMany(t => t.AssetManager_Models)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
