using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class NSLocationMap : EntityTypeConfiguration<NSLocation>
    {
        public NSLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.LocationCity)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.LocationState)
                .IsRequired()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("NSLocations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LocationCity).HasColumnName("LocationCity");
            this.Property(t => t.LocationState).HasColumnName("LocationState");
            this.Property(t => t.LocationZip).HasColumnName("LocationZip");
        }
    }
}
