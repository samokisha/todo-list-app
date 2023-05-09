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
    public async Task<IActionResult> PostAsync([FromBody] ToDoCreateRequestModel createRequestModel)
    {
        var response = await ResponseAsync<ToDoCreateRequestModel, ToDoItemResponseModel>(createRequestModel);

        return Ok(response);
    }

    [HttpGet("items")]
    public async Task<IActionResult> GetAsync([FromQuery] ToDoReadRequestModel readRequestModel)
    {
        var response = await ResponseAsync<ToDoReadRequestModel, SearchRequestResultModel>(readRequestModel);

        if (response.ResponseModel != null)
        {
            return Ok(response.ResponseModel);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("items")]
    public async Task<IActionResult> PutAsync([FromBody] ToDoUpdateRequestModel updateRequestModel)
    {
        var response = await ResponseAsync<ToDoUpdateRequestModel, SearchRequestResultModel>(updateRequestModel);

        if (response.ResponseModel != null)
        {
            return Ok(response.ResponseModel);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("items")]
    public async Task<IActionResult> DeleteAsync([FromBody] ToDoDeleteRequestModel deleteRequestModel)
    {
        var response = await ResponseAsync<ToDoDeleteRequestModel, ToDoDeleteResponseModel>(deleteRequestModel);

        if (response.Id != null)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}
