using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentApp.Domain.Abstraction;
using RentApp.Domain.Entities;
using RentApp.Infrastructure.Repositories;


namespace RentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var Apartment = _unitOfWork.Apartments.GetById(id);
            return Ok(Apartment);
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<Apartment> apartments;
            apartments = _unitOfWork.Apartments.GetAll();
            return Ok(apartments);
        }
        [HttpGet("sorted")]
        public IActionResult GetSorted([FromQuery] string sortBy = "Name", [FromQuery] bool ascending = true)
        {
            IEnumerable<Apartment> Apartments;
            switch (sortBy.ToLower())
            {
                case "size":
                    Apartments = _unitOfWork.Apartments.GetAllSorted(a => a.Size, ascending);
                    break;
                case "numberofrooms":
                    Apartments = _unitOfWork.Apartments.GetAllSorted(a => a.NumberOfRooms, ascending);
                    break;
                case "city":
                    Apartments = _unitOfWork.Apartments.GetAllSorted(a => a.City, ascending);
                    break;
                default:
                    Apartments = _unitOfWork.Apartments.GetAllSorted(a => a.Id, ascending);
                    break;

            }
            return Ok(Apartments);
        }
        //[HttpGet("GetByIdAsync")]
        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
        //    return Ok(await _unitOfWork.Apartments.GetByIdAsync(id));
        //}

        //Post
        [HttpPost]
        public IActionResult AddApartment([FromBody] Apartment Apartment) {
            if (Apartment == null)
            {
                return BadRequest("Apartment's data is required.");
            }
            _unitOfWork.Apartments.Add(Apartment);
            return Created();
        }
    }
}
