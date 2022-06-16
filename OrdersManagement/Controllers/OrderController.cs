using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Models;
using OrderManagement.Service.Contracts;


namespace OrdersManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
                _orderService= orderService; 
        }
        // GET: api/<OrderController>
        [HttpGet("getorders/{id}")]
        public async Task<IActionResult> GetOrders(string id)
        {
            try
            {
                var orders = await _orderService.GetOrders(id);

                if (orders != null)
                    return Ok(orders);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);

                if (order != null)
                    return Ok(order);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto order)
        {
            try
            {
                var orders = await _orderService.CreateOrder(order);

                if (orders != null)
                    return Ok(orders);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] OrderDto order)
        {
            try
            {
                var orders = await _orderService.UpdateOrderById(order);

                if (orders != null)
                    return Ok(orders);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<OrderController>/5/id
        [HttpDelete("{id}/{userId}")]
        public async Task<IActionResult> Delete(string id,string userId)
        {

            try
            {
                var orders = await _orderService.DeleteOrderById(id,userId);

                if (orders != null)
                    return Ok(orders);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
