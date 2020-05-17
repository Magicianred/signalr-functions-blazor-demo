using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Extensions.Storage;


namespace MadeByGPS.Function
{
    public static class Function
    {

        private static HttpClient httpClient = new HttpClient();
        
        [FunctionName("Function")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Queue("quote-notifications")] IAsyncCollector<IncomingQuote> notifications,
            ILogger log)
        {

            // Get quote from stoic api.
            var response = await httpClient.GetAsync("https://api.stoic.rest/quote");

            // Read the json into a string.
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialze string to incoming quote object.
            var incomingQuote = JsonConvert.DeserializeObject<IncomingQuote>(responseBody);

            // Add to queue storage.
            await notifications.AddAsync(incomingQuote);

            return new OkObjectResult($"{incomingQuote.Author}: {incomingQuote.Quote}");
        }
    
    
       [FunctionName("Negotiate")]
       public static SignalRConnectionInfo GetConnectionInfo(
           [HttpTrigger (AuthorizationLevel.Anonymous,"post")] HttpRequest req,
           [SignalRConnectionInfo (HubName="notifications")] SignalRConnectionInfo connectionInfo
       )
       {
           return connectionInfo;
       }

       [FunctionName("SendQuoteNotification")]
       public static async Task SendQuoteNotification(
           [QueueTrigger("quote-notifications")] IncomingQuote incomingQuote,
           [SignalR(HubName="notifications")] IAsyncCollector<SignalRMessage> signalRMessage,
           ILogger log
       )
       {
           await signalRMessage.AddAsync (
               new SignalRMessage{
                   Target = "incomingQuote",
                    Arguments = new [] {incomingQuote}
               }
           );

       }
    

    
    }

    public class IncomingQuote {
        public string Author {get; set;}
        public string Quote {get; set;}
    }

    
}
