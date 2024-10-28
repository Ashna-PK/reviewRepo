using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fatWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        [HttpGet]
        public string GetRandom()
        {
            return "get all string";
        }
        [HttpGet]
        public string GetSingleRandom()
        {
            return "get a string";
        }

    }


}
