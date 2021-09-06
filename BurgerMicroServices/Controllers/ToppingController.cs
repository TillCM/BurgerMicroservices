using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerMicroServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerMicroServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToppingController : ControllerBase
    {
       private  BurgerContext burgerContext;

       public ToppingController()
       {
           burgerContext = new BurgerContext();
       }

        [HttpGet]
        public List<Topping> Get()
        {
            return burgerContext.Toppings.ToList();
        }
    }
}
