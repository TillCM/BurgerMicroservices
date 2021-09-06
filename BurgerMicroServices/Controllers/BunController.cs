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
    public class BunController : ControllerBase
    {
       private  BurgerContext burgerContext;

       public BunController()
       {
           burgerContext = new BurgerContext();
       }

        [HttpGet]
        public List<Bun> Get()
        {
            return burgerContext.Buns.ToList();
        }
    }
}
