using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class AssetManager_HardwareMap : EntityTypeConfiguration<AssetManager_Hardware>
    {
        public AssetManager_HardwareMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AssetTag)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.SerialNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PurchaseOrderNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.IPAddress)
                .HasMaxLength(12);

            this.Property(t => t.ComputerName)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("AssetManager_Hardware");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.HardwareAssetNumber).HasColumnName("HardwareAssetNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.AssetTag).HasColumnName("AssetTag");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.DisposalDate).HasColumnName("DisposalDate");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.AssignedToId).HasColumnName("AssignedToId");
            this.Property(t => t.PurchaseOrderNumber).HasColumnName("PurchaseOrderNumber");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.PurchasedFromId).HasColumnName("PurchasedFromId");
            this.Property(t => t.SupportedById).HasColumnName("SupportedById");
            this.Property(t => t.DateOfPurchase).HasColumnName("DateOfPurchase");
            this.Property(t => t.EndOfLifeDate).HasColumnName("EndOfLifeDate");
            this.Property(t => t.DisposalMethodCode).HasColumnName("DisposalMethodCode");
            this.Property(t => t.ReassignedDate).HasColumnName("ReassignedDate");
            this.Property(t => t.OldLocationId).HasColumnName("OldLocationId");
            this.Property(t => t.OldAssignedToId).HasColumnName("OldAssignedToId");
            this.Property(t => t.DeskRoomNumber).HasColumnName("DeskRoomNumber");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.ComputerName).HasColumnName("ComputerName");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedById).HasColumnName("CreatedById");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedById).HasColumnName("ModifiedById");

            // Relationships
            this.HasRequired(t => t.AssetManager_AssetStatus)
                .WithMany(t => t.AssetManager_Hardware)
                .HasForeignKey(d => d.StatusId);
            this.HasRequired(t => t.AssetManager_Companies)
                .WithMany(t => t.AssetManager_Hardware)
                .HasForeignKey(d => d.PurchasedFromId);
            this.HasOptional(t => t.AssetManager_Companies1)
                .WithMany(t => t.AssetManager_Hardware1)
                .HasForeignKey(d => d.SupportedById);
            this.HasOptional(t => t.ServiceDesk_Users)
                .WithMany(t => t.AssetManager_Hardware)
                .HasForeignKey(d => d.AssignedToId);
            this.HasRequired(t => t.ServiceDesk_Users1)
                .WithMany(t => t.AssetManager_Hardware1)
                .HasForeignKey(d => d.CreatedById);
            this.HasOptional(t => t.Department)
                .WithMany(t => t.AssetManager_Hardware)
                .HasForeignKey(d => d.DepartmentId);
            this.HasRequired(t => t.NSLocation)
                .WithMany(t => t.AssetManager_Hardware)
                .HasForeignKey(d => d.LocationId);
            this.HasRequired(t => t.AssetManager_Models)
                .WithMany(t => t.AssetManager_Hardware)
                .HasForeignKey(d => d.ModelId);
            this.HasOptional(t => t.ServiceDesk_Users2)
                .WithMany(t => t.AssetManager_Hardware2)
                .HasForeignKey(d => d.ModifiedById);
            this.HasOptional(t => t.ServiceDesk_Users3)
                .WithMany(t => t.AssetManager_Hardware3)
                .HasForeignKey(d => d.OldAssignedToId);
            this.HasOptional(t => t.NSLocation1)
                .WithMany(t => t.AssetManager_Hardware1)
                .HasForeignKey(d => d.OldLocationId);
            this.HasRequired(t => t.AssetManager_Hardware_AssetType)
                .WithMany(t => t.AssetManager_Hardware)
                .HasForeignKey(d => d.TypeId);

        }
    }
}
