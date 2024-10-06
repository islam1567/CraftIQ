using CraftIQ.Models;
using CraftIQ.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        IRepository<OrderDetails> repo;

        public OrderDetailsController(IRepository<OrderDetails> _repo)
        {
            repo = _repo;
        }

        [HttpGet]
         public IActionResult Get()
         {
             var result = repo.GetAll();
             return Ok(result);
         }

         [HttpGet("{id}", Name = "OrderDetailsRoute")]
         public IActionResult GetById(Guid id)
         {
             var result = repo.GetById(id);
             return Ok(result);
         }

         [HttpPost]
         public IActionResult Add(OrderDetails orderdetails)
         {
             if (ModelState.IsValid)
                 repo.Add(orderdetails);
             else
                 return BadRequest();

             var url = Url.Link("OrderRoute", new { id = orderdetails.Id });
             return Created(url, orderdetails);
         }

         [HttpPut("{id}")]
         public IActionResult Update(Guid id, OrderDetails orderdetails)
         {
             if (ModelState.IsValid)
                 repo.Update(id, orderdetails);
             else
                 return BadRequest();

             return Ok();
         }

         [HttpDelete("{id}")]
         public IActionResult Delete(OrderDetails orderdetails)
         {
             repo.Delete(orderdetails);
             return Ok();
         }
    }
}
