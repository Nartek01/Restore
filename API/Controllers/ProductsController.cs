using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /** Skapa en API fält, som heter "Products" */
    [ApiController] // Attribut
    [Route("api/[controller]")] // API Rutt
    public class ProductsController : ControllerBase // Skapar en ny klass ProductsController som förlänger ControllerBase
    {
        /**
        Dependecy Injection, 
        Förläng den nuvarande klassen med StoreContext klassen,
        annars kommer vi inte åt "Products tabellen".
        */
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            /**
            Först förlänger vi ProductsController klassen med StoreConetx.cs/klassen.
            Sen skicka vi med det som en paramter i ProductsController metoden/funktionen...
            */
            this.context = context; // För att senare lägga det till våran LOKALA context konstanten.
        }
        [HttpGet] // Returnerar en lista med produkter
        public ActionResult<List<Product>> GetProducts() 
        {
            var products = context.Products.ToList(); // Hämta data från "Products" DB tabellen, lägg det senare inuti inuti variabeln "products".

            return Ok(products); // Returnera den populerade "products" listan med en 200 OK
        }

        [HttpGet("{id}")] // API Rutt
        public ActionResult<Product> GetProduct(int id) // Skapa en kontroller fält som vill ha ett products id
        {
            return context.Products.Find(id);// Passa med id paramtern till Find metoden och returnera det.
        }
    }
}