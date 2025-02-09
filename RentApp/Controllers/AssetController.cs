using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentApp.Domain.Abstraction;
using RentApp.Domain.Entities;

namespace RentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IBaseRepository<Asset> _assetRepository;
        public AssetController(IBaseRepository<Asset> apartmentRepository)
        {
            _assetRepository = apartmentRepository;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_assetRepository.GetById(id));
        }
    }
}
