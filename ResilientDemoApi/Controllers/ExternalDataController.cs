using Microsoft.AspNetCore.Mvc;
using ResilientDemoApi.Services;
using ResilientDemoApi.Models;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ExternalDataController : ControllerBase
{
    private readonly IExternalDataService _externalDataService;

    public ExternalDataController(IExternalDataService externalDataService)
    {
        _externalDataService = externalDataService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ExternalDataResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ExternalDataResponse>> GetExternalData()
    {
        try
        {
            var data = await _externalDataService.GetDataFromExternalApiAsync();

            return Ok(new ExternalDataResponse
            {
                Data = data
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {error = "Internal server error"});
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ExternalDataResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ExternalDataResponse>> GetTimeOut()
    {
        try
        {
            var data = await _externalDataService.GetTimeOutFromExternalApiAsync();

            return Ok(new ExternalDataResponse
            {
                Data = data
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {error = "Internal server error"});
        }
    }

    [HttpGet("usd-rate")]
    [ProducesResponseType(typeof(ExternalDataResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<string>> GetUsdRate([FromQuery] DateTime date)
    {
        var xml = await _externalDataService.GetFromCbApiAsync();
        return Ok(xml);
    }
}