using DOTnetcoreAPI.Data;
using DOTnetcoreAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcoreAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsApiController: ControllerBase
    {
        private readonly IDOTnetRepository _repository;
        private readonly ILogger<ProductsApiController> _logger;

        public ProductsApiController(IDOTnetRepository repository,ILogger<ProductsApiController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Get All Products is called ...");     
                return Ok(_repository.GetProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex.Message}");
                return BadRequest("Failed to get all products");
            }
        }


    }
}
