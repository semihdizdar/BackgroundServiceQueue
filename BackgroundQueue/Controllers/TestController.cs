using BackgroundQueue.Queue;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly IBackgroundTaskQueue<string> _queue;

        public TestController(IBackgroundTaskQueue<string> queue)
        {
            _queue = queue;
        }


        [HttpPost]
        public async Task<IActionResult> AddQueue(string[] message)
        {
            foreach (var item in message)
            {
                await _queue.AddQueue(item);
            }
            return Ok();
        }
    }
}
