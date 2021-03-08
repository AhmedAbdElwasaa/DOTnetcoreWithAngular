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
        public IActionResult Get(bool includeItems=true)
        {
            try
            {
            _logger.LogInformation("Get all orders is Called ...");
            return Ok(_repository.GetAllOrders(includeItems));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex.Message}");
                return BadRequest("Failed to get all orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logger.LogInformation("Get one order is called ...");
                var order = _repository.GetOrderById(id);
               if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get one order: {ex.Message}");
                return BadRequest("Failed to get one order");
                
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order model)
        {
            try
            {
                _repository.AddEntity(model);
                _repository.SaveAll();

                return Created($"/api/ordersapi/{model.Id}",model);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to post order model: {model}, exception message: {ex.Message}");
                return BadRequest("Failed to post order model");
             
            }
        }

    }
}
