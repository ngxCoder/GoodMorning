using Microsoft.AspNetCore.Mvc;
using GoodMorning.Models;
using System.Net.Mime;
using GoodMorning.Services;

namespace GoodMorning.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[ApiController]
[Route("GoodMorning")]
public class GoodMorningController : ControllerBase
{
    private readonly TimeAPIService _timeAPIService;

    public GoodMorningController(TimeAPIService timeAPIService)
    {
        _timeAPIService = timeAPIService;
    }

    [HttpGet("Time")]
    public async Task<TimeResponse?> GetTime()
    {
        try
        {
            return await _timeAPIService.GetTimeAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Custom Internal server error");
        }

    }
}