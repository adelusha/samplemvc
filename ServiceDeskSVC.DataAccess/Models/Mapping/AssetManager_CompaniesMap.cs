using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class AssetManager_CompaniesMap : EntityTypeConfiguration<AssetManager_Companies>
    {
        public AssetManager_CompaniesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Website)
                .HasMaxLength(100);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(30);

            this.Property(t => t.Street)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("AssetManager_Companies");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
        }
    }
}
