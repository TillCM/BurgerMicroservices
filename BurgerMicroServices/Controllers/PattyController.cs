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
    public class PattyController : ControllerBase
    {
       private  BurgerContext burgerContext;

       public PattyController()
       {
           burgerContext = new BurgerContext();
       }

        [HttpGet]
        public List<Patty> Get()
        {
            return burgerContext.Patties.ToList();
        }
    }
}
