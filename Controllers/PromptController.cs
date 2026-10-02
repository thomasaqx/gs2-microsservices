using Microsoft.AspNetCore.Mvc;
using PromptApi.Models;
using PromptApi.Services;

namespace PromptApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromptController : ControllerBase
    {
        private readonly IPromptService _service;
        private readonly ILogger<PromptController> _logger;

        public PromptController(IPromptService service, ILogger<PromptController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Prompt prompt)
        {
            var id = await _service.CreateAsync(prompt);
            prompt.Id = id;
            return CreatedAtAction(nameof(GetById), new { id }, prompt);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Prompt prompt)
        {
            var ok = await _service.UpdateAsync(id, prompt);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
