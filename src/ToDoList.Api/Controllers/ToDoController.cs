using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;

namespace ToDoList.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    [HttpPost("items")]
    public IActionResult Post([FromBody] ToDoCreateRequestModel createRequestModel)
    {
        return Ok(new ToDoItemResponseModel());
    }

    [HttpGet("items")]
    public IActionResult Get([FromQuery] ToDoReadRequestModel readRequestModel)
    {
        return Ok(new ToDoItemResponseModel());
    }

    [HttpPut("items")]
    public IActionResult Put([FromBody] ToDoUpdateRequestModel updateRequestModel)
    {
        return Ok(new ToDoUpdateRequestModel());
    }

    [HttpDelete("items")]
    public IActionResult Delete([FromBody] ToDoDeleteRequestModel deleteRequestModel)
    {
       return Ok(new ToDoDeleteResponseModel());
    }
}
