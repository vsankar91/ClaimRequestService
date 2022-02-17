using Azure;
using Azure.Messaging.EventGrid;
using FineosClaimService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FineosClaimService.Services
{
    public class EventGridService : IEventGridService
    {
        private readonly EventGridPublisherClient _publisherClient;

        public EventGridService(IConfiguration configuration)
        {
            _publisherClient = new EventGridPublisherClient(new Uri(configuration.ClaimRequestTopicEndPoint),
                new AzureKeyCredential(configuration.ClaimRequestTopicAccessKey));
        }

        public async Task TriggerEvent<T>(string subject, string eventType, T payload)
        {
            try
            {
                var gridEvent = new EventGridEvent(subject, eventType, "1.0", payload);
                await _publisherClient.SendEventAsync(gridEvent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}