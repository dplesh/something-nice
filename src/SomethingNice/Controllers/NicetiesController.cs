using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomethingNice.Models;

namespace SomethingNice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NicetiesController : ControllerBase
    {
        private readonly Random _random;

        public NicetiesController(Random random)
        {
            _random = random;
        }

        IQueryable<Nicetie> niceties = new List<Nicetie>
        {
           new Nicetie{Text= "\"I have always believed that each man makes his own happiness and is responsible for his own problems. It is a simple philosophy.\"", Author= new Author{ Name = "Ray Kroc"}},
           new Nicetie{Text= "\"Anger is the ultimate destroyer of your own peace of mind.\"", Author = new Author{Name = "Dalai Lama"}},
           new Nicetie{Text= "\"Don't be afraid. Be focused. Be determined. Be hopeful. Be empowered.\"", Author = new Author{Name = "Michelle Obama"}},
           new Nicetie{Text= "\"No one would have crossed the ocean if he could have gotten off the ship in the storm.\"", Author = new Author{Name = "Charles Kettering"}},
           new Nicetie{Text= "\"Appreciate those early influences and what they've done for you.\"", Author = new Author{Name = "Willie Davis"}},
           new Nicetie{Text= "\"If you want to see a rainbow you have to learn to see the rain.\"", Author = new Author{Name = "Paulo Coelho"}},

        }.AsQueryable();

        public ActionResult<Nicetie> Get()
        {
            return niceties.OrderBy(n => _random.Next()).First();
        }

    }
}
