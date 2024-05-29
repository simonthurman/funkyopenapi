using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;

namespace funkyswagger
{
    public class sayBye
    {
        private readonly ILogger _logger;

        public sayBye(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<sayBye>();
        }

        [Function("sayBye")]
        [OpenApiOperation(operationId: "sayBye", tags: new[] { "sayBye" }, Summary = "sayBye", Description = "sayBye", Visibility = OpenApiVisibilityType.Important)]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Good bye!");

            return response;
        }
    }
}
