using System.Web.Http;
using ServiceDeskSVC.WorkerServices;

namespace ServiceDeskSVC.Controllers.API.Ticketing
{
    [RoutePrefix("api/ticketing")]
    public class UsersController : ApiController
    {
        private readonly TicketingControllerWorkerService _ticketsService;

        public UsersController(TicketingControllerWorkerService ticketsService)
        {
            _ticketsService = ticketsService;
        }


        [Route("RefreshUsers")]
        [HttpGet]
        public IHttpActionResult RefreshAllUsers()
        {
            _ticketsService.RefreshUsers();
            return Ok();
        }
    }
}