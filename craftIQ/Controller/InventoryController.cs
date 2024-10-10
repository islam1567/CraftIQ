using CraftIQ.Models;
using CraftIQ.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        IRepository<Inventory> repo;

        public InventoryController(IRepository<Inventory> _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = repo.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "InventoryRoute")]
        public IActionResult GetById(Guid id)
        {
            var result = repo.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Inventory inventory)
        {
            if (ModelState.IsValid)
                repo.Add(inventory);
            else
                return BadRequest();

            var url = Url.Link("InventoryRoute", new { id = inventory.Id });
            return Created(url, inventory);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Inventory inventory)
        {
            if (ModelState.IsValid)
                repo.Update(id, inventory);
            else
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Inventory inventory)
        {
            repo.Delete(inventory);
            return Ok();
        }
    }
}
