using Taxually.TechnicalTest.DL.Interfaces;

namespace Taxually.TechnicalTest.DL.Queue
{
    public class TaxuallyQueueClient : IQueue
    {
        public Task EnqueueAsync<TPayload>(string queueName, TPayload payload)
        {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}