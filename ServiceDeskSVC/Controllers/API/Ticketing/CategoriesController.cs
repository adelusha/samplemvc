using System.Web.Http;
using ServiceDeskSVC.Models.Ticketing;
using ServiceDeskSVC.WorkerServices;

namespace ServiceDeskSVC.Controllers.API.Ticketing
{
    [RoutePrefix("api/ticketing")]
    public class CategoriesController : ApiController
    {
        private readonly TicketingControllerWorkerService _ticketsService;

        public CategoriesController(TicketingControllerWorkerService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [Route("categories")]
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            AllCategoriesModel model = _ticketsService.GetAllCategories();
            return Ok(model);
        }
    }
}