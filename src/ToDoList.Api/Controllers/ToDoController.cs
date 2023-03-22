using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Controllers.Base;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;

namespace ToDoList.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : BaseController
{
    public ToDoController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpPost("items")]
    public async Task<IActionResult> Post([FromBody] ToDoCreateRequestModel createRequestModel)
    {
        var result = await ResponseAsync<ToDoCreateRequestModel, ToDoItemResponseModel>(createRequestModel);
        return Ok(result);
    }

    [HttpGet("items")]
    public async Task<IActionResult> Get([FromQuery] ToDoReadRequestModel readRequestModel)
    {
        var result = await ResponseAsync<ToDoReadRequestModel,ToDoItemResponseModel>(readRequestModel);
        return Ok(result);
    }

    [HttpPut("items")]
    public async Task<IActionResult> Put([FromBody] ToDoUpdateRequestModel updateRequestModel)
    {
        var result = await ResponseAsync<ToDoUpdateRequestModel,ToDoItemResponseModel>(updateRequestModel);
        return Ok(result);
    }

    [HttpDelete("items")]
    public async Task<IActionResult> Delete([FromBody] ToDoDeleteRequestModel deleteRequestModel)
    {
        var result = await ResponseAsync<ToDoDeleteRequestModel,ToDoDeleteResponseModel>(deleteRequestModel);
        return Ok(result);
    }
}
