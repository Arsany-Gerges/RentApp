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
        private readonly IBaseRepository<Room> _roomRepository;
        public RoomController(IBaseRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_roomRepository.GetById(id));
        }
    }
}
