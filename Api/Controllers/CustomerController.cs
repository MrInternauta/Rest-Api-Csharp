using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public CustomerController()
        {

        }
        [HttpGet()]
        public IActionResult getCustomer() {
            return new JsonResult(
                Repository.intance.customers
            );
        
        }
        //recibe id
        [HttpGet("{id}")]
        public IActionResult getCustomer(int id)
        {
            var res = Repository.intance.customers.FirstOrDefault(c => c.id == id);
            if (res == null) { return NotFound(); }
            return Ok(res);
        }

    }
}
