using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ServiceDeskSVC.DataAccess.Models.Mapping;

namespace ServiceDeskSVC.DataAccess.Models
    {
    public partial class ServiceDeskContext:DbContext
        {
        static ServiceDeskContext()
            {
            Database.SetInitializer<ServiceDeskContext>(null);
            }

        public ServiceDeskContext()
            : base("Name=ServiceDeskContext")
            {
            }

        public DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public DbSet<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
        public DbSet<AssetManager_AssetStatus> AssetManager_AssetStatus { get; set; }
        public DbSet<AssetManager_Companies> AssetManager_Companies { get; set; }
        public DbSet<AssetManager_Hardware> AssetManager_Hardware { get; set; }
        public DbSet<AssetManager_Hardware_AssetType> AssetManager_Hardware_AssetType { get; set; }
        public DbSet<AssetManager_Models> AssetManager_Models { get; set; }
        public DbSet<AssetManager_Software> AssetManager_Software { get; set; }
        public DbSet<AssetManager_Software_AssetType> AssetManager_Software_AssetType { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HelpDesk_Tasks> HelpDesk_Tasks { get; set; }
        public DbSet<HelpDesk_Tasks_RelatedTasks> HelpDesk_Tasks_RelatedTasks { get; set; }
        public DbSet<HelpDesk_TaskStatus> HelpDesk_TaskStatus { get; set; }
        public DbSet<HelpDesk_TicketAttachments> HelpDesk_TicketAttachments { get; set; }
        public DbSet<HelpDesk_TicketCategory> HelpDesk_TicketCategory { get; set; }
        public DbSet<HelpDesk_TicketComments> HelpDesk_TicketComments { get; set; }
        public DbSet<HelpDesk_TicketDocuments> HelpDesk_TicketDocuments { get; set; }
        public DbSet<HelpDesk_Tickets> HelpDesk_Tickets { get; set; }
        public DbSet<HelpDesk_TicketStatus> HelpDesk_TicketStatus { get; set; }
        public DbSet<HelpDesk_TicketType> HelpDesk_TicketType { get; set; }
        public DbSet<NSLocation> NSLocations { get; set; }
        public DbSet<ServiceDesk_Users> ServiceDesk_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            modelBuilder.Configurations.Add(new C__RefactorLogMap());
            modelBuilder.Configurations.Add(new AssetManager_AssetAttachmentsMap());
            modelBuilder.Configurations.Add(new AssetManager_AssetStatusMap());
            modelBuilder.Configurations.Add(new AssetManager_CompaniesMap());
            modelBuilder.Configurations.Add(new AssetManager_HardwareMap());
            modelBuilder.Configurations.Add(new AssetManager_Hardware_AssetTypeMap());
            modelBuilder.Configurations.Add(new AssetManager_ModelsMap());
            modelBuilder.Configurations.Add(new AssetManager_SoftwareMap());
            modelBuilder.Configurations.Add(new AssetManager_Software_AssetTypeMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new HelpDesk_TasksMap());
            modelBuilder.Configurations.Add(new HelpDesk_Tasks_RelatedTasksMap());
            modelBuilder.Configurations.Add(new HelpDesk_TaskStatusMap());
            modelBuilder.Configurations.Add(new HelpDesk_TicketAttachmentsMap());
            modelBuilder.Configurations.Add(new HelpDesk_TicketCategoryMap());
            modelBuilder.Configurations.Add(new HelpDesk_TicketCommentsMap());
            modelBuilder.Configurations.Add(new HelpDesk_TicketDocumentsMap());
            modelBuilder.Configurations.Add(new HelpDesk_TicketsMap());
            modelBuilder.Configurations.Add(new HelpDesk_TicketStatusMap());
            modelBuilder.Configurations.Add(new HelpDesk_TicketTypeMap());
            modelBuilder.Configurations.Add(new NSLocationMap());
            modelBuilder.Configurations.Add(new ServiceDesk_UsersMap());
            }
        }
    }
