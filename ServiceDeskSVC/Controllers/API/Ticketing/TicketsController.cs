using System.Net;
using System.Web.ModelBinding;
using ServiceDeskSVC.Models.Ticketing;
using ServiceDeskSVC.WorkerServices;
using System.Web.Http;

namespace ServiceDeskSVC.Controllers.API.Ticketing
    {
    [RoutePrefix("api/ticketing")]
    public class TicketsController : ApiController
        {
        private readonly TicketingControllerWorkerService _ticketsService;

        public TicketsController(TicketingControllerWorkerService ticketsService)
            {
            _ticketsService = ticketsService;
            }

        [Route("tickets")]
        [HttpPost]
        public IHttpActionResult CreateTicket(TicketInputModel model)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _ticketsService.CreateNewTicket(model);
            return Ok();
            }

        [Route("tickets/{id}")]
        [HttpGet]
        public IHttpActionResult GetTicket(int id)
            {
            TicketViewModel ticket = _ticketsService.GetTicket(id);
            return Ok(ticket);
            }

        [Route("tickets/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateTicket(int id, TicketUpdateModel model)
            {
            if (!ModelState.IsValid)
                {
                return BadRequest(ModelState);
                }

            _ticketsService.UpdateTicket(id, model);
            return Ok();
            }

        [Route("tickets")]
        [HttpGet]
        public IHttpActionResult GetAllTickets()
            {
            AllTicketsModel model = _ticketsService.GetAllTickets();
            return Ok(model);
            }

        [Route("tickets/{id}/tasks")]
        [HttpGet]
        public IHttpActionResult GetTasksForTicket(int id)
            {
            AllTasksModel model = _ticketsService.GetTasksForTicket(id);
            return Ok(model);
            }

        [Route("tickets/tasks/{id}")]
        [HttpGet]
        public IHttpActionResult GetTask(int id)
            {
            TaskViewModel model = _ticketsService.GetTask(id);
            return Ok(model);
            }


        [Route("tickets/{id}/task")]
        [HttpPost]
        public IHttpActionResult CreateTask(int id, TaskInputModel model)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _ticketsService.CreateNewTask(id, model);
            return Ok();
            }

        [Route("tickets/{id}/comment")]
        [HttpGet]
        public IHttpActionResult GetTicketComments(int id)
        {
            AllTicketCommentsModel comments = _ticketsService.GetCommentsForTicket(id);
            return Ok(comments);
        }

        [Route("tickets/{id}/comment")]
        [HttpPost]
        public IHttpActionResult CreateComment(int id, TicketCommentInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _ticketsService.CreateTicketComment(id, model);
            return Ok();
        }



        [Route("tickets/{ticketId}/task/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateTask(int ticketId, int id, UpdateTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ticketsService.UpdateTask(ticketId, id, model);
            return Ok();
        }
        }
    }
