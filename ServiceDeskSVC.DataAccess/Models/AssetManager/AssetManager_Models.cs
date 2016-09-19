using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_Models
    {
        public AssetManager_Models()
        {
           this.AssetManager_Companies = new List<AssetManager_Companies>();
        }

        public int Id { get; set; }
        public string ModelName { get; set; }
        public int CompanyId { get; set; }
        public string DescriptionNotes { get; set; }
        public string SupportWebsite { get; set; }
        public string ManufacturerWebsite { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreateById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual 
        public int? PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }
        public virtual ICollection<AssetManager_Companies> AssetManager_Companies { get; set; }


    //    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    //[ModelName] NVARCHAR(100) NOT NULL, 
    //[CompanyId] INT NOT NULL, 
    //[DescriptionNotes] NVARCHAR(MAX) NULL, 
    //[SupportWebsite] NVARCHAR(300) NULL, 
    //[ManufacturerWebsite] NVARCHAR(300) NULL, 
    //[CreatedDate] DATETIME2(0) NOT NULL, 
    //[CreatedById] INT NOT NULL, 
    //[ModifiedDate] DATETIME2(0) NULL, 
    //[ModifiedById] INT NULL,
    //CONSTRAINT [FK_AssetManager_Models_CreatedById_ToServiceDesk_Users_Id] FOREIGN KEY ([CreatedById]) REFERENCES [ServiceDesk_Users]([Id]),
    //CONSTRAINT [FK_AssetManager_Models_ModifiedById_ToServiceDesk_Users_Id] FOREIGN KEY ([ModifiedById]) REFERENCES [ServiceDesk_Users]([Id]),
    //CONSTRAINT [FK_AssetManager_Models_CompanyId_ToServiceDesk_Companies_Id] FOREIGN KEY ([CompanyId]) REFERENCES [AssetManager_Companies]([Id])
    }
}
