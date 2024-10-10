using CraftIQ.Models;
using CraftIQ.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IRepository<Order> repo;

        public OrderController(IRepository<Order> _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = repo.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "OrderRoute")]
        public IActionResult GetById(Guid id)
        {
            var result = repo.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Order order)
        {
            if (ModelState.IsValid)
                repo.Add(order);
            else
                return BadRequest();

            var url = Url.Link("OrderRoute", new { id = order.Id });
            return Created(url, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Order order)
        {
            if (ModelState.IsValid)
                repo.Update(id, order);
            else
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Order order)
        {
            repo.Delete(order);
            return Ok();
        }
    }
}
