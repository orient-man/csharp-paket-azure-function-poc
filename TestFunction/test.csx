#load "dep1.csx"
#load "run.csx"

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

var z = new Adder().Add(2, 2);
Console.WriteLine($"{z}");