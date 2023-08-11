using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppExample.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public string[] GetDishes()
        {
            string[] dishes = {"Oxtail", "Curry Chicken", "Dumplings"};
            return dishes;
        }
    }
}
