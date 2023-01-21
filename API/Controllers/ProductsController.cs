using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet] // Ange vilken HTTP metod som skall användas
        public async Task<ActionResult<List<Product>>> GetProducts() // Returnerar en lista med produkter
        {
            var products = await context.Products.ToListAsync(); // Hämta data från "Products" DB tabellen, lägg det senare inuti inuti variabeln "products".

            return Ok(products); // Returnera den populerade "products" listan med en 200 OK
        }

        [HttpGet("{id}")] // API Rutt
        /** 
        async Task<> Gör så att koden körs asynkront
        */
        public async Task<ActionResult<Product>> GetProduct(int id) // Skapa en kontroller fält som vill ha ett products id
        {
            /** När async är färdig så returnera den promise.  */
            return await context.Products.FindAsync(id);// Passa med id paramtern till Find metoden och returnera det. 
        }
    }
}