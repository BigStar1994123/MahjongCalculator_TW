using Microsoft.AspNetCore.Mvc;

namespace MahjongCalculator_TW.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EfficiencyController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<long>> GetTodoItem(long id)
    {
        return id;
    }
}