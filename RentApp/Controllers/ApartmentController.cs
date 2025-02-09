using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentApp.Domain.Abstraction;

namespace RentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IBaseRepository<ApartmentController> _apartmentRepository;
        public ApartmentController(IBaseRepository<ApartmentController> apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        [HttpGet]
        public IActionResult GetById(int id) {
            return Ok(_apartmentRepository.GetById(id));
        }
    }
}
