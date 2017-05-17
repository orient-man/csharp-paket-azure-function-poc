//#load "../.paket/load/main.group.csx"
#r "System.Xml"
#r "System.Xml.Linq"
#r "System.Windows"
#r "System.Net.Http"
#r "../packages/Microsoft.AspNet.WebApi.Client/lib/net45/System.Net.Http.Formatting.dll"
#r "../packages/Microsoft.Azure.KeyVault.Core/lib/net45/Microsoft.Azure.KeyVault.Core.dll"
#r "../packages/Microsoft.Azure.WebJobs.Core/lib/net45/Microsoft.Azure.WebJobs.dll"
#r "../packages/Microsoft.Data.Edm/lib/net40/Microsoft.Data.Edm.dll"
#r "../packages/Microsoft.Tpl.Dataflow/lib/portable-net45+win8+wpa81/System.Threading.Tasks.Dataflow.dll"
#r "../packages/ncrontab/lib/net35/NCrontab.dll"
#r "../packages/Newtonsoft.Json/lib/net45/Newtonsoft.Json.dll"
#r "../packages/System.Spatial/lib/net40/System.Spatial.dll"
#r "../packages/Microsoft.AspNet.WebApi.Core/lib/net45/System.Web.Http.dll"
#r "../packages/Microsoft.Azure.WebJobs/lib/net45/Microsoft.Azure.WebJobs.Host.dll"
#r "../packages/Microsoft.Data.OData/lib/net40/Microsoft.Data.OData.dll"
#r "../packages/Microsoft.AspNet.WebApi.WebHost/lib/net45/System.Web.Http.WebHost.dll"
#r "../packages/Microsoft.Azure.WebJobs.Extensions/lib/net45/Microsoft.Azure.WebJobs.Extensions.dll"
#r "../packages/Microsoft.Data.Services.Client/lib/net40/Microsoft.Data.Services.Client.dll"
#r "../packages/WindowsAzure.Storage/lib/net45/Microsoft.WindowsAzure.Storage.dll"
#load "dep1.csx"
#r "System.Net.Http"

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        .Value;

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    name = name ?? data?.name;

    return name == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
}