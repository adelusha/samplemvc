using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class AssetManager_Hardware_AssetTypeMap : EntityTypeConfiguration<AssetManager_Hardware_AssetType>
    {
        public AssetManager_Hardware_AssetTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AssetManager_Hardware_AssetType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DescriptionNotes).HasColumnName("DescriptionNotes");
            this.Property(t => t.EndOfLifeMo).HasColumnName("EndOfLifeMo");
            this.Property(t => t.CategoryCode).HasColumnName("CategoryCode");
        }
    }
}
