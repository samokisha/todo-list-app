using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        [HttpPost("items")]
        public IActionResult Post([FromBody] ToDoCreateRequestModel createRequestModel)
        {
            return (IActionResult)new ToDoItemResponseModel();
        }

        [HttpGet("items")]
        public IActionResult Get([FromQuery] ToDoReadRequestModel readRequestModel)
        {
            return (IActionResult)new ToDoItemResponseModel();
        }

        [HttpPut("items")]
        public IActionResult Put([FromBody] ToDoUpdateRequestModel updateRequestModel)
        {
            return (IActionResult)new ToDoItemResponseModel();
        }

        [HttpDelete("items")]
        public IActionResult Delete([FromBody] ToDoDeleteRequestModel deleteRequestModel)
        {
            return (IActionResult)new ToDoDeleteResponseModel();
        }
    }
}
