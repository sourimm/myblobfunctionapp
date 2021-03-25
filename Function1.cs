using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("demoblobtrigger/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            [Blob("output/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream opBlob,
            string name, ILogger log)
        {
            var len = myBlob.Length;
            myBlob.CopyTo(opBlob);
        }
    }
}
