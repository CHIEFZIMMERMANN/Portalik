using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.API.Data;

namespace Portal.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly DataContext _context;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        var values = await _context.Values.ToListAsync();
        return Ok(values);
    }

    [HttpGet(Name = "GetWeatherForecast/{id}")]
    public IActionResult Get(int id)
    {
        var value = _context.Values.FirstOrDefault(x => x.Id == id);
        return Ok(value);
    }

    [HttpPost]
    public void AddValue([FromBody] WeatherForecast value)
    {
        _context.Values.Add(value);
        _context.SaveChanges();
    }

    [HttpPut("{id}")]
    public void EditValue(int id, [FromBody] WeatherForecast value)
    {
        var data = _context.Values.Find(id);
        data.Summary = value.Summary;
        _context.Values.Update(data);
        _context.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void DeleteValue(int id)
    {
        var data = _context.Values.Find(id);
        _context.Remove(data);
        _context.SaveChanges();
    }
}
