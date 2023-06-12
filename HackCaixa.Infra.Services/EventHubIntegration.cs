
using Microsoft.Azure.EventHubs;
using System;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using HackCaixa.Domain.Interfaces;

namespace HackCaixa.Infra.Services
{
    public class EventHubIntegration : IEventHubIntegration
    {
        private EventHubClient eventHubClient;
        private string eventHubConnectionString;
        

        public EventHubIntegration(string connectionString)
        {
            eventHubConnectionString = connectionString;
            
        }

        public async Task SendMessageAsync<T>(T message)
        {
            if (eventHubClient == null)
            {
                eventHubClient = EventHubClient.CreateFromConnectionString(eventHubConnectionString);
            }

            try
            {
                var jsonMessage = JsonConvert.SerializeObject(message);
                var eventData = new EventData(Encoding.UTF8.GetBytes(jsonMessage));
                await eventHubClient.SendAsync(eventData);
            }
            catch (Exception ex)
            {
                // Trate qualquer exceção de envio de mensagem
                Console.WriteLine($"Erro ao enviar mensagem para o Event Hub: {ex.Message}");
            }
        }

        public async Task CloseConnectionAsync()
        {
            if (eventHubClient != null)
            {
                await eventHubClient.CloseAsync();
            }
        }
    }
}
