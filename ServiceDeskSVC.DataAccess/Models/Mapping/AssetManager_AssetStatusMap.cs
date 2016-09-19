using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class AssetManager_AssetStatusMap : EntityTypeConfiguration<AssetManager_AssetStatus>
    {
        public AssetManager_AssetStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AssetManager_AssetStatus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedById).HasColumnName("CreatedById");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedById).HasColumnName("ModifiedById");

            // Relationships
            this.HasRequired(t => t.ServiceDesk_Users)
                .WithMany(t => t.AssetManager_AssetStatus)
                .HasForeignKey(d => d.CreatedById);
            this.HasOptional(t => t.ServiceDesk_Users1)
                .WithMany(t => t.AssetManager_AssetStatus1)
                .HasForeignKey(d => d.ModifiedById);

        }
    }
}
