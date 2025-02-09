using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentApp.Domain.Abstraction;
using RentApp.Domain.Entities;


namespace RentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IBaseRepository<Apartment> _apartmentRepository;
        public ApartmentController(IBaseRepository<Apartment> apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        //Get
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var Apartment = _apartmentRepository.GetById(id);
            return Ok(Apartment);
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<Apartment> Apartments;
            Apartments = _apartmentRepository.GetAll();
            return Ok(Apartments);
        }
        //[HttpGet("sorted")]
        //public IActionResult GetSorted([FromQuery] string sortBy = "Name", [FromQuery] bool ascending = true)
        //{
        //    IEnumerable<Apartment> Apartments;
        //    switch (sortBy.ToLower())
        //    {
        //        case "price":
        //            Apartments = _apartmentRepository.GetAllSorted(p => p.Price, ascending));
        //            break;
        //        default:
        //            Apartments = _apartmentRepository.GetAllSorted(p => p.Id, ascending));
        //            break;

        //    }
        //    return Ok(Apartments);
        //}
        //[HttpGet("GetByIdAsync")]
        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
        //    return Ok(await _apartmentRepository.GetByIdAsync(id));
        //}

        //Post
        [HttpPost]
        public IActionResult AddApartment([FromBody] Apartment Apartment) {
            if (Apartment == null)
            {
                return BadRequest("Product data is required.");
            }
            _apartmentRepository.Add(Apartment);
            return Created();
        }
    }
}
