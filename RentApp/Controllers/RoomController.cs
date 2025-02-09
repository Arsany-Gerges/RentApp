using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentApp.Domain.Abstraction;
using RentApp.Domain.Entities;

namespace RentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var room = _unitOfWork.Rooms.GetById(id);
            return Ok(room);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<Room> rooms;
            rooms = _unitOfWork.Rooms.GetAll();
            return Ok(rooms);
        }
        [HttpGet("sorted")]
        public IActionResult GetSorted([FromQuery] string sortBy = "Name", [FromQuery] bool ascending = true)
        {
            IEnumerable<Room> rooms;
            switch (sortBy.ToLower())
            {
                case "price":
                    rooms = _unitOfWork.Rooms.GetAllSorted(r => r.Price, ascending);
                    break;
                case "capacity":
                    rooms = _unitOfWork.Rooms.GetAllSorted(r => r.Capacity, ascending);
                    break;
                default:
                    rooms = _unitOfWork.Rooms.GetAllSorted(r => r.ID, ascending);
                    break;
            }
            return Ok(rooms);
        }
        //Post
        [HttpPost]
        public IActionResult AddRoom([FromBody] Room room)
        {
            if (room == null)
            {
                return BadRequest("Rooms's data is required.");
            }
            _unitOfWork.Rooms.Add(room);
            return Created();
        }
    }
}
