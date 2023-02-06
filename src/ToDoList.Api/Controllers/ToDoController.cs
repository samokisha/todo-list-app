using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Requests;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        [HttpPost]
        [Route("items")]
        public IActionResult Post([FromBody] ToDoUpdateRequestModel updateRequestModel)
        {
            return (IActionResult)updateRequestModel;
        }
        [HttpGet]
        [Route("items")]
        public IActionResult Get([FromQuery] ToDoReadRequestModel readRequestModel)
        {
            return (IActionResult)readRequestModel;
        }
        [HttpPut]
        [Route("items")]
        public IActionResult Put([FromBody] ToDoCreateRequestModel createRequestModel)
        {
            return (IActionResult)createRequestModel;
        }
        [HttpDelete]
        [Route("items")]
        public IActionResult Delete([FromBody] ToDoDeleteRequestModel deleteRequestModel)
        {
            return (IActionResult)deleteRequestModel;
        }

    }
}
