using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DataAccesslayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductRepository prodrep;

        public ProductController()
        {
            prodrep=new ProductRepository();
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {

            return prodrep.Showall();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductModel value)
        {
            prodrep.Insert(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("(Update price)")]
        public void Put(decimal Price, [FromBody] string Name)
        {
            prodrep.Put(Price, Name);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete()]
        public void Delete(string Name)
        {
            prodrep.Delete(Name);

        }
    }
}
