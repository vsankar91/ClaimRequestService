using Azure.Messaging.ServiceBus;
using FineosClaimService.Services.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FineosClaimService.Services
{
    public class ServiceBusMessagingService : IServiceBusMessagingService
    {
        private readonly IConfiguration _configuration;
        private readonly ServiceBusClient _sbClient;
        private readonly ServiceBusSender _sbMessageSender;

        public ServiceBusMessagingService(IConfiguration configuration)
        {
            _configuration = configuration;
            _sbClient = new ServiceBusClient(_configuration.ServiceBusConnectionString);
            _sbMessageSender = _sbClient.CreateSender(_configuration.ClaimRequestQeueName);
        }

        public async Task SendMessageAsync<T>(T payload)
        {
            try
            {
                if (_sbClient.IsClosed)
                {
                    throw new Exception("Service bus closed");
                }
                var messagePayload = JsonSerializer.Serialize(payload);
                ServiceBusMessage message = new ServiceBusMessage(messagePayload);
                await _sbMessageSender.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}