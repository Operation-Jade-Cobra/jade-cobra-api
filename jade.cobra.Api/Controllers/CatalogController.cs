using Microsoft.AspNetCore.Mvc;
using jade.cobra.Domain.Catalog;
using jade.cobra.Data;
using System.Xml;

namespace jade.cobra.Api.Controllers
{
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase{
        
        private readonly StoreContext _db;
        public CatalogController(StoreContext db){
            _db = db;
        }

        [HttpGet]
        /*public IActionResult GetItems(){
            var items = new List<Item>{
                new Item("Shirt", "Ohio State shirt", "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts", "Nike", 44.99m),
            };
            return Ok(items);
        }*/

        public IActionResult GetItems(){
            return Ok(_db.Items);
        }



        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id){
            var item = new Item("Shirt", "Ohio State shirt", "Nike", 29.99m);
            item.Id = id;
            return Ok(item);
        }


        [HttpPost]
        public IActionResult Post(Item item){
            return Created("/catalog/42", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);

            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item){
            //return Ok(item);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id){
            //return Ok("Deleted!");
            return NoContent();
        }

    }
}