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
        private readonly IUnitOfWork _unitOfWork;
        public AssetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        //Get
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Asset = _unitOfWork.Apartments.GetById(id);
            return Ok(Asset);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<Asset> assets;
            assets = _unitOfWork.Assets.GetAll();
            return Ok(assets);
        }
        [HttpGet("sorted")]
        public IActionResult GetSorted([FromQuery] string sortBy = "Name", [FromQuery] bool ascending = true)
        {
            IEnumerable<Asset> assets;
            switch (sortBy.ToLower())
            {
                case "name":
                    assets = _unitOfWork.Assets.GetAllSorted(a => a.Name, ascending);
                    break;
                default:
                    assets = _unitOfWork.Assets.GetAllSorted(a => a.ID, ascending);
                    break;

            }
            return Ok(assets);
        }
        [HttpPost]
        public IActionResult AddAsset([FromBody] Asset asset)
        {
            if (asset == null)
            {
                return BadRequest("Asset's data is required.");
            }
            _unitOfWork.Assets.Add(asset);
            return Created();
        }
    }
}
