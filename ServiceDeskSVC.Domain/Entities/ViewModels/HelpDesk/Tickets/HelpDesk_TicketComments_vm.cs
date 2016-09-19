using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets
{
    public class HelpDesk_TicketComments_vm
    {
    public int Id { get; set; }
    public int TicketID { get; set; }
    public System.DateTime CommentDateTime { get; set; }
    public string AuthorUserName { get; set; }
    public int CommentTypeID { get; set; }
    public string Comment { get; set; }
    public virtual Comment_User AuthorUser { get; set; }
    }

    public class Comment_User
        {

        public string UserName { get; set; }

        public string DisplayName { get; set; }
        }
}
