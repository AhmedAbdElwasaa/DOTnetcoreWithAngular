using DOTnetcoreAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcoreAPI.Controllers
{
    /// <summary>
    /// Association Controller
    /// </summary>
    [Route("api/ordersapi/{orderid}/items")]
    [ApiController]
    [Produces("application/json")]
    public class OrderItemApiController:ControllerBase
    {
        private readonly IDOTnetRepository _repository;
        private readonly ILogger<OrderItemApiController> _logger;

        public OrderItemApiController(IDOTnetRepository repository,ILogger<OrderItemApiController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get(int orderId)
        {
            try
            {
                _logger.LogInformation("Get all items for order is called ... ");
                var order = _repository.GetOrderById(orderId);
                if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to get all items for orderId: {orderId},exception message: {ex.Message} ");
                return BadRequest("Faild to get all items for order");
            }

        }
        [HttpGet("{id}")]
        public IActionResult Get(int orderId,int id)
        {
            try
            {
                _logger.LogInformation("Get item order by id is called ...");
                var order = _repository.GetOrderById(orderId);
                if (order != null)
                {
                    var orderItem = order.Items.Where(i => i.Id == id).FirstOrDefault();
                    if (orderItem != null) return Ok(orderItem);
                    else return NotFound();
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to get item order where order id: {orderId} and item id: {id}, exception message: {ex.Message} ");
                return BadRequest("Failedto Get itemorder data");
            }
        }

    }
}
