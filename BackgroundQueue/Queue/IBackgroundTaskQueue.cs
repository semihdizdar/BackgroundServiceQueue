namespace BackgroundQueue.Queue
{
    public interface IBackgroundTaskQueue<T>
    {
        ValueTask AddQueue(T workItem);
        ValueTask<T> DeQueue(CancellationToken cancellationToken);
    }
}
