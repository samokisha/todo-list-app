using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Controllers.Base;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using ToDoService.Managers;

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
        var response = await ResponseAsync<ToDoCreateRequestModel, ToDoItemResponseModel>(createRequestModel);

        if (response != null)
        {
            return Ok(response);
        }
        else
        {
            return NotFound(response);
        }
    }

    [HttpGet("items")]
    public async Task<IActionResult> Get([FromQuery] ToDoReadRequestModel readRequestModel)
    {
        var response = await ResponseAsync<ToDoReadRequestModel, SearchRequestResultModel>(readRequestModel);

        if (response.ResponseModel != null)
        {
            return Ok(response.ResponseModel);
        }
        else
        {
            return NotFound(response.ResponseModel);
        }
    }

    [HttpPut("items")]
    public async Task<IActionResult> Put([FromBody] ToDoUpdateRequestModel updateRequestModel)
    {
        var response = await ResponseAsync<ToDoUpdateRequestModel, SearchRequestResultModel>(updateRequestModel);

        if (response.ResponseModel != null)
        {
            return Ok(response.ResponseModel);
        }
        else
        {
            return NotFound(response.ResponseModel);
        }
    }

    [HttpDelete("items")]
    public async Task<IActionResult> Delete([FromBody] ToDoDeleteRequestModel deleteRequestModel)
    {
        var response = await ResponseAsync<ToDoDeleteRequestModel, ToDoDeleteResponseModel>(deleteRequestModel);

        if (response != null)
        {
            return Ok(response);
        }
        else
        {
            return NotFound(response);
        }
    }
}
