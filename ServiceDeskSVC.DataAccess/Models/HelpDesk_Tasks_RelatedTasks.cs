using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_Tasks_RelatedTasks
    {
        public int Id { get; set; }
        public int TaskID { get; set; }
        public int RelatedTaskID { get; set; }
    }
}
