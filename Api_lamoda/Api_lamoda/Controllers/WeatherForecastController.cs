using Microsoft.AspNetCore.Mvc;

namespace Api_lamoda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // 1. ����� GetAll � �����������
        [HttpGet]
        public IActionResult GetAll([FromQuery] int? sortStrategy = null)
        {
            if (sortStrategy == null)
                return Ok(Summaries);
            if (sortStrategy == 1)
                return Ok(Summaries.OrderBy(s => s).ToList());
            if (sortStrategy == -1)
                return Ok(Summaries.OrderByDescending(s => s).ToList());

            return BadRequest("������������ �������� ��������� sortStrategy");
        }

        // 2. ����� ��� ��������� ������ �������� �� �������
        [HttpGet("{index:int}")]
        public IActionResult GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("������ ������� �� ������� ����������� ���������.");

            return Ok(Summaries[index]);
        }

        [HttpGet("find-by-name")]
        public IActionResult GetCountByName(string name)
        {
           
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("��� �� ����� ���� ������ ��� �������� ������ �� ��������.");

        
            if (Summaries == null)
                return StatusCode(500, "��������� ������ ����������.");

          
            var count = Summaries.Count(s => s.Equals(name, StringComparison.OrdinalIgnoreCase));

          
            return Ok(new
            {
                Count = count,
                Message = count == 0 ? $"��� '{name}' �� �������." : $"������� {count} ������� ��� ����� '{name}'."
            });
        }

        // ����� ��� ���������� ������ ��������
        [HttpPost]
        public IActionResult Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("��� �� ����� ���� ������.");

            Summaries.Add(name);
            return Ok();
        }

        // ����� ��� ���������� ��������
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("������ ������� �� ������� ����������� ���������.");

            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("��� �� ����� ���� ������.");

            Summaries[index] = name;
            return Ok();
        }

        // ����� ��� �������� ��������
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("������ ������� �� ������� ����������� ���������.");

            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}
