namespace MicroservicesLab
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;

    public static class CalculatorResponse
    {
        [FunctionName("CalculationResponse")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "put", Route = "Calculate/{CalculationId}")]HttpRequestMessage req, string CalculationId,
            [Blob("calculationresponses/{CalculationId}", FileAccess.Read)] string calculatedRequest,
            TraceWriter log)
        {
            try
            {
                log.Info("C# HTTP trigger function processed a request.");


                var responseObject = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(calculatedRequest, Encoding.UTF8, "application/json")
                };

                return responseObject;
            }
            catch (Exception exception)
            {
                return req.CreateResponse(HttpStatusCode.InternalServerError,
                    exception.Message.ToString() + exception.StackTrace.ToString());
            }
        }
        
    }
}
