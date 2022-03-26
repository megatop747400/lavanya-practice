using web_api_1.Models;
using web_api_1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace web_api_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        // GET by Id action
        [HttpGet("{id}", Name = "GetPizza")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        // POST action
        [HttpPost]
        public ActionResult Add(Pizza pizzaToAdd)
        {
            PizzaService.Add(pizzaToAdd);

            return CreatedAtRoute(
            routeName: "GetPizza",
            routeValues: new { id = pizzaToAdd.Id },
            value: pizzaToAdd);
        }

        // PUT action
        [HttpPut("{id}")]
        public ActionResult Update(int id, Pizza pizzaToUpdate)
        {
            if(id != pizzaToUpdate.Id)
            return BadRequest();

            var pizza = PizzaService.Get(pizzaToUpdate.Id);
            if(pizza == null) 
            return NotFound();

            PizzaService.Update(pizzaToUpdate);

            return NoContent();
        }

        // DELETE action
    }
}