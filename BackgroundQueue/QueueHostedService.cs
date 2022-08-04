using BackgroundQueue.Queue;

namespace BackgroundQueue
{
    public class QueueHostedService : BackgroundService
    {
        private readonly ILogger<QueueHostedService> _logger;
        private readonly IBackgroundTaskQueue<string> _queue;

        public QueueHostedService(ILogger<QueueHostedService> logger, IBackgroundTaskQueue<string> queue)
        {
            _logger = logger;
            _queue = queue;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var name = await _queue.DeQueue(stoppingToken);

                await Task.Delay(1000); //db insert 

                _logger.LogInformation($"ExecuteAsync worked for {name}");
            }
        }
    }
}
