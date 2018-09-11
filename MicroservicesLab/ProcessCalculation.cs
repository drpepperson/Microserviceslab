using System;
using System.IO;
using MicroservicesLab.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace MicroservicesLab
{
    public static class ProcessCalculation
    {
        [FunctionName("ProcessCalculation")]
        public static void Run([QueueTrigger("calculationrequests")]string myQueueItem,
            Binder binder,
            TraceWriter log)
        {
            var request = JsonConvert.DeserializeObject<CalculationRequest>(myQueueItem);

            log.Info($"C# Queue trigger function processed: {myQueueItem}");

            //Add Implementation Here

            //Generate Response
            var response = new Models.CalculationResponse(request);

            //Format your result, and save it to a blob.
            var outputBlob = binder.Bind<CloudBlockBlob>(new BlobAttribute($"calculationresponses/{response.CalculationId}"));
            outputBlob.UploadText(JsonConvert.SerializeObject(response));
        }
    }
}
