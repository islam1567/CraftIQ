using CraftIQ.Models;
using CraftIQ.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        IRepository<Transactions> repo;

        public TransactionController(IRepository<Transactions> _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = repo.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "TransactionRoute")]
        public IActionResult GetById(Guid id)
        {
            var result = repo.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Transactions transactions)
        {
            if (ModelState.IsValid)
                repo.Add(transactions);
            else
                return BadRequest();

            var url = Url.Link("TransactionRoute", new { id = transactions.Id });
            return Created(url, transactions);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Transactions transactions)
        {
            if (ModelState.IsValid)
                repo.Update(id, transactions);
            else
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Transactions transactions)
        {
            repo.Delete(transactions);
            return Ok();
        }
    }
}
