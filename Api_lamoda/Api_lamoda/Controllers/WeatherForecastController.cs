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

        // 1. Метод GetAll с сортировкой
        [HttpGet]
        public IActionResult GetAll([FromQuery] int? sortStrategy = null)
        {
            if (sortStrategy == null)
                return Ok(Summaries);
            if (sortStrategy == 1)
                return Ok(Summaries.OrderBy(s => s).ToList());
            if (sortStrategy == -1)
                return Ok(Summaries.OrderByDescending(s => s).ToList());

            return BadRequest("Некорректное значение параметра sortStrategy");
        }

        // 2. Метод для получения одного элемента по индексу
        [HttpGet("{index:int}")]
        public IActionResult GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Индекс выходит за пределы допустимого диапазона.");

            return Ok(Summaries[index]);
        }

        [HttpGet("find-by-name")]
        public IActionResult GetCountByName(string name)
        {
           
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Имя не может быть пустым или состоять только из пробелов.");

        
            if (Summaries == null)
                return StatusCode(500, "Коллекция данных недоступна.");

          
            var count = Summaries.Count(s => s.Equals(name, StringComparison.OrdinalIgnoreCase));

          
            return Ok(new
            {
                Count = count,
                Message = count == 0 ? $"Имя '{name}' не найдено." : $"Найдено {count} записей для имени '{name}'."
            });
        }

        // Метод для добавления нового элемента
        [HttpPost]
        public IActionResult Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Имя не может быть пустым.");

            Summaries.Add(name);
            return Ok();
        }

        // Метод для обновления элемента
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Индекс выходит за пределы допустимого диапазона.");

            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Имя не может быть пустым.");

            Summaries[index] = name;
            return Ok();
        }

        // Метод для удаления элемента
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Индекс выходит за пределы допустимого диапазона.");

            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}
