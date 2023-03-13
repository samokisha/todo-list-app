using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;

namespace ToDoList.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    [HttpPost("items")]
    public async Task<IActionResult> Post([FromBody] IRequestClient<ToDoCreateRequestModel> createRequestModel, CancellationToken cancellationToken)
    {
        var response = await createRequestModel.GetResponse<ToDoItemResponseModel>(new(), cancellationToken);
        return Ok(response.Message);
    }

    [HttpGet("items")]
    public async Task<IActionResult> Get([FromQuery] IRequestClient<ToDoReadRequestModel> readRequestModel, CancellationToken cancellationToken)
    {
        var response = await readRequestModel.GetResponse<ToDoItemResponseModel>(new(), cancellationToken);
        return Ok(response.Message);
    }

    [HttpPut("items")]
    public async Task<IActionResult> Put([FromBody] IRequestClient<ToDoUpdateRequestModel> updateRequestModel, CancellationToken cancellationToken)
    {
        var response = await updateRequestModel.GetResponse<ToDoItemResponseModel>(new(), cancellationToken);
        return Ok(response.Message);
    }

    [HttpDelete("items")]
    public async Task<IActionResult> Delete([FromBody] IRequestClient<ToDoDeleteRequestModel> deleteRequestModel, CancellationToken cancellationToken)
    {
        var response = await deleteRequestModel.GetResponse<ToDoDeleteResponseModel>(new(), cancellationToken);
        return Ok(response.Message);
    }
}
