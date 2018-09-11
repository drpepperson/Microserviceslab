namespace MicroservicesLab
{
    using MicroservicesLab.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class CalculatorRequest
    {
        [FunctionName("Calculation")]
        public static async Task<HttpResponseMessage> Run(
                    [HttpTrigger(AuthorizationLevel.Anonymous, "post", "put", Route = "Calculate")]HttpRequestMessage req,
                    [Queue("calculationrequests")] IAsyncCollector<CalculationRequest> sendQueue,
                    TraceWriter log)
        {
            try
            {
                log.Info("C# HTTP trigger function processed a request.");

                // Get request body
                var data = await req.Content.ReadAsAsync<CalculationRequest>();

                await sendQueue.AddAsync(data);

                return req.CreateResponse(HttpStatusCode.OK, "Processing your request for " + data.Id);
            }
            catch (Exception exception)
            {
                return req.CreateResponse(HttpStatusCode.InternalServerError,
                    exception.Message.ToString() + exception.StackTrace.ToString());
            }
        }
    }
}
