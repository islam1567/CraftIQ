using CraftIQ.Models;
using CraftIQ.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IRepository<Products> repo;

        public ProductController(IRepository<Products> _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = repo.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name ="ProductRoute")]
        public IActionResult GetById(Guid id)
        {
            var result = repo.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Products products)
        {
            if(ModelState.IsValid)
                repo.Add(products);
            else
                return BadRequest();

            string url = Url.Link("ProductRoute", new { id = products.Id });
            return Created(url, products);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Products products)
        {
            if(ModelState.IsValid)
                repo.Update(id, products);
            else
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Products products)
        {
            repo.Delete(products);
            return Ok();
        }

    }
}
