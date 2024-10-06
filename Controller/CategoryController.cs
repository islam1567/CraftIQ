using CraftIQ.Models;
using CraftIQ.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IRepository<Category> repo;

        public CategoryController(IRepository<Category> _repo) 
        {
            repo = _repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = repo.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "CategoryRoute")]
        public IActionResult GetById(Guid id)
        {
            var result = repo.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(ModelState.IsValid)
                repo.Add(category);
            else
                return BadRequest();

            var url = Url.Link("CategoryRoute", new { id = category.Id });
            return Created(url, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Category category)
        {
            if(ModelState.IsValid)
                repo.Update(id, category);
            else
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Category category)
        {
            repo.Delete(category);
            return Ok();
        }

    }
}
