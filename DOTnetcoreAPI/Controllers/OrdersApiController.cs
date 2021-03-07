using DOTnetcoreAPI.Data;
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
    public class OrdersApiController:ControllerBase
    {
        private readonly IDOTnetRepository _repository;
        private readonly ILogger _logger;

        public OrdersApiController(IDOTnetRepository repository,ILogger<OrdersApiController> logger)
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
            _logger.LogInformation("Get all orders is Called ...");
            return Ok(_repository.GetAllOrders());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex.Message}");
                return BadRequest("Failed to get all orders");
            }
        }

    }
}
